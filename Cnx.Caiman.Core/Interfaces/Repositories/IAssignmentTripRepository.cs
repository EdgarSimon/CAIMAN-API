using Cnx.Caiman.Core.DTOs.AssignmentTrip;
using Cnx.Caiman.Core.DTOs.ManualPlan;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.AsignacionViajes;
using Cnx.Caiman.Core.Entities.QueryEntities.TripsPlan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IAssignmentTripRepository
    {
        Task DeleteAsync(int Idtrip, string user);
        Task<dynamic> ListTripAsync(Object parameters);
        Task<dynamic> getAceptTripListAsyc(int resultTrip);
        Task<ViajeListarCostosResult> getCostsAsyc(TripListCostsParamsDto model);
        Task<List<PlanAsignacionEnviarASicadiResult>> PlanSendSicadiAsync(AceptAssignPlanDto model);
        Task<IEnumerable<KeyValuePair<int, string>>> getPlanAssigListAsyc(int idzone, DateTime date);
        Task<TripsPlanAssigment> TripsSapAsync(AceptAssignPlanDto model);
        Task<KeyValuePair<List<ViajeSapFile>, string>> TripsSapFileAsync(AceptAssignPlanDto model);
        Task<int> AceptAssignPlanAsync(AceptAssignPlanDto model);
        Task ReevaluateTripAsync(int result);
        Task<string> SapFileJsonAsync();

        //metodos de edicion
        Task<dynamic> TripEditListAsync(Object parameters);
        Task<IEnumerable<KeyValuePair<int, string>>> getTripCarrierListAsync(int idresult);
        Task<IEnumerable<KeyValuePair<int, string>>> getTripOriginListAsync(int idresult);
        Task UpdateTripAsync(UpdateTripDto model);

        //factibildiad
        Task<dynamic> ListsFactibilityAsync(int idzone, int validation, string date, int idresult);
        Task<dynamic> ListsPriorityAsync(int idzone, int idresult, int entity);
        Task<dynamic> ListFeasibilityAgreementAsync(Object parameters);

        //Nuevo viaje
        Task<IEnumerable<KeyValuePair<int, string>>> getFilterListElementAsync(FilterListElementDto model);
        Task<int> InsertPlanTripAsync(InsertPlanTripDto model);
        Task<int> UpdateStatusPlan(int AsigmmentId, int IdStatus, string PlanType,string MensajeAzure);
    }
}
