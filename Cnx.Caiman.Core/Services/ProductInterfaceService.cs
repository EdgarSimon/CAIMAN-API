using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cnx.Caiman.Core.DTOs.ProductInterface;
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
    public class ProductInterfaceService: IProductInterfaceService
    {
        private IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;

        public ProductInterfaceService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.paginationConfiguration = options.Value;
        }

        public async Task<ApiResponse<IEnumerable<ProductInterfaceDto>>> GetAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            var productsInterface = await this.unitOfWork.ProductInterfaceRepository.GetAsync(filter.GetProperties());
            var productsInterfacePage = PageList<ProductoInterfaz>.Create(productsInterface, filter.Paging.PageNumber, filter.Paging.PageSize);
            var productsInterfaceDto = this.mapper.Map<IEnumerable<ProductInterfaceDto>>(productsInterfacePage);
            return new ApiResponse<IEnumerable<ProductInterfaceDto>>(productsInterfaceDto).ToPagination((object)productsInterfacePage);
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            IEnumerable<ProductoInterfaz> productsInterface = await this.unitOfWork.ProductInterfaceRepository.GetAsync(filter.GetProperties());
            using(var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<ProductoInterfaz>(productsInterface, filter.Columns, "Reporte Productos interfaz");
                return new ApiResponse<string>(base64);
            }
            
        }

        public async Task<int> InsertAsync(ProductInterfaceInsertDto parameters)
        {
            return await this.unitOfWork.ProductInterfaceRepository.InsertAsync(parameters);
        }

        public async Task<int> UpdateAsync(ProductInterfaceInsertDto parameters)
        {
            return await this.unitOfWork.ProductInterfaceRepository.UpdateAsync(parameters);
        }

        public async Task<int> DeleteAsync(string vcSap)
        {
            return await this.unitOfWork.ProductInterfaceRepository.DeleteAsync(vcSap);
        }
    }
}
