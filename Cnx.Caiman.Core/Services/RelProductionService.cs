using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cnx.Caiman.Core.DTOs.Distance;
using Cnx.Caiman.Core.DTOs.Origin;
using Cnx.Caiman.Core.DTOs.Product;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Extension;
using ClosedXML.Excel;
using Microsoft.Extensions.Options;

namespace Cnx.Caiman.Core.Services
{
    public class RelProductionService : IRelProductionService
    {
       private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;

        public RelProductionService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper Mapper)
        {
            this.unitOfWork = unitOfWork;
            paginationConfiguration = options.Value;
            this.mapper = Mapper;
        }

        public async Task<int> DeleteProductOriginAsync(int idRel)
        {
            return await this.unitOfWork.RelProductionRepository.DeleteProductOriginAsync(idRel);
        }

        public async Task<ApiResponse<IEnumerable<RelProductionDto>>> GetAsync(int idOrigin, PaginationQuery filter)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;
            var relProductions = await this.unitOfWork.RelProductionRepository.GetAsync(idOrigin);
            var relProductionsPage = PageList<RelProduccion>.Create(relProductions, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<IEnumerable<RelProductionDto>>(relProductionsPage);
            return new ApiResponse<IEnumerable<RelProductionDto>>(map).ToPagination(relProductionsPage);
        }

        public async Task<ApiResponse<IEnumerable<ProductDto>>> GetProductosByZoneAsync(PaginationQuery filter, int idOrigin, int idZone)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;
            var productos = await unitOfWork.RelProductionRepository.GetProductosByZoneAsync(idOrigin, idZone, filter.Search);
            var productosPage = PageList<Producto>.Create(productos, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<IEnumerable<ProductDto>>(productosPage);
            return new ApiResponse<IEnumerable<ProductDto>>(map).ToPagination(productosPage);
        }

        public async Task<ApiResponse<IEnumerable<RelProductionDto>>> GetValuesOriginAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            IEnumerable<RelProduccion> relProductions = await this.unitOfWork.RelProductionRepository.GetValuesOriginAsync(filter.GetProperties());
            var relProductionsPage = PageList<RelProduccion>.Create(relProductions, filter.Paging.PageNumber, filter.Paging.PageSize);
            var map = this.mapper.Map<IEnumerable<RelProductionDto>>(relProductionsPage);
            return new ApiResponse<IEnumerable<RelProductionDto>>(map).ToPagination(relProductionsPage);
        }

        public async Task<ApiResponse<string>> GetValuesOriginExportAsync(FilterGrid filter)
        {
            IEnumerable<RelProduccion> relProductions = await this.unitOfWork.RelProductionRepository.GetValuesOriginAsync(filter.GetProperties());
            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<RelProduccion>(relProductions, filter.Columns, "Reporte Sobrecostos");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<int> InsertProductOriginAsync(RelOriginProductInsertDto data)
        {
            return await this.unitOfWork.RelProductionRepository.InsertProductOriginAsync(data);
        }

        public async Task<int> UpdateCostProductOverrunAsync(CostProductOverrunUpdateDto data)
        {
            var response = await this.unitOfWork.RelProductionRepository.UpdateCostProductOverrunAsync(data);
            return response;
        }

        public async Task<int> UpdateProductOriginAsync(RelOriginProductInsertDto data, int idRel)
        {
            return await this.unitOfWork.RelProductionRepository.UpdateProductOriginAsync(data, idRel);
        }
    }
}
