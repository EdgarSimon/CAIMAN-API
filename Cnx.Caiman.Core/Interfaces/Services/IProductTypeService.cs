using Cnx.Caiman.Core.DTOs.ProductType;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IProductTypeService
    {
        Task<ApiResponse<IEnumerable<ProductTypeDto>>> GetAsync(int idZona, PaginationQuery filter);
        Task UpdateAsync(ProductTypeUpdateDto model);
        Task InsertAsync(ProductTypeInsertDto model);
        Task DeleteAsync(int idTipoProducto, string Vc20Usuario);
    }
}
