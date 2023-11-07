using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Origin;
using Cnx.Caiman.Core.Entities.Filters;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IOriginService
    {
        Task<ApiResponse<IEnumerable<OriginQueryDto>>> GetAsync(FilterGrid filter);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
        Task<ApiResponse<IEnumerable<OriginDto>>> GetByZoneAllAsync(FilterZone filter, bool isagreement, string idFiltrados);
        Task<ApiResponse<IEnumerable<OriginDto>>> GetRestrictionAsync(PaginationQuery filter, int idZone, long tid);
        Task<ApiResponse<IEnumerable<OriginDto>>> GetRestrictionOneToOneAsync(PaginationQuery filter, int idZone, long tid);
        Task<ApiResponse<IEnumerable<OriginDto>>> GetRestrictionInvolvedAsync(PaginationQuery filter, int idZone, long tid);
        Task<ApiResponse<IEnumerable<OriginDto>>> GetRestrictionInvolvedOneToOneAsync(PaginationQuery filter, int idZone, long tid);
        Task<ApiResponse<IEnumerable<OriginDistanceDto>>> GetOriginNewDistanceAsync(PaginationQuery filter, int idorigin);
        Task<int> InsertAsync(OriginInsertDto data);
        Task InsertRestrictionAsync(OriginRestrictionDto data);
        Task InsertRestrictionOneToOneAsync(OriginRestrictionDto data);
        Task<ApiResponse<Object>> DeleteAsync(string idOrigin, string username);
        Task<ApiResponse<Object>> UpdateAsync(int idOrigin, OriginInsertDto data);
        Task<ApiResponse<IEnumerable<OriginDto>>> GetAllAsyn(FilterZone filter);
    }
}