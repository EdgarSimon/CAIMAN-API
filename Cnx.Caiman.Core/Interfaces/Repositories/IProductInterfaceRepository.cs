using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.ProductInterface;
using Cnx.Caiman.Core.Entities;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IProductInterfaceRepository
    {
        Task<IEnumerable<ProductoInterfaz>> GetAsync(object parameters);
        Task<int> InsertAsync(ProductInterfaceInsertDto parameters);
        Task<int> UpdateAsync(ProductInterfaceInsertDto parameters);
        Task<int> DeleteAsync(string vcsap);
    }
}
