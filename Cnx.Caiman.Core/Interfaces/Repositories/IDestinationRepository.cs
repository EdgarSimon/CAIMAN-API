using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Destination;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.Destino;
using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IDestinationRepository
    {
        Task<IEnumerable<DestinoQuery>> GetAsync(Object parameters);
        Task<IEnumerable<Destino>> GetWithoutDistanceAsync(int idZone);
        Task<int> DeleteAsync(int id, string user);
        Task<int> InsertAsync(DestinationInsertDto data);
        Task<int> InsertRestrictionAsync(DestinationRestrictionDto model);
        Task<int> InsertRestrictionOneToOneAsync(int tid, string value255);
        Task<int> UpdateAsync(int idDestino, DestinationInsertDto data);
        Task<IEnumerable<Destino>> GetByZoneAllAsync(int idZona, bool isagreement, string word);
        Task<IEnumerable<RelUso>> GetDestinationProductsListAsync(int idDestination);
        Task<IEnumerable<Producto>> GetProductsByZoneAsync(int idZone, int idDestination, string search);
        Task<int> StoreRelationProductAsync(RelDestinationProductInsertDto data);
        Task<int> UpdateRelationProductAsync(RelDestinationProductInsertDto data, int idRelUse);
        Task<int> DeleteRelationProductAsync(int idRelUse);
        Task<IEnumerable<RelDestinoInventario>> GetRelationDestinationInventoryAsync(int idDestination);
        Task<int> InsertInventoryProductAsync(RelInventoryInsertProductDto data, int idDestination);
        Task<int> UpdateInventoryProductAsync(RelInventoryInsertProductDto data, int idDestination, int idRelation);
        Task<IEnumerable<Destino>> GetRestrictionInvolvedAsync(int idZona, long tid);
        Task<IEnumerable<Destino>> GetRestrictionInvolvedOneToOneAsync(int idZona, long tid);
        Task<KeyValuePair<List<Destino>, int>> GetRestrictionAsync(int idZona, long tid, int pageNumber, int pageSize, string search);
        Task<KeyValuePair<List<Destino>, int>> GetRestrictionOneToOneAsync(int idZona, long tid, int pageNumber, int pageSize, string search);
        Task<int> DeleteRelationInventoryAsync(int idDestination, int idRelation);
        Task<IEnumerable<Destino>> GetDestinationClientListAsync(int idZone);
        Task<IEnumerable<Destino>> getDestinationDistanceListAsync(PaginationQuery filter, int idZone);
    }
}