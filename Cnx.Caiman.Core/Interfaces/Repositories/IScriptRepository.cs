using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.Scripts;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IScriptRepository
    {
        Task<IEnumerable<Script>> GetAsync(Object parameters);
        Task<List<KeyValuePair<string,IEnumerable<dynamic>>>> GetReportOverrunCost(Object parameters);
        Task<List<KeyValuePair<string, IEnumerable<dynamic>>>> GetAndDeleteDestinationsManualRates(Object parameters, bool res = false);
        Task<dynamic> UpdateMonthlyPlan(Object parameters);
        Task<List<KeyValuePair<string, IEnumerable<dynamic>>>> GetCuboTacticianPlan(Object parameters);
        Task<List<KeyValuePair<string, IEnumerable<dynamic>>>> InsertProductAsync(Object parameters);
        Task<int> ExecuteUpdateCVP(DataTable dataTable);
        Task<dynamic> ProcessInterfaceProduct2Async(Object parameters);
    }
}
