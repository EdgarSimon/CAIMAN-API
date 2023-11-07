using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cnx.Caiman.Core.DTOs.Destination;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Extension;
using Microsoft.Extensions.Options;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Cnx.Caiman.Core.Services
{
    public class CustomerService: ICustomerService
    {   
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;

        public CustomerService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper Mapper)
        {
            this.unitOfWork = unitOfWork;
            paginationConfiguration = options.Value;
            this.mapper = Mapper;
        }

        public async Task<ApiResponse<IEnumerable<DestinationDto>>> GetAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            var customers = await this.unitOfWork.CustomerRepository.GetAsync(filter.GetProperties());
            var responsePage = PageList<Destino>.Create(customers, filter.Paging.PageNumber, filter.Paging.PageSize);
            var map = this.mapper.Map<IEnumerable<DestinationDto>>(responsePage);

            var response = new ApiResponse<IEnumerable<DestinationDto>>(map).ToPagination((Object)responsePage);

            return response;
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            IEnumerable<Destino> customers = await this.unitOfWork.CustomerRepository.GetAsync(filter.GetProperties());
            // CREATE EXCEL FILE
            using(var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<Destino>(customers, filter.Columns, "Reporte Clientes");
                return new ApiResponse<string>(base64);
            }
            
        }

        public async Task<int> InsertAsync(DestinationInsertDto data)
        {
            var response = await this.unitOfWork.CustomerRepository.InsertAsync(data);

            return response;
        }
    }
}
