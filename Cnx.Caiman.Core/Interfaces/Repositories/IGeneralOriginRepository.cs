using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Origin;
using Cnx.Caiman.Core.Entities;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IGeneralOriginRepository
    {
        Task<IEnumerable<OrigenGeneral>> GetAsync(Object parameters);
        Task<IEnumerable<OrigenGeneral>> GetAvailableAsync(int idZone);
        Task<int> InsertAsync(GeneralOriginInsertDto data);
        Task<int> DeleteAsync(string PrmIdOrigen, string PrmUsuario);
        Task<int> UpdateAsync(int originId, GeneralOriginInsertDto data);

    }
}