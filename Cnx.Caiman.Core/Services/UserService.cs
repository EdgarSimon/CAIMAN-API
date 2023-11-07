using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.DTOs.User;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Exceptions;
using Cemex.Core.Extension;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Cnx.Caiman.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor context;
        public UserService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper mapper, IConfiguration configuration, IHttpContextAccessor context)
        {
            this.unitOfWork = unitOfWork;
            this.paginationConfiguration = options.Value;
            this.mapper = mapper;
            this.configuration = configuration;
            this.context = context;
        }

        public async Task InsertAsync(UserDto userDTO)
        {
            await this.unitOfWork.UserRepository.InsertAsync(userDTO);
        }

        public async Task UpdateAsync(UserDto userDTO)
        {
            await this.unitOfWork.UserRepository.UpdateAsync(userDTO);
        }

        public async Task UpdateInfoAsync(UserDto userDTO)
        {
            await this.unitOfWork.UserRepository.UpdateInfoAsync(userDTO);
        }

        public async Task DeleteAsync(int idUser)
        {
            await this.unitOfWork.UserRepository.DeleteAsync(idUser);
        }

        public async Task<ApiResponse<UserLoginResponseDto>> LoginAsync(string username, string password, string email)
        {
            var objectMultiple = await this.unitOfWork.UserRepository.LoginAsync(username, password);
            if (objectMultiple == null)
            {
                throw new BusinessException("InvalidUsername");
            }

            var userData =(ApiResponse<UserLoginResponseDto>)await this.DataUserAsync(objectMultiple);
            //Se deja el if debug para pruebas con el AD de CIBI por temas con el AD de CAIMAN
#if DEBUG
            string emailData = this.context.HttpContext.User.FindFirst("preferred_username")?.Value;
#else
            string emailData = this.context.HttpContext.User.Identity.Name;
#endif
            await this.unitOfWork.UserRepository.UpdateEmailAsync(userData.Data.User.IdUsuario, emailData);

            return userData;
        }

        public async Task<ApiResponse<UserLoginResponseDto>> getUserMailAsync()
        {
            //Se deja el if debug para pruebas con el AD de CIBI por temas con el AD de CAIMAN
#if DEBUG
            string email = this.context.HttpContext.User.FindFirst("preferred_username")?.Value;
#else
            string email = this.context.HttpContext.User.Identity.Name;
#endif

            var objectMultiple = await this.unitOfWork.UserRepository.GetUserForMailAsync(email);
            if (objectMultiple == null)
            {
                return new ApiResponse<UserLoginResponseDto>(null);
            }

            var userData = (ApiResponse<UserLoginResponseDto>)await this.DataUserAsync(objectMultiple);

            return userData;
        }

        private async Task<ApiResponse<UserLoginResponseDto>> DataUserAsync(dynamic objectMultiple)
        {
            var entity = (Usuario)objectMultiple.GetType().GetProperty("usuario").GetValue(objectMultiple);
            var zones = (IEnumerable<Zona>)objectMultiple.GetType().GetProperty("zonas").GetValue(objectMultiple);

            var userMapped = this.mapper.Map<UserDto>(entity);
            var zonesMapped = this.mapper.Map<IEnumerable<ZoneDto>>(zones);

            var resp = new UserLoginResponseDto
            {
                User = userMapped,
                Zones = zonesMapped
            };
            //add permission
            var menuMultiple = await this.unitOfWork.UserRepository.MenuPermitAsync(entity.IdUsuario, entity.IdZona);



            ModuleDto obtModule = new ModuleDto();
            List<ModuleDto> lsModule = new List<ModuleDto>();

            SubModuleDto obtSubModule = new SubModuleDto();
            List<SubModuleDto> lsSubModule = new List<SubModuleDto>();

            var module = (List<Modulo>)menuMultiple.GetType().GetProperty("module").GetValue(menuMultiple);
            var submodule = (List<SubModulo>)menuMultiple.GetType().GetProperty("submodule").GetValue(menuMultiple);
            var page = (List<Pagina>)menuMultiple.GetType().GetProperty("page").GetValue(menuMultiple);


            module.ForEach(delegate (Modulo itemMod)
            {
                obtModule = new ModuleDto();
                lsSubModule = new List<SubModuleDto>();
                var submoduleitem = submodule.Where(k => k.IdModulo == itemMod.IdModulo).ToList();
                submoduleitem.ForEach(delegate (SubModulo submod)
                {
                    obtSubModule = new SubModuleDto();
                    var pages = page.Where(k => k.IdSubModulo == submod.IdSubModulo).ToList();
                    var mapPages = this.mapper.Map<List<PageDto>>(pages);
                    obtSubModule.Pages = mapPages;
                    obtSubModule.IdModule = itemMod.IdModulo;
                    obtSubModule.IdSubModule = submod.IdSubModulo;
                    obtSubModule.Childs = submod.Hijos;
                    lsSubModule.Add(obtSubModule);
                });
                obtModule.IdModule = itemMod.IdModulo;
                obtModule.Name = itemMod.Vc100NombreModulo;
                obtModule.SubModule = lsSubModule;
                lsModule.Add(obtModule);
            });

            resp.Module = lsModule;

            var response = new ApiResponse<UserLoginResponseDto>(resp);

            return response;
        }

        public async Task<ApiResponse<IEnumerable<UserDto>>> FindByZoneAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;

            object objectMultiple = await this.unitOfWork.UserRepository.FindByZoneAsync(filter.GetProperties(hasPaginationProperties: true));

            var entity = (IEnumerable<Usuario>)objectMultiple.GetType().GetProperty("records").GetValue(objectMultiple);
            var totalCount = (int)objectMultiple.GetType().GetProperty("count").GetValue(objectMultiple);

            var responsePage = PageList<Usuario>.Create(entity, totalCount, filter.Paging.PageNumber, filter.Paging.PageSize);
            var map = this.mapper.Map<IEnumerable<UserDto>>(entity);

            var response = new ApiResponse<IEnumerable<UserDto>>(map).ToPagination(responsePage);
            return response;
        }

        public async Task<ApiResponse<IEnumerable<UserDto>>> getFindByZoneAsync(PaginationQuery filter, Nullable<int> idZone)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var parameters = new ExpandoObject() as IDictionary<String, object>;
            
            parameters.Add("idzona", (idZone!= null)? idZone: null);
            parameters.Add("pageNumber", filter.PageNumber);
            parameters.Add("pageSize", filter.PageSize);
            parameters.Add("vc20ClaveUsuario", filter.Search);


            object objectMultiple = await this.unitOfWork.UserRepository.FindByZoneAsync(parameters);

            var entity = (IEnumerable<Usuario>)objectMultiple.GetType().GetProperty("records").GetValue(objectMultiple);
            var totalCount = (int)objectMultiple.GetType().GetProperty("count").GetValue(objectMultiple);

            var responsePage = PageList<Usuario>.Create(entity, totalCount, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<IEnumerable<UserDto>>(entity);

            var response = new ApiResponse<IEnumerable<UserDto>>(map).ToPagination(responsePage);
            return response;
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            var user = await this.unitOfWork.UserRepository.FindByZoneAsync(filter.GetProperties());
            
            var entity = (IEnumerable<Usuario>)user.GetType().GetProperty("records").GetValue(user);
            var map = this.mapper.Map<IEnumerable<UserDto>>(entity);

            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<UserDto>(map, filter.Columns, "Reporte convenios");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<ApiResponse<UserDto>> GetInfoAsync(int idUser)
        {
            var entity = await this.unitOfWork.UserRepository.GetInfoAsync(idUser);
            if (entity == null)
            {
                throw new BusinessException("User not exist");
            }

            var map = this.mapper.Map<UserDto>(entity);
            var response = new ApiResponse<UserDto>(map);

            return response;
        }        

        public async Task<ApiResponse<ProfileDto>> GetProfileAsync(int idZone, int idUser)
        {
            var entity = await this.unitOfWork.UserRepository.GetProfileAsync(idZone, idUser);
            if (entity == null)
            {
                throw new BusinessException("User not exist");
            }

            var map = this.mapper.Map<ProfileDto>(entity);
            var response = new ApiResponse<ProfileDto>(map);

            return response;
        }


        public async Task<ApiResponse<List<UserZoneDto>>> GetUserZoneAsync(int idUser, int idUserUpdate)
        {

            var entity = await this.unitOfWork.UserRepository.GetUserZoneAsync(idUser, idUserUpdate);
            if (entity == null)
            {
                throw new BusinessException("User not exist");
            }

            var map = this.mapper.Map<List<UserZoneDto>>(entity);
            var response = new ApiResponse<List<UserZoneDto>>(map);

            return response;
        }

        public async Task UpdateUserZoneAsync(UserZoneUpdateDto model)
        {
            foreach (var item in model.zona)
            {
                await this.unitOfWork.UserRepository.UpdateUserZoneAsync(model.iduser, item.Id, item.Acess);
            }
        }

        public async Task<ApiResponse<List<UserProfileDto>>> GetByProfileAsync(int idZone, int idUser)
        {
            var entity = await this.unitOfWork.UserRepository.GetUserProfileAsync(idZone, idUser);
            if (entity == null)
            {
                throw new BusinessException("User not exist");
            }

            var map = this.mapper.Map<List<UserProfileDto>>(entity);
            var response = new ApiResponse<List<UserProfileDto>>(map);

            return response;
        }
        public async Task UpdateUserProfileAsync(UserProfileUpdateDto model)
        {
            await this.unitOfWork.UserRepository.UpdateUserProfileAsync(model);
        }

        public async Task<ApiResponse<List<UserPermitDto>>> GetPagePermitAsync(int idZone, int idUser, int option)
        {
            var entity = await this.unitOfWork.UserRepository.GetPagePermitAsync(idZone, idUser, option);
            if (entity == null)
            {
                throw new BusinessException("User not exist");
            }

            var map = this.mapper.Map<List<UserPermitDto>>(entity);
            var response = new ApiResponse<List<UserPermitDto>>(map);

            return response;
        }

        public async Task UpdateUserPermitAsync(UserPermitUpdateDto model)
        {
            foreach (var item in model.Page)
            {
                UserchekUpdateDto detail = new UserchekUpdateDto()
                {
                    Acess = item.Acess,
                    Id = item.Id
                };
                await this.unitOfWork.UserRepository.UpdateUserPermitAsync(model, detail);
            }
            
        }

        public async Task<ApiResponse<List<KeyValuePair<string, int>>>> GetByPlanDailyAsync(int idZone, int idUser)
        {
            var entity = await this.unitOfWork.UserRepository.GetByPlanDailyAsync(idZone, idUser);

            if (entity == null)
            {
                throw new BusinessException("User not exist");
            }
            var response = new ApiResponse<List<KeyValuePair<string, int>>>(entity);

            return response;
        }

        public async Task UpdatePlanDailyAsync(UserPlanDailyUpdateDto model)
        {
            await this.unitOfWork.UserRepository.UpdatePlanDailyAsync(model);
        }

        public async Task<ApiResponse<List<UserDailyPlanPermisionDto>>> GetPermisionAgreggentAsync(int idzone, int iduser, int module)
        {

            List<RelUsuarioPermisoAdmin> entity;

            if (module == 1)
                entity = await this.unitOfWork.UserRepository.GetPlanDailyAgreggentAsync(idzone, iduser);
            else
                entity = await this.unitOfWork.UserRepository.GetMonitorAgreggentAsync(idzone, iduser);

            if (entity == null)
            {
                throw new BusinessException("User not exist");
            }
            var map = this.mapper.Map<List<UserDailyPlanPermisionDto>>(entity);

            var response = new ApiResponse<List<UserDailyPlanPermisionDto>>(map);

            return response;
        }

        public async Task UpdateAgreggentAsync(UserPermisionPlanDailyDto model)
        {
            if (model.module == 1)
            {
                foreach (var item in model.Marcado)
                {
                    await this.unitOfWork.UserRepository.UpdateAgreggentAsync(model, item);
                }
            }
            else
            {
                foreach (var item in model.Marcado)
                {
                    await this.unitOfWork.UserRepository.UpdateMonitorAgreggentAsync(model, item);
                }
            }
        }

        public async Task UpdateAgreggentAllAsync(UserPermisionPlanDailyAllDto model)
        {
            if(model.module == 1)
            {
                await this.unitOfWork.UserRepository.UpdateAgreggentAllAsync(model);
            }
            else
            {
                await this.unitOfWork.UserRepository.UpdateMonitorAgreggentAllAsync(model);
            }
        }

        public async Task<ApiResponse<List<UserDailyPlanPermisionDto>>> GetPlanDailyConcretAsync(int idzone, int iduser, int module)
        {
            List<RelUsuarioPermisoAdmin> entity;

            if (module == 1)
            {
                entity = await this.unitOfWork.UserRepository.GetPlanDailyConcretAsync(idzone, iduser);
            }
            else
            {
                entity = await this.unitOfWork.UserRepository.GetMonitorConcretAsync(idzone, iduser);
            }

            if (entity == null)
            {
                throw new BusinessException("User not exist");
            }
            var map = this.mapper.Map<List<UserDailyPlanPermisionDto>>(entity);

            var response = new ApiResponse<List<UserDailyPlanPermisionDto>>(map);

            return response;
        }

        public async Task UpdateConcretAsync(UserPermisionPlanDailyDto model)
        {
            if (model.module == 1)
            {
                foreach (var item in model.Marcado)
                {
                    await this.unitOfWork.UserRepository.UpdateConcretAsync(model, item);
                }
            }
            else
            {
                foreach (var item in model.Marcado)
                {
                    await this.unitOfWork.UserRepository.UpdateMonitorConcretAsync(model, item);
                }
                
            }
        }

        public async Task UpdateConcretAllAsync(UserPermisionPlanDailyAllDto model)
        {
            if (model.module == 1)
            {
                await this.unitOfWork.UserRepository.UpdateConcretAllAsync(model);
            }
            else
            {
                await this.unitOfWork.UserRepository.UpdateMonitorConcretAllAsync(model);
            }
        }


        public async Task<ApiResponse<List<UserDailyPlanPermisionDto>>> GetPlanDailyShipperAsync(int idzone, int iduser, int module)
        {
            List<RelUsuarioPermisoAdmin> entity;
            if(module == 1)
            {
                entity = await this.unitOfWork.UserRepository.GetPlanDailyShipperAsync(idzone, iduser);
            }
            else
            {
                entity = await this.unitOfWork.UserRepository.GetMonitorShipperAsync(idzone, iduser);
            }

            if (entity == null)
            {
                throw new BusinessException("User not exist");
            }
            var map = this.mapper.Map<List<UserDailyPlanPermisionDto>>(entity);

            var response = new ApiResponse<List<UserDailyPlanPermisionDto>>(map);

            return response;
        }

        public async Task UpdateShipperAsync(UserPermisionPlanDailyDto model)
        {
            if (model.module == 1)
            {
                foreach (var item in model.Marcado)
                {
                    await this.unitOfWork.UserRepository.UpdateShipperAsync(model, item);
                }
            }
            else
            {
                foreach (var item in model.Marcado)
                {
                    await this.unitOfWork.UserRepository.UpdateMonitorShipperAsync(model, item);
                }
            }

        }

        public async Task UpdateShipperAllAsync(UserPermisionPlanDailyAllDto model)
        {
            if (model.module == 1)
            {
                await this.unitOfWork.UserRepository.UpdateShipperAllAsync(model);
            }
            else
            {
                await this.unitOfWork.UserRepository.UpdateMonitorShipperAllAsync(model);
            }
        }

        public async Task<ApiResponse<List<KeyValuePair<string, int>>>> GetByMonitorAsync(int idZone, int idUser)
        {
            var entity = await this.unitOfWork.UserRepository.GetByMonitorAsync(idZone, idUser);

            if (entity == null)
            {
                throw new BusinessException("");
            }
            var response = new ApiResponse<List<KeyValuePair<string, int>>>(entity);

            return response;
        }

        public async Task UpdateMonitorAsync(UserSecurityManagementDto model)
        {
            await this.unitOfWork.UserRepository.UpdateMonitorAsync(model);
        }

        public async Task UserClonAsync(UserClonDto model)
        {
            await this.unitOfWork.UserRepository.UserClonAsync(model);
        }

        public async Task<ApiResponse<IEnumerable<RelUserPermissionsDto>>> PagePermissionsAsync(int idZone, int idUser, int page)
        {
            var entity = await this.unitOfWork.UserRepository.PagePermissionsAsync(idZone, idUser, page);
            if (entity == null)
            {
                throw new BusinessException("User not exist");
            }

            var map = this.mapper.Map<IEnumerable<RelUserPermissionsDto>>(entity);

            var response = new ApiResponse<IEnumerable<RelUserPermissionsDto>>(map);

            return response;
        }

    }
}
