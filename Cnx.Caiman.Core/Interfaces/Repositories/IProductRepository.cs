using Cnx.Caiman.Core.DTOs.Product;
using Cnx.Caiman.Core.Entities;
using Cemex.Core.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Producto>> GetByZoneAllAsync(int idZona, bool isagreement, string search);
        Task<IEnumerable<Producto>> GetRestrictionAsync(int idZona, long tid, string search);
        Task<dynamic> GetProductDestinationByIdAsync(int idDestination, int pageNumber, int pageSize);
        Task<IEnumerable<Producto>> GetRestrictionOneToOneAsync(int idZona, long tid);
        Task<IEnumerable<Producto>> GetRestrictionInvolvedAsync(int idZona, long tid);
        Task<IEnumerable<Producto>> GetRestrictionInvolvedOneToOneAsync(int idZona, long tid);
        Task<int> InsertRestrictionOneToOneAsync(int tid, string value255);
        Task<int> InsertRestrictionAsync(ProductRestrictionDto model);
        Task<IEnumerable<Producto>> GetProductsByOriginAsync(int idOrigin);
        Task<IEnumerable<Producto>> GetAsync(Object properties);
        Task<IEnumerable<TipoProducto>> GetTypesProductsAsync(int idZona, bool? aplyAll);
        Task<int> UpdateAsync(int idProduct, ProductInsertDto data);
        Task<int> DeleteAsync(string idProduct, string user);
        Task<int> InsertAsync(ProductInsertDto data);
        Task<int> InsertShortAsync(ProductShortInsertDto data);
        Task<int> InsertMonthlyAsync(ProductInsertDto data);
        Task<int> UpdateRelationMonthlyAsync(int idProduct, ProductoRelationMonthlyUpdateDto data);
        Task<dynamic> GetProductDistanceByIdAsync(int idDestination, PaginationQuery filter);
    }
}
