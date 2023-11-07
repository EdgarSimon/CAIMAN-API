using Cnx.Caiman.Core.DTOs.AssigPlan;
using Cnx.Caiman.Core.DTOs.PrevValidation;
using Cemex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IPrevValidationsService
    {
        Task<ApiResponse<List<ValidacionesPreviasListDto>>> GetAsync(int IdPlanAssig, string element);
        Task<ApiResponse<List<KeyValuePair<string, int>>>> GetDvSEAsync(int IdPlanAssig);
        Task<ApiResponse<List<AssigPlanDto>>> GetOTvsDAsync(int IdPlanAssig);
    }
}
