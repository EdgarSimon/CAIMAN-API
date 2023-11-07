using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Distance;
using Cnx.Caiman.Core.Entities.Filters;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IDistanceService
    {
        Task<ApiResponse<IEnumerable<TariffDestinationProductDto>>> TariffConsultOriginProductAsync(FilterGrid filter);
        Task<ApiResponse<string>> TariffConsultOriginProductExportAsync(FilterGrid filter);
        Task<ApiResponse<IEnumerable<TariffDestinationProductDto>>> TariffConsultDestinationProductAsync(FilterGrid filter);
        Task<ApiResponse<string>> TariffConsultDestinationProductExportAsync(FilterGrid filter);
        Task<int> UpdateAsync(DistanceUpdateDto data);
    }
}