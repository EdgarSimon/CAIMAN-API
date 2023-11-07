using AutoMapper;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.DTOs.SubZone;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.Filters;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Exceptions;
using Cemex.Core.Extension;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Services
{
    public class SubZoneService: ISubZoneService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;
        public SubZoneService(IUnitOfWork unitOfWork, IMapper mapper, IOptions<PaginationConfiguration> paginationConfiguration)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.paginationConfiguration = paginationConfiguration.Value;
        }

        public async Task<ApiResponse<IEnumerable<SubZoneDto>>> GetAsync(PaginationQuery filter, int idzone)
        {
            if (idzone != 0)
            {
                filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
                filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

                var entity = await this.unitOfWork.SubZoneRepository.GetAsync(idzone);
                var responsePage = PageList<SubZona>.Create(entity, filter.PageNumber, filter.PageSize);
                var map = this.mapper.Map<List<SubZoneDto>>(responsePage);

                var response = new ApiResponse<IEnumerable<SubZoneDto>>(map).ToPagination(responsePage);

                return response;
            }
            else
            {
                throw new BusinessException("El id zona debe ser mayor a cero.");
            }
        }


        public async Task<int> PutAsync(SubZoneInsertDto model)
        {
            var response = await this.unitOfWork.SubZoneRepository.PutAsync(model);

            return response;
        }


        public async Task<int> PostAsync(SubZoneUpdateDto model)
        {
            var response = await this.unitOfWork.SubZoneRepository.PostAsync(model);

            return response;
        }

        public async Task<int> DeleteAsync(int idsubzone, string user)
        {
            if (idsubzone == 0)
            {
                throw new BusinessException("El valor no puede ser 0.");
            }

            var response = await this.unitOfWork.SubZoneRepository.DeleteAsync(idsubzone, user);

            return response;
        }

        public async Task<ApiResponse<IEnumerable<SubZoneDto>>> GetAllByZonaAsync(ZoneIntFilter filter)
        {
                filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
                filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

                var entity = await this.unitOfWork.SubZoneRepository.GetAllByZonaAsync(filter.IdZona);
                var responsePage = PageList<SubZona>.Create(entity, filter.PageNumber, filter.PageSize);
                var map = this.mapper.Map<List<SubZoneDto>>(responsePage);
                var response = new ApiResponse<IEnumerable<SubZoneDto>>(map).ToPagination(responsePage);
                return response;
        }

        public async Task<ApiResponse<IEnumerable<SubZoneDto>>> GetByZoneOptionAllAsync(ZoneIntFilter filter)
        {
            List<SubZoneDto> list = new List<SubZoneDto>();
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var entity = await this.unitOfWork.SubZoneRepository.GetByZoneOptionAllAsync(filter.IdZona);
            var responsePage = PageList<KeyValuePair<int,string>>.Create(entity, filter.PageNumber, filter.PageSize);

            responsePage.ForEach(delegate (KeyValuePair<int, string> item)
            {
                list.Add(new SubZoneDto() { IdSubZona= item.Key, Vc50Nombre= item.Value });
            });


            var response = new ApiResponse<IEnumerable<SubZoneDto>>(list).ToPagination(responsePage);
            return response;
        }
    }
}
