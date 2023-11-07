using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Microsoft.AspNetCore.Http;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IProcFileService
    {
        Task<int> ReadAndImportedFileToSql(ProcFileDto procExcelDto);
        Task<ApiResponse<IEnumerable<LogInterfazDto>>> GetAsync(FilterGrid filter);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
    }
}
