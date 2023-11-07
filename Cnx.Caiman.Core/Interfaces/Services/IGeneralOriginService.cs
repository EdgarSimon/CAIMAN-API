using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Origin;
using Cnx.Caiman.Core.Entities;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IGeneralOriginService
    {
        Task<ApiResponse<IEnumerable<GeneralOriginDto>>> GetAsync(FilterGrid filter);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
        Task<ApiResponse<IEnumerable<GeneralOriginDto>>> GetAvailableAsync(int zoneId, PaginationQuery filter);
        Task<int> InsertAsync(GeneralOriginInsertDto data);
        Task<ApiResponse<Object>> DeleteAsync(string PrmIdOrigen, string PrmUsuario);
        Task<ApiResponse<Object>> UpdateAsync(int originId, GeneralOriginInsertDto data);
    }
}