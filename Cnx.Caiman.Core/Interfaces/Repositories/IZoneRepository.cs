using System;
using Cnx.Caiman.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Zone;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IZoneRepository
    {
        Task<IEnumerable<Zona>> ListAsync(Object parameters);
        Task<Zona> ListProfileZoneAsync(int iduser, int idzone);
        Task<List<Zona>> ProfileNameAsync(int idzone);
        Task<List<Medicion>> MeasuringListAsync();
        Task<int> InsertAsync(ZoneInsertDto zoneModel);
        Task<int> UpdateAsync(int idZona, ZoneInsertDto zoneModel);
        Task<int> DeleteAsync(int idzone);
        Task<List<Zona>> ListByUserAsync(int iduser);
    }
}
