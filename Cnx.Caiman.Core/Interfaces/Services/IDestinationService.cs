using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Destination;
using Cnx.Caiman.Core.DTOs.Product;
using Cnx.Caiman.Core.Entities.Filters;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IDestinationService
    {
        Task<ApiResponse<IEnumerable<DestinationDto>>> GetAsync(FilterGrid filter);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
        Task<ApiResponse<IEnumerable<DestinationWithoutDistanceDto>>> GetWithoutDistanceAsync(ZoneIntFilter filter);
        Task<ApiResponse<IEnumerable<DestinationDto>>> GetByZoneAllAsync(FilterZone filter, bool isagreement, string idFiltrados);
        Task<ApiResponse<IEnumerable<RelUsoDto>>> GetDestinationProductsListAsync(PaginationQuery filter, int idDestination);
        Task<ApiResponse<IEnumerable<ProductDto>>> GetProductsByZoneAsync(PaginationQuery filter, int idZone, int idDestination);
        Task<int> StoreRelationProductAsync(RelDestinationProductInsertDto data);
        Task<int> UpdateRelationProductAsync(RelDestinationProductInsertDto data, int idRelUse);
        Task<int> DeleteRelationProductAsync(int idRelUse);
        Task<ApiResponse<IEnumerable<RelDestinoInventarioDto>>> GetRelationDestinationInventoryAsync(PaginationQuery filter, int idDestination);
        Task<int> InsertInventoryProductAsync(RelInventoryInsertProductDto data, int idDestination);
        Task<int> UpdateInventoryProductAsync(RelInventoryInsertProductDto data, int idDestination, int idRelation);
        Task<ApiResponse<IEnumerable<DestinationDto>>> GetDestinationClientListAsync(PaginationQuery filter, int idZone);
        Task<ApiResponse<IEnumerable<DestinationDto>>> GetRestrictionAsync(PaginationQuery filter, int idZone, long tid);
        Task<ApiResponse<IEnumerable<DestinationDto>>> GetRestrictionOneToOneAsync(PaginationQuery filter, int idZone, long tid);
        Task<ApiResponse<IEnumerable<DestinationDto>>> GetRestrictionInvolvedAsync(PaginationQuery filter, int idZone, long tid);
        Task<ApiResponse<IEnumerable<DestinationDto>>> GetRestrictionInvolvedOneToOneAsync(PaginationQuery filter, int idZone, long tid);
        Task<ApiResponse<IEnumerable<DestinationDto>>> getDestinationDistanceListAsync(PaginationQuery filter, int idZone);
        Task InsertRestrictionAsync(DestinationRestrictionDto data);
        Task InsertRestrictionOneToOneAsync(DestinationRestrictionDto data);
        Task<int> InsertAsync(DestinationInsertDto data);        
        Task<int> DeleteAsync(int idDestination, string username);
        Task<int> DeleteRelationInventoryAsync(int idDestination, int idRelation);
        Task<int> UpdateAsync(int idDestination, DestinationInsertDto data);
    }
}