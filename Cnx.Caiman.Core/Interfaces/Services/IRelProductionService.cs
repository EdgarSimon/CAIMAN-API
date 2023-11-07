using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Distance;
using Cnx.Caiman.Core.DTOs.Origin;
using Cnx.Caiman.Core.DTOs.Product;
using Cnx.Caiman.Core.Entities;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IRelProductionService
    {
        Task<ApiResponse<IEnumerable<RelProductionDto>>> GetAsync(int idOrigin, PaginationQuery filter);
        Task<ApiResponse<IEnumerable<RelProductionDto>>> GetValuesOriginAsync(FilterGrid filter);
        Task<ApiResponse<string>> GetValuesOriginExportAsync(FilterGrid filter);
        Task<int> UpdateCostProductOverrunAsync(CostProductOverrunUpdateDto data);
        Task<ApiResponse<IEnumerable<ProductDto>>> GetProductosByZoneAsync(PaginationQuery filter, int idOrigin, int idZone);
        Task<int> InsertProductOriginAsync(RelOriginProductInsertDto data);
        Task<int> UpdateProductOriginAsync(RelOriginProductInsertDto data, int idRel);
        Task<int> DeleteProductOriginAsync(int idRel);
    }
}
