using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Scripts;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IScriptService
    {
        Task<ApiResponse<IEnumerable<ScriptDto>>> GetAsync(FilterGrid filter);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
        Task<ApiResponse<string>> ExecuteScriptAsync(ScriptBody body);
    }
}
