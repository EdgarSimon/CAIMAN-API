using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.DTOs.Shipper;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.Filters;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Interfaces.Services
{

    public interface IShipperService
    {
        Task<ApiResponse<IEnumerable<ShipperDto>>> GetAsync(FilterGrid filter);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
		Task<ApiResponse<IEnumerable<ShipperDto>>> GetByZoneAllAsync(ZoneIntFilter filter, bool isagreement);
        Task<ApiResponse<IEnumerable<ShipperDto>>> GetRestrictionAsync(PaginationQuery filter, int idZone, long tid);
        Task<ApiResponse<IEnumerable<ShipperDto>>> GetRestrictionOneToOneAsync(PaginationQuery filter, int idZone, long tid);
        Task<ApiResponse<IEnumerable<ShipperDto>>> GetRestrictionInvolvedAsync(PaginationQuery filter, int idZone, long tid);
        Task<ApiResponse<IEnumerable<ShipperDto>>> GetRestrictionInvolvedOneToOneAsync(PaginationQuery filter, int idZone, long tid);
        Task InsertRestrictionAsync(ShipperRestrictionDto data);
        Task InsertRestrictionOneToOneAsync(ShipperRestrictionDto data);
        Task<int> InsertAsync(ShipperInsertDto data);
        Task<ApiResponse<Object>> DeleteAsync(string ShipperId, string User);
        Task<ApiResponse<Object>> UpdateAsync(ShipperUpdateDto data);
        Task<ApiResponse<Object>> InsertMonthlyAsync(ShipperInsertMonthlyDto data);
        Task<ApiResponse<Object>> UpdateMonthlyAsync(int idTransportista, ShipperInsertMonthlyDto data);
        Task<ApiResponse<IEnumerable<ShipperDto>>> GetMonthAsync(ZoneIntFilterDto data);
    }
}