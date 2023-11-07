using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface ISicadiRepository
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetSicadiAsync(int idzone);
        Task<int> UpdateAsync(int idzone);
    }
}
