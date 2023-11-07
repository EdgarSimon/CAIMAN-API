using Cnx.Caiman.Core.DTOs.ManualPlan;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IManualPlanService
    {
        Task<ApiResponse<List<ManualPlanDto>>> GetPlanAsync(PaginationQuery filter, int idzone, DateTime date);
        Task<ApiResponse<ManualPlanInfoDto>> GetPlanInfoAsync(FilterGrid filter);
        Task<ApiResponse<string>> GetInfoListExportAsync(FilterGrid filter);
        Task<ApiResponse<long>> InsertAsync(int idzone, DateTime date, string user);
        Task AuthorizeAsync(ManualPlanUpdateDto model);
        Task<ApiResponse<ManualTripSapDto>> AcceptAsync(ManualPlanUpdateDto model);
        Task<ApiResponse<CubeDailyAggDto>> CubeDailyAsync(PaginationQuery filter, int idzone, int? iddestination);
        Task InsertTripManualAsync(ManualTripDto model);
        Task DeleteAsync(long idtrip);
    }
}
