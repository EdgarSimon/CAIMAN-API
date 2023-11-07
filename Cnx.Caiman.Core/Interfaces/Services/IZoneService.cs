using System;
using Cnx.Caiman.Core.DTOs.Zone;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.Entities;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IZoneService
    {
        Task<ApiResponse<IEnumerable<MeasurementDto>>> MeasuringListAsync();
        Task<ApiResponse<IEnumerable<ZoneDto>>> ProfileNameAsync(PaginationQuery filter, int idzone);
        Task<ApiResponse<IEnumerable<ZoneDto>>> ListAsync(FilterGrid filter);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
        Task<ApiResponse<ZoneDto>> ListProfileZoneAsync(int iduser, int idzone);
        Task<int> InsertAsync(ZoneInsertDto zoneModel);
        Task<int> UpdateAsync(int idZona, ZoneInsertDto zoneModel);
        Task<int> DeleteAsync(int idzone);
        Task<ApiResponse<List<ZoneDto>>> ListByUserAsync(int iduser);
    }
}