using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.ValidacionesPrevias;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IPrevValidationsRepository
    {
        Task<IEnumerable<ValidacionesPreviasListar>> GetAsync(int IdPlanAssig, string element);
        Task<List<KeyValuePair<string, int>>> GetDvSEAsync(int IdPlanAssig);
        Task<List<PlanAsignacion>> GetOTvsDAsync(int IdPlanAssig);
    }
}
