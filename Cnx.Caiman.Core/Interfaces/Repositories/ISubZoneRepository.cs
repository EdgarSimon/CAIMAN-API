using Cnx.Caiman.Core.DTOs.SubZone;
using Cnx.Caiman.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface ISubZoneRepository
    {
        Task<List<SubZona>> GetAsync(int idzone);
        Task<IEnumerable<SubZona>> GetAllByZonaAsync(int idzone);
        Task<int> PutAsync(SubZoneInsertDto model);
        Task<int> PostAsync(SubZoneUpdateDto model);
        Task<int> DeleteAsync(int idsubzone, string user);
        Task<IEnumerable<KeyValuePair<int, string>>> GetByZoneOptionAllAsync(int idzone);
    }
}
