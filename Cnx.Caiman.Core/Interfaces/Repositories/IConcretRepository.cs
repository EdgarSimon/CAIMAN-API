using Cnx.Caiman.Core.DTOs.Concret;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.OrdenCapacity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IConcretRepository
    {
        Task<IEnumerable<Demanda>> GetAsync(Object parameters);
        Task<int> ShowPhotoAsync(int idzone, DateTime date);
        Task<int> UpdateAsync(DemandUpdateDto model);
        Task<int> UpdateSicadiAsync(string origins, string products, DateTime date);
        Task<IEnumerable<KeyValuePair<string, string>>> GetSicadiAsync(SicadiDemandDto model);
        Task<List<CapacidadDeOrden>> OrdenVerifyCapacityAsync(int idzone, DateTime date, int capacity);
    }
}
