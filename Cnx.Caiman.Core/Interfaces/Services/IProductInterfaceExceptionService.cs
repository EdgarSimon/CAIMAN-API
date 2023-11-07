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
    public interface IProductInterfaceExceptionService
    {
        Task<ApiResponse<IEnumerable<ProductInterfaceExceptionDto>>> GetAsync(FilterGrid filter);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
        Task<int> InsertAsync(ProductInterfaceExceptionInsertDto parameters);
        Task<int> UpdateAsync(ProductInterfaceExceptionInsertDto parameters);
        Task<int> DeleteAsync(string vcSap);
    }
}
