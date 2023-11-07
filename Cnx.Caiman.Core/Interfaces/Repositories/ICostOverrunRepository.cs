using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.CostOverrun;
using Cnx.Caiman.Core.Entities;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface ICostOverrunRepository
    {
        Task<IEnumerable<TipoSobreconsumo>> GetTypesOverrunAsync();

    }
}
