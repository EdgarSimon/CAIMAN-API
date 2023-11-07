using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.Filters;
using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface ICediRepository
    {
        Task<IEnumerable<Cedi>> GetAsync(Object parameters);
        Task<int> DeleteAsync(string prmVcSAP, string prmUsuario);
        Task<int> InsertAsync(string prmVcSAP, string prmNombre, string prmUsuario);
        Task<int> UpdateAsync(string prmVcSAP, string prmNombre, string prmUsuario);
    }
}
