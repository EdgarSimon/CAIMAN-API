using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.ProductInterface;
using Cnx.Caiman.Core.Entities;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IProductInterfaceExceptionRepository
    {
        Task<IEnumerable<ProductoInterfazExcepcion>> GetAsync(object parameters);
        Task<int> InsertAsync(ProductInterfaceExceptionInsertDto parameters);
        Task<int> UpdateAsync(ProductInterfaceExceptionInsertDto parameters);
        Task<int> DeleteAsync(string vcSap);
    }
}
