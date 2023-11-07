using Cnx.Caiman.Core.DTOs.AssigPlan;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IAssigPlanService
    {
        Task<ApiResponse<IEnumerable<AssigPlanDto>>> GetAsync(FilterGrid filter);
        Task UpdateAsync(AssigPlanUpdateDto model);
        Task UpdateStateAsync(AssigPlanstateDto model);
        Task InsertAsync(AssigPlanInsertDto model);
        Task DeleteAsync(int IdPlanAsignacion, string vc20Usuario);
        Task InsertCopyAsync(AssigPlanInsertCopyDto model);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
    }
}
