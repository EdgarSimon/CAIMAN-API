using Cnx.Caiman.Core.DTOs.AssigPlan;
using Cnx.Caiman.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IAssigPlanRepository
    {
        Task<IEnumerable<PlanAsignacion>> GetAsync(Object parameters);
        Task<int> UpdateAsync(AssigPlanUpdateDto model);
        Task<int> UpdatestateAsync(AssigPlanstateDto model);
        Task<int> InsertAsync(AssigPlanInsertDto model);
        Task<int> DeleteAsync(int IdPlanAsignacion, string vc20Usuario);
        Task<int> InsertCopyAsync(AssigPlanInsertCopyDto model);
    }
}
