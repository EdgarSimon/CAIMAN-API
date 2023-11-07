using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.ProductInterface;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IProductInterfaceService
    {
        Task<ApiResponse<IEnumerable<ProductInterfaceDto>>> GetAsync(FilterGrid filter);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
        Task<int> InsertAsync(ProductInterfaceInsertDto parameters);
        Task<int> UpdateAsync(ProductInterfaceInsertDto parameters);
        Task<int> DeleteAsync(string vcSap);
    }
}
