using System.Net.Http;
using System.Threading.Tasks;
using Cnx.Caiman.Core.Interfaces.Repositories;

namespace Cnx.Caiman.Core.Factories.ScriptFactory
{
    public class ScriptUpdateMonthlyPlan : IScriptReader
    {
        private readonly IScriptRepository scriptRepository;
        public ScriptUpdateMonthlyPlan(IScriptRepository scriptRepository)
        {
            this.scriptRepository = scriptRepository;
        }
        
        public async Task<string> GetResponseStoreProcedure(object parameters, StreamContent file = null)
        {
            await this.scriptRepository.UpdateMonthlyPlan(parameters);
            return "";
        }

        public string GetResponseType()
        {
            return "";
        }
    }
}