using System.Net.Http;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Factories.ScriptFactory
{
    public interface IScriptReader
    {
         Task<string> GetResponseStoreProcedure(object parameters, StreamContent file = null);
         string GetResponseType();
    }
}