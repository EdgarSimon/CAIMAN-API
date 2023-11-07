using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.DTOs.Shipper;
using Cnx.Caiman.Core.Entities;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IShipperRepository
    {
        Task<IEnumerable<Transportista>> GetAsync(Object parameters);
        Task<IEnumerable<Transportista>> GetMonthAsync(int idZona, DateTime date);
        Task<IEnumerable<Transportista>> GetRelationMonthAsync(int idZona, DateTime date);
        Task<IEnumerable<Transportista>> GetValuesAsync(int idZona);
        Task<IEnumerable<Transportista>> GetRelationMonthlyAsync(int idZona, DateTime date);
        Task<IEnumerable<Transportista>> GetOrdersByTripAsync(int idZona);
        Task<IEnumerable<Transportista>> GetByZoneAllAsync(int idZona, bool isagreement, string word);
        Task<IEnumerable<Transportista>> GetRestrictionAsync(int idZona, long tid, string phrase);
        Task<IEnumerable<Transportista>> GetRestrictionOneToOneAsync(int idZona, long tid);
        Task<IEnumerable<Transportista>> GetRestrictionInvolvedAsync(int idZona, long tid);
        Task<IEnumerable<Transportista>> GetRestrictionInvolvedOneToOneAsync(int idZona, long tid);
        Task<int> InsertAsync(ShipperInsertDto data);
        Task<int> InsertMonthlyAsync(ShipperInsertMonthlyDto data);
        Task<int> InsertRestrictionAsync(ShipperRestrictionDto model);
        Task<int> InsertRestrictionOneToOneAsync(int tid, string value255);
        Task<int> UpdateAsync(ShipperUpdateDto data);
        Task<int> DeleteAsync(string IdShipper, string user);
        Task<int> UpdateMonthlyAsync(int idTransportista, ShipperInsertMonthlyDto data);
        
    }
}