using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.CostOverrun;
using Cnx.Caiman.Core.DTOs.Origin;
using Cnx.Caiman.Core.DTOs.Product;
using Cnx.Caiman.Core.Entities;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IRelProductionRepository
    {
        Task<IEnumerable<RelProduccion>> GetAsync(int idOrigin);
        Task<IEnumerable<RelProduccion>> GetValuesOriginAsync(Object parameters);
        Task<int> UpdateCostProductOverrunAsync(CostProductOverrunUpdateDto data);
        Task<IEnumerable<Producto>> GetProductosByZoneAsync(int idOrigin, int idZone, string search);
        Task<int> InsertProductOriginAsync(RelOriginProductInsertDto data);
        Task<int> UpdateProductOriginAsync(RelOriginProductInsertDto data, int idRel);
        Task<int> DeleteProductOriginAsync(int idRel);
    }
}
