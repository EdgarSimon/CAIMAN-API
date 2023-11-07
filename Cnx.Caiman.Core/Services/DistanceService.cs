using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cnx.Caiman.Core.DTOs.Distance;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.Filters;
using Cnx.Caiman.Core.Entities.QueryEntities.TariffDestinationProduct;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Extension;
using ClosedXML.Excel;
using Microsoft.Extensions.Options;

namespace Cnx.Caiman.Core.Services
{
    public class DistanceService : IDistanceService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;

        public DistanceService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper Mapper)
        {
            this.unitOfWork = unitOfWork;
            paginationConfiguration = options.Value;
            this.mapper = Mapper;
        }

        public async Task<ApiResponse<IEnumerable<TariffDestinationProductDto>>> TariffConsultOriginProductAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;

            IEnumerable<TarifaConsultarDestinoProducto> distances = await this.unitOfWork.DistanceRepository.TariffConsultOriginProductAsync(filter.GetProperties());
            var responsePage = PageList<TarifaConsultarDestinoProducto>.Create(distances, filter.Paging.PageNumber, filter.Paging.PageSize);
            var map = this.mapper.Map<List<TariffDestinationProductDto>>(responsePage);

            var response = new ApiResponse<IEnumerable<TariffDestinationProductDto>>(map).ToPagination(responsePage);

            return response;
        }

        public async Task<ApiResponse<string>> TariffConsultOriginProductExportAsync(FilterGrid filter)
        {

            IEnumerable<TarifaConsultarDestinoProducto> distances = await this.unitOfWork.DistanceRepository.TariffConsultOriginProductAsync(filter.GetProperties());
            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<TarifaConsultarDestinoProducto>(distances, filter.Columns, "Reporte Distancias por origen");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<ApiResponse<IEnumerable<TariffDestinationProductDto>>> TariffConsultDestinationProductAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;

            var distances =(IEnumerable<TarifaConsultarDestinoProducto>) await this.unitOfWork.DistanceRepository.TariffConsultDestinationProductAsync(filter.GetProperties());
            var responsePage = PageList<TarifaConsultarDestinoProducto>.Create(distances, filter.Paging.PageNumber, filter.Paging.PageSize);
            var map = this.mapper.Map<List<TariffDestinationProductDto>>(responsePage);

            var response = new ApiResponse<IEnumerable<TariffDestinationProductDto>>(map).ToPagination(responsePage);

            return response;
        }

        public async Task<ApiResponse<string>> TariffConsultDestinationProductExportAsync(FilterGrid filter)
        {

            IEnumerable<TarifaConsultarDestinoProducto> distances = await this.unitOfWork.DistanceRepository.TariffConsultDestinationProductAsync(filter.GetProperties());
            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<TarifaConsultarDestinoProducto>(distances, filter.Columns, "Reporte Distancias");
                return new ApiResponse<string>(base64);
            }
        }

        public Task<int> UpdateAsync(DistanceUpdateDto data)
        {
            return this.unitOfWork.DistanceRepository.UpdateAsync(data);
        }
    }
}