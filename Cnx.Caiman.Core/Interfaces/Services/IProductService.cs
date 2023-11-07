using Cnx.Caiman.Core.DTOs.Product;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.Filters;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<ApiResponse<IEnumerable<ProductDto>>> GetByZoneAllAsync(FilterZone filter, bool isagreement, string idFiltrados);
        Task<ApiResponse<IEnumerable<ProductDto>>> GetRestrictionAsync(PaginationQuery filter, int idZone, long tid);
        Task<ApiResponse<IEnumerable<ProductDto>>> GetRestrictionOneToOneAsync(PaginationQuery filter, int idZone, long tid);
        Task<ApiResponse<IEnumerable<ProductDto>>> GetRestrictionInvolvedAsync(PaginationQuery filter, int idZone, long tid);
        Task<ApiResponse<IEnumerable<ProductDto>>> GetProductDestinationByIdAsync(int idDestination, PaginationQuery filter);
        Task<ApiResponse<IEnumerable<ProductDto>>> GetProductDistanceByIdAsync(int idDestination, PaginationQuery filter);
        Task<ApiResponse<IEnumerable<ProductDto>>> GetRestrictionInvolvedOneToOneAsync(PaginationQuery filter, int idZone, long tid);
        Task InsertRestrictionAsync(ProductRestrictionDto data);
        Task InsertRestrictionOneToOneAsync(ProductRestrictionDto data);
        Task<ApiResponse<IEnumerable<ProductDto>>> GetAsync(FilterGrid filter);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
        Task<ApiResponse<IEnumerable<TypeProductDto>>> GetTypesProductsAsync(int idZone, bool? aplyAll);
        Task<ApiResponse<IEnumerable<ProductDto>>> GetProductsByOriginAsync(int idOrigin,  PaginationQuery filter);
        Task<int> UpdateAsync(int idProduct, ProductInsertDto data);
        Task<int> DeleteAsync(string idProduct, string user);
        Task<int> InsertAsync(ProductInsertDto data);
        Task<int> InsertShortAsync(ProductShortInsertDto data);
        Task<int> InsertMonthlyAsync(ProductInsertDto data);
        Task<int> UpdateRelationMonthlyAsync(int idProduct, ProductoRelationMonthlyUpdateDto data);
        
    }
}
