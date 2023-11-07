using Cnx.Caiman.Core.DTOs.Agreement;
using Cnx.Caiman.Core.DTOs.Hour;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IAgreementService
    {
        Task<ApiResponse<bool>> InfoAsync(int idzone);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
        Task<ApiResponse<int>> GetTIDAsync(string description);
        Task<ApiResponse<EsqPivPronDto>> FindInfoAsync(FindInfoDto model);
        Task<ApiResponse<AgreementDto>> RestrictionInfoAsync(int idrestriction);
        Task<ApiResponse<IEnumerable<ProfileAgreementDTO>>> ProfileListAsync();
        Task<ApiResponse<IEnumerable<RestrictionTypeDto>>> ByTypeAsync();
        Task<ApiResponse<IEnumerable<FrequencyAgreementDto>>> FrequencyAsync();
        Task<ApiResponse<IEnumerable<AgreementDto>>> GetByDailyPlanAsync(FilterGrid filter);
        Task<ApiResponse<string>> ExportDailyPlanAsync(FilterGrid filter);
        Task<ApiResponse<IEnumerable<AgreementDto>>> ListSearchAsync(FilterGrid filter);
        Task<int> DeleteTransacAsync(long TID);
        Task<int> DeleteAsync(int idagreement);
        Task<int> InsertAsync(AgreementSaveDto agreement);
        Task<int> UpdateAsync(AgreementSaveDto agreement);
        Task<int> UpdateDailyPlanAsync(AgreementDailyPlanDto agreement);
        Task<ApiResponse<IEnumerable<HourDto>>> GetRestrictionAsync(PaginationQuery filter, int idZone, long tid);
        Task<ApiResponse<IEnumerable<HourDto>>> GetRestrictionOneToOneAsync(PaginationQuery filter, int idZone, long tid);

        Task InsertRestrictionAsync(HourRestrictionDto data);
    }
}
