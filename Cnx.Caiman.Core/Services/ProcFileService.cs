using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Factories.ReaderDataFromFileFactory;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Extension;
using ClosedXML.Excel;
using Microsoft.Extensions.Options;

namespace Cnx.Caiman.Core.Services
{
    public class ProcFileService : IProcFileService
    {
        private IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;

        public ProcFileService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.paginationConfiguration = options.Value;
        }

        public async Task<ApiResponse<IEnumerable<LogInterfazDto>>> GetAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            IEnumerable<LogInterfaz> logInterfaces = await this.unitOfWork.ProcExcelRepository.GetAsync(filter.GetProperties());
            var logInterfacesPage = PageList<LogInterfaz>.Create(logInterfaces, filter.Paging.PageNumber, filter.Paging.PageSize);
            var LogsInterfaceDto = this.mapper.Map<IEnumerable<LogInterfazDto>>(logInterfacesPage);
            var response = new ApiResponse<IEnumerable<LogInterfazDto>>(LogsInterfaceDto);
            return response.ToPagination((object)logInterfacesPage);
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            IEnumerable<LogInterfaz> logInterfaces = await this.unitOfWork.ProcExcelRepository.GetAsync(filter.GetProperties());
            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<LogInterfaz>(logInterfaces, filter.Columns, "Reporte Log interface");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<int> ReadAndImportedFileToSql(ProcFileDto procExcel)
        {
            var readerFile = ReaderDataFromFileFactory.GetInstance(procExcel);
            var dataTableReader = readerFile.GetDataAndStoreFromFile();
            return await this.unitOfWork.ProcExcelRepository.UploadDataFromDataTableAsync(dataTableReader.StoreToImportData, dataTableReader.Data);
        }
    }
}
