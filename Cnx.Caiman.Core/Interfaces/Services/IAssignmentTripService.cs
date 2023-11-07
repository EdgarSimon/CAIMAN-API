using Cnx.Caiman.Core.DTOs.AssignmentTrip;
using Cnx.Caiman.Core.DTOs.Feasibility;
using Cnx.Caiman.Core.DTOs.FeasibilityAgreement;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IAssignmentTripService
    {
        Task DeleteAsync(int idTrip, string Vc20Usuario);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
        Task<ApiResponse<AceptTripListDto>> getAceptTripListAsyc(int resultTrip);
        Task<ApiResponse<IEnumerable<TripListDto>>> ListTripAsync(FilterGrid filter);
        Task<ApiResponse<TripListCostsDto>> getCostsAsyc(TripListCostsParamsDto model);
        Task<ApiResponse<IEnumerable<KeyValuePair<int, string>>>> getPlanAssigListAsyc(PaginationQuery filter, int idZone, DateTime date);
        Task AceptAssignPlanAsync(AceptAssignPlanDto model);

        //EDICION
        Task<ApiResponse<IEnumerable<ListEditTripDto>>> TripEditListAsync(FilterGrid filter);
        Task<ApiResponse<string>> TripEditListExportAsync(FilterGrid filter);
        Task<ApiResponse<IEnumerable<KeyValuePair<int, string>>>> getTripCarrierListAsync(int idresult);
        Task<ApiResponse<IEnumerable<KeyValuePair<int, string>>>> getTripOriginListAsync(int idresult);
        Task UpdateTripAsync(UpdateTripDto model);

        //FACTIBILIDAD
        Task<ApiResponse<FeasibilityDto>> getFeasibilityAsync(int idzone, string date, int idresult);

        //FACTIBILIDAD CONVENIO
        Task<ApiResponse<FeasibilityAgreementDto>> getFeasibilityAgreementAsync(int idzone, string date, int idresult);
        Task<ApiResponse<IEnumerable<RestrictionListUnfulfilledDto>>> ListFeasibilityAgreementAsync(FilterGrid filter);
        Task<ApiResponse<string>> FeasibilityAgreementExportAsync(FilterGrid filter);

        //REEVALUAR
        Task ReevaluateTripAsync(ReevaluateDto model);

        //NUEVO VIAJE
        Task<ApiResponse<IEnumerable<KeyValuePair<int, string>>>> getFilterListElementAsync(FilterListElementDto filter);
        Task<ApiResponse<int>> InsertPlanTripAsync(InsertPlanTripDto model);
    }
}
