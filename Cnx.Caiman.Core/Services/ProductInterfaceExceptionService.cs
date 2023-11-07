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
    public class ProductInterfaceExceptionService: IProductInterfaceExceptionService
    {
        private IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;

        public ProductInterfaceExceptionService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.paginationConfiguration = options.Value;
        }

        public async Task<ApiResponse<IEnumerable<ProductInterfaceExceptionDto>>> GetAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            var productsInterfaceExceptions = await this.unitOfWork.ProductInterfaceExceptionRepository.GetAsync(filter.GetProperties());
            var productsInterfaceExceptionsPage = PageList<ProductoInterfazExcepcion>.Create(productsInterfaceExceptions, filter.Paging.PageNumber, filter.Paging.PageSize);
            var productsInterfaceExceptionsDto = this.mapper.Map<IEnumerable<ProductInterfaceExceptionDto>>(productsInterfaceExceptionsPage);
            return new ApiResponse<IEnumerable<ProductInterfaceExceptionDto>>(productsInterfaceExceptionsDto).ToPagination((object)productsInterfaceExceptionsPage);
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            IEnumerable<ProductoInterfazExcepcion> productsInterfaceExceptions = await this.unitOfWork.ProductInterfaceExceptionRepository.GetAsync(filter.GetProperties());
            using(var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<ProductoInterfazExcepcion>(productsInterfaceExceptions, filter.Columns, "Reporte Productos excepcioens");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<int> InsertAsync(ProductInterfaceExceptionInsertDto parameters)
        {
            return await this.unitOfWork.ProductInterfaceExceptionRepository.InsertAsync(parameters);
        }

        public async Task<int> UpdateAsync(ProductInterfaceExceptionInsertDto parameters)
        {
            return await this.unitOfWork.ProductInterfaceExceptionRepository.UpdateAsync(parameters);
        }

        public async Task<int> DeleteAsync(string vcSap)
        {
            return await this.unitOfWork.ProductInterfaceExceptionRepository.DeleteAsync(vcSap);
        }
    }
}
