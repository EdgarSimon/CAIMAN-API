using System.Collections;
using System;
using AutoMapper;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Exceptions;
using Cemex.Core.Extension;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using ClosedXML.Excel;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Zone;
using Cnx.Caiman.Core.Enums;

namespace Cnx.Caiman.Core.Services
{
    public class ZoneService : IZoneService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;

        public ZoneService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper Mapper)
        {
            this.unitOfWork = unitOfWork;
            paginationConfiguration = options.Value;
            this.mapper = Mapper;
        }

        public async Task<ApiResponse<IEnumerable<ZoneDto>>> ListAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            var zones = await this.unitOfWork.ZoneRepository.ListAsync(filter.GetProperties(hasIdUserProperties: true));
            var responsePage = PageList<Zona>.Create(zones, filter.Paging.PageNumber, filter.Paging.PageSize);
            var zonesDto = this.mapper.Map<IEnumerable<ZoneDto>>(responsePage);
            var response = new ApiResponse<IEnumerable<ZoneDto>>(zonesDto);
            return response.ToPagination((object)responsePage);
        }
        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            IEnumerable<Zona> zones = await this.unitOfWork.ZoneRepository.ListAsync(filter.GetProperties(hasIdUserProperties: true));
            using(var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<Zona>(zones, filter.Columns, "Reporte Zonas");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<ApiResponse<ZoneDto>> ListProfileZoneAsync(int iduser, int idzone)
        {
            if (iduser == 0)
            {
                throw new BusinessException("The User must be greater than 0.");
            }

            var entity = await this.unitOfWork.ZoneRepository.ListProfileZoneAsync(iduser, idzone);
            var map = this.mapper.Map<ZoneDto>(entity);
            
            var response = new ApiResponse<ZoneDto>(map);

            return response;
        }

        public async Task<ApiResponse<IEnumerable<ZoneDto>>> ProfileNameAsync(PaginationQuery filter, int idzone)
        {

            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var entity = await this.unitOfWork.ZoneRepository.ProfileNameAsync(idzone);
            var responsePage = PageList<Zona>.Create(entity, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<List<ZoneDto>>(responsePage);
            var response = new ApiResponse<IEnumerable<ZoneDto>>(map).ToPagination(responsePage);

            return response;
        }

        public async Task<ApiResponse<IEnumerable<MeasurementDto>>> MeasuringListAsync()
        {
            var entity = await this.unitOfWork.ZoneRepository.MeasuringListAsync();
            var map = this.mapper.Map<List<MeasurementDto>>(entity);
            
            var response = new ApiResponse<IEnumerable<MeasurementDto>>(map);

            return response;

        }

        public async Task<int> InsertAsync(ZoneInsertDto zoneModel)
        {
            if (string.IsNullOrEmpty(zoneModel.Vc50Nombre))
            {
                throw new BusinessException("El valor no puede ser nulo.");
            }

            var response = await this.unitOfWork.ZoneRepository.InsertAsync(zoneModel);
            if (response == (int)StatusExceptions.ErrorDuplicate)
                throw new DuplicateException(MessageCodesErrors.Duplicate);
            return response;
        }

        public async Task<int> UpdateAsync(int idZone, ZoneInsertDto zoneModel)
        {
            if (idZone == 0)
            {
                throw new BusinessException("El valor Id no puede ser vacio.");
            }

            if (string.IsNullOrEmpty(zoneModel.Vc50Nombre))
            {
                throw new BusinessException("El valor no puede ser nulo.");
            }
            var response = await this.unitOfWork.ZoneRepository.UpdateAsync(idZone, zoneModel);

            return response;
        }

        public async Task<int> DeleteAsync(int idzone)
        {
            if (idzone == 0)
            {
                throw new BusinessException("El valor Id no puede ser vacio.");
            }
            
            var response = await this.unitOfWork.ZoneRepository.DeleteAsync(idzone);

            return response;
        }

        public async Task<ApiResponse<List<ZoneDto>>> ListByUserAsync(int iduser)
        {
            if (iduser == 0)
            {
                throw new BusinessException("The User must be greater than 0.");
            }

            var entity = await this.unitOfWork.ZoneRepository.ListByUserAsync(iduser);
            var map = this.mapper.Map<List<ZoneDto>>(entity);

            var response = new ApiResponse<List<ZoneDto>>(map);

            return response;
        }
    }
}
