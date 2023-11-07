using AutoMapper;
using Cnx.Caiman.Core.DTOs.Agreement;
using Cnx.Caiman.Core.DTOs.Hour;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Exceptions;
using Cemex.Core.Extension;
using ClosedXML.Excel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Services
{
    public class AgreementService: IAgreementService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;
        public AgreementService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper Mapper)
        {
            this.unitOfWork = unitOfWork;
            this.paginationConfiguration = options.Value;
            this.mapper = Mapper;
        }

        public async Task<ApiResponse<int>> GetTIDAsync(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new BusinessException("El campo descripcion no puede ser nulo.");
            }

            var result = await this.unitOfWork.AgreementRepository.GetTIDAsync(description);
            var response = new ApiResponse<int>(result);


            return response;
        }

        public async Task<ApiResponse<bool>> InfoAsync(int idzone)
        {
            if (idzone == 0)
            {
                throw new BusinessException("El valor tiene que ser mayor a cero.");
            }

            var result = (await this.unitOfWork.AgreementRepository.InfoAsync(idzone)) == 1;

            var response = new ApiResponse<bool>(result);

            return response;
        }

        public async Task<ApiResponse<IEnumerable<AgreementDto>>> ListSearchAsync(FilterGrid filter)
        {
            List<KeyValuePair<string, string>> FiltersReconstructor = new List<KeyValuePair<string, string>>();

            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;

            if (filter.Filters.Any(k => k.Key.Contains(".")))
            {
                filter.Filters.ForEach(delegate (KeyValuePair<string, string> item) {
                    if(item.Key == "relTraduccionRestriccion.vc8000Traduccion")
                    {
                        FiltersReconstructor.Add(new KeyValuePair<string, string>("vc8000Traduccion", item.Value));
                    }
                    else
                    {
                        FiltersReconstructor.Add(new KeyValuePair<string, string>(item.Key, item.Value));
                    }
                });

                filter.Filters.Clear();
                filter.Filters = FiltersReconstructor;
            }

            var objects = await this.unitOfWork.AgreementRepository.ListSearchAsync(filter.GetProperties(hasPaginationProperties: true));

            var entity = (IEnumerable<Restriccion>)objects.GetType().GetProperty("records").GetValue(objects);
            var totalCount = (int)objects.GetType().GetProperty("count").GetValue(objects);

            var responsePage = PageList<Restriccion>.Create(entity, totalCount, filter.Paging.PageNumber, filter.Paging.PageSize);

            var map = this.mapper.Map<List<AgreementDto>>(responsePage);

            var response = new ApiResponse<IEnumerable<AgreementDto>>(map).ToPagination(responsePage);

            return response;
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            var agreements = await this.unitOfWork.AgreementRepository.ListSearchAsync(filter.GetProperties());
            var entity = (IEnumerable<Restriccion>)agreements.GetType().GetProperty("records").GetValue(agreements);

            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<Restriccion>(entity, filter.Columns, "Reporte convenios");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<ApiResponse<IEnumerable<RestrictionTypeDto>>> ByTypeAsync()
        {
                var entity = await this.unitOfWork.AgreementRepository.ByTypeAsync();
                var map = this.mapper.Map<List<RestrictionTypeDto>>(entity);

                var response = new ApiResponse<IEnumerable<RestrictionTypeDto>>(map);

                return response;
        }

        public async Task<ApiResponse<IEnumerable<ProfileAgreementDTO>>> ProfileListAsync()
        {
            var entity = await this.unitOfWork.AgreementRepository.ProfileListAsync();
            var map = this.mapper.Map<List<ProfileAgreementDTO>>(entity);

            var response = new ApiResponse<IEnumerable<ProfileAgreementDTO>>(map);

            return response;
        }

        public async Task<ApiResponse<IEnumerable<FrequencyAgreementDto>>> FrequencyAsync()
        {
            var entity = await this.unitOfWork.AgreementRepository.FrequencyAsync();
            var map = this.mapper.Map<List<FrequencyAgreementDto>>(entity);

            var response = new ApiResponse<IEnumerable<FrequencyAgreementDto>>(map);

            return response;
        }

        public async Task<ApiResponse<AgreementDto>> RestrictionInfoAsync(int idrestriction)
        {
            var entity = await this.unitOfWork.AgreementRepository.RestrictionInfoAsync(idrestriction);
            var map = this.mapper.Map<AgreementDto>(entity);

            var response = new ApiResponse<AgreementDto>(map);

            return response;
        }

        public async Task<ApiResponse<EsqPivPronDto>> FindInfoAsync(FindInfoDto model)
        {
            var entity = await this.unitOfWork.AgreementRepository.FindInfoAsync(model);
            var map = this.mapper.Map<EsqPivPronDto>(entity);

            var response = new ApiResponse<EsqPivPronDto>(map);

            return response;
        }

        public async Task<ApiResponse<IEnumerable<AgreementDto>>> GetByDailyPlanAsync(FilterGrid filter)
        {

            List<KeyValuePair<string, string>> FiltersReconstructor = new List<KeyValuePair<string, string>>();

            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;

            if (filter.Filters.Any(k => k.Key.Contains(".")))
            {
                filter.Filters.ForEach(delegate (KeyValuePair<string, string> item) {
                    if (item.Key == "relTraduccionRestriccion.vc8000Traduccion")
                    {
                        FiltersReconstructor.Add(new KeyValuePair<string, string>("vc8000Traduccion", item.Value));
                    }
                    else
                    {
                        FiltersReconstructor.Add(new KeyValuePair<string, string>(item.Key, item.Value));
                    }
                });

                filter.Filters.Clear();
                filter.Filters = FiltersReconstructor;
            }

            var objects = await this.unitOfWork.AgreementRepository.GetByDailyPlanAsync(filter.GetProperties(hasPaginationProperties: true, hasIdUserProperties:true));

            var entity = (IEnumerable<Restriccion>)objects.GetType().GetProperty("records").GetValue(objects);
            var totalCount = (int)objects.GetType().GetProperty("count").GetValue(objects);

            var responsePage = PageList<Restriccion>.Create(entity, totalCount, filter.Paging.PageNumber, filter.Paging.PageSize);

            var map = this.mapper.Map<List<AgreementDto>>(responsePage);

            var response = new ApiResponse<IEnumerable<AgreementDto>>(map).ToPagination(responsePage);

            return response;
        }

        public async Task<ApiResponse<string>> ExportDailyPlanAsync(FilterGrid filter)
        {
            var agreements = await this.unitOfWork.AgreementRepository.GetByDailyPlanAsync(filter.GetProperties(hasIdUserProperties: true));
            var entity = (IEnumerable<Restriccion>)agreements.GetType().GetProperty("records").GetValue(agreements);
            var map = this.mapper.Map<IEnumerable<AgreementDto>>(entity);
            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<AgreementDto>(map, filter.Columns, "Reporte convenios");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<int> InsertAsync(AgreementSaveDto agreement)
        {

            var response = await this.unitOfWork.AgreementRepository.InsertAsync(agreement);

            return response;
        }

        public async Task<int> UpdateAsync(AgreementSaveDto agreement)
        {
            var response = await this.unitOfWork.AgreementRepository.UpdateAsync(agreement);

            return response;
        }

        public async Task<int> UpdateDailyPlanAsync(AgreementDailyPlanDto agreement)
        {
            if (agreement.idzone == 0)
            {
                throw new BusinessException("El valor zona tiene que ser mayor a cero.");
            }


            var response = await this.unitOfWork.AgreementRepository.UpdateDpAsync(agreement);

            return response;
        }

        public async Task<int> DeleteAsync(int idagreement)
        {
            if (idagreement == 0)
            {
                throw new BusinessException("El valor Id no puede ser vacio.");
            }

            var response = await this.unitOfWork.AgreementRepository.DeleteAsync(idagreement);

            return response;
        }

        public async Task<int> DeleteTransacAsync(long TID)
        {
            if (TID == 0)
            {
                throw new BusinessException("El valor Id no puede ser vacio.");
            }

            var response = await this.unitOfWork.AgreementRepository.DeleteTransacAsync(TID);

            return response;
        }

        public async Task<ApiResponse<IEnumerable<HourDto>>> GetRestrictionAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.AgreementRepository.GetRestrictionAsync(idZone, tid, filter.Search);
            var productsPage = PageList<Horario>.Create(result, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<List<HourDto>>(productsPage);


            var response = new ApiResponse<IEnumerable<HourDto>>(map).ToPagination(productsPage);

            return response;
        }

        public async Task InsertRestrictionAsync(HourRestrictionDto data)
        {
            if (data.tid == 0)
            {
                throw new BusinessException("The tid must be greater than zero.");
            }

            await this.unitOfWork.AgreementRepository.InsertRestrictionAsync(data);
        }

        public async Task<ApiResponse<IEnumerable<HourDto>>> GetRestrictionOneToOneAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.AgreementRepository.GetRestrictionOnetoOneAsync(idZone, tid, filter.Search);
            var productsPage = PageList<Horario>.Create(result, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<List<HourDto>>(productsPage);


            var response = new ApiResponse<IEnumerable<HourDto>>(map).ToPagination(productsPage);

            return response;
        }
    }
}
