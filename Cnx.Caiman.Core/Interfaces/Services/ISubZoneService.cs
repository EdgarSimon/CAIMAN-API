using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.DTOs.SubZone;
using Cnx.Caiman.Core.Entities.Filters;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface ISubZoneService
    {
        Task<ApiResponse<IEnumerable<SubZoneDto>>> GetAsync(PaginationQuery filter, int idzone);
        Task<ApiResponse<IEnumerable<SubZoneDto>>> GetAllByZonaAsync(ZoneIntFilter filter);
        Task<ApiResponse<IEnumerable<SubZoneDto>>> GetByZoneOptionAllAsync(ZoneIntFilter filter);
        Task<int> PutAsync(SubZoneInsertDto model);
        Task<int> PostAsync(SubZoneUpdateDto model);
        Task<int> DeleteAsync(int idsubzone, string user);
    }
}
