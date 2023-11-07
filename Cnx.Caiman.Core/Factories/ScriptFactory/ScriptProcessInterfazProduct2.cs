using System.Net.Http;
using System.Threading.Tasks;
using Cnx.Caiman.Core.Interfaces.Repositories;

namespace Cnx.Caiman.Core.Factories.ScriptFactory
{
    public class ScriptProcessInterfazProduct2: IScriptReader
    {
        private readonly IScriptRepository scriptRepository;
        public ScriptProcessInterfazProduct2(IScriptRepository scriptRepository)
        {
            this.scriptRepository = scriptRepository;
        }

        public async Task<string> GetResponseStoreProcedure(object parameters, StreamContent file = null)
        {
            await this.scriptRepository.ProcessInterfaceProduct2Async(parameters);
            return "";
        }

        public string GetResponseType()
        {
            return "";
        }
    }
}