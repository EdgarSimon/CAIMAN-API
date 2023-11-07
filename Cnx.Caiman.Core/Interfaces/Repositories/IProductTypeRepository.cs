using Cnx.Caiman.Core.DTOs.ProductType;
using Cnx.Caiman.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<TipoProducto>> GetAsync(int idZone);
        Task<int> UpdateAsync(ProductTypeUpdateDto model);
        Task<int> InsertAsync(ProductTypeInsertDto model);
        Task<int> DeleteAsync(int idTipoProducto, string Vc20Usuario);
    }
}
