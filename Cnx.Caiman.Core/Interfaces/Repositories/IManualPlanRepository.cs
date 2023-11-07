using Cnx.Caiman.Core.DTOs.ManualPlan;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.PlanManualInfo_Nvo;
using Cnx.Caiman.Core.Entities.QueryEntities.TripsPlan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IManualPlanRepository
    {
        Task<IEnumerable<PlanManual>> GetPlanAsync(int idzone, DateTime date);
        Task<dynamic> GetManualInfoAsync(object properties);
        Task<int> InsertAsync(int idzone, DateTime date, string user);
        Task<int> AuthorizeAsync(ManualPlanUpdateDto model);
        Task<dynamic> DailyCubeAsync(int idzone, string search, int? iddestination);
        Task<TripsPlanAssigment> AcceptAsync(ManualPlanUpdateDto model);
        Task<KeyValuePair<List<ViajeManualSap>, string>> AcceptFileAsync(ManualPlanUpdateDto model);
        Task<int> InsertTripManualAsync(ManualTripDto model);
        Task<int> DeleteAsync(long idtrip);
        Task<int> FileCreateAsync(long plan, string file, string name, string Typeplan);
    }
}
