using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.Entities;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IGeneralShipperRepository
    {
        Task<dynamic> GetAsync(Object parameters);
        Task<int> InsertAsync(GeneralShipperInsertDto data);
        Task<int> DeleteAsync(int id, string username);
        Task<int> UpdateAsync(int idTransportista, GeneralShipperUpdateDto data);
        TransportistaGeneral GetShipperByGeneralShipperAsync(ShipperByGeneralShipperDto data);
        Task<IEnumerable<TransportistaGeneral>> GetShipperAvailableAsync(int idZone);
    }
}