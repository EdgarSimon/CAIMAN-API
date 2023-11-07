using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.Entities.Filters;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IGeneralShipperService
    {
        Task<ApiResponse<IEnumerable<GeneralShipperDto>>> GetAsync(FilterGrid filter);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
        Task<int> InsertAsync(GeneralShipperInsertDto data);
        Task<int> DeleteAsync(int id, string username);
        Task<int> UpdateAsync(int IdTransportista, GeneralShipperUpdateDto data);
        ApiResponse<GeneralShipperDto> GetShipperByGeneralShipperAsync(ShipperByGeneralShipperDto data);
        Task<ApiResponse<IEnumerable<GeneralShipperDto>>> GetShipperAvailableAsync(ZoneIntFilter filter);
    }
}