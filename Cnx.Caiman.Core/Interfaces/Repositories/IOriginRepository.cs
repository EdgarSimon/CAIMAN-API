using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Origin;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.Origen;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IOriginRepository
    {
        Task<IEnumerable<OrigenQuery>> GetAsync(Object parameters);
        Task<IEnumerable<Origen>> GetAllAsync(int idZone);
        Task<IEnumerable<Origen>> GetOriginNewDistanceAsync(int idorigin);
        Task<IEnumerable<Origen>> GetByZoneAllAsync(int idZona, bool isagreement, string search);
        Task<IEnumerable<Origen>> GetRestrictionAsync(int idZona, long tid, string phrase);
        Task<IEnumerable<Origen>> GetRestrictionOneToOneAsync(int idZona, long tid);
        Task<IEnumerable<Origen>> GetRestrictionInvolvedAsync(int idZona, long tid);
        Task<IEnumerable<Origen>> GetRestrictionInvolvedOneToOneAsync(int idZona, long tid);
        Task<int> DeleteAsync(string id, string user);
        Task<int> InsertAsync(OriginInsertDto data);
        Task<int> InsertRestrictionOneToOneAsync(int tid, string value255);
        Task<int> InsertRestrictionAsync(OriginRestrictionDto model);
        Task<int> UpdateAsync(int id, OriginInsertDto data);
    }
}