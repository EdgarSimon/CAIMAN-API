using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cnx.Caiman.Core.DTOs.Scripts;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Factories.ScriptFactory;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Extension;
using ClosedXML.Excel;
using Microsoft.Extensions.Options;

namespace Cnx.Caiman.Core.Services
{
    public class ScriptService : IScriptService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;
        public ScriptService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.paginationConfiguration = options.Value;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<string>> ExecuteScriptAsync(ScriptBody body)
        {
            var instanceScript = ScriptFactory.GetInstance(body.idSp, this.unitOfWork.ScriptRepository);
            var file = body.GetFile();
            var scriptReponse = await instanceScript.GetResponseStoreProcedure(body.GetProperties(), file);
            return new ApiResponse<string>(scriptReponse, instanceScript.GetResponseType());

        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            IEnumerable<Script> scripts = await this.unitOfWork.ScriptRepository.GetAsync(filter.GetProperties());
            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<Script>(scripts, filter.Columns, "Reporte Scripts");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<ApiResponse<IEnumerable<ScriptDto>>> GetAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            IEnumerable<Script> scripts = await this.unitOfWork.ScriptRepository.GetAsync(filter.GetProperties());
            var scriptsPage = PageList<Script>.Create(scripts, filter.Paging.PageNumber, filter.Paging.PageSize);
            var map = this.mapper.Map<IEnumerable<ScriptDto>>(scriptsPage);
            return new ApiResponse<IEnumerable<ScriptDto>>(map).ToPagination(scriptsPage);
        }
    }
}
