using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Cnx.Caiman.Core.Entities.QueryEntities.Scripts;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Entities;
using Cemex.Core.Extension;
using ClosedXML.Excel;

namespace Cnx.Caiman.Core.Factories.ScriptFactory
{
    public class ScriptOverrunCostReader : IScriptReader
    {
        private readonly IScriptRepository scriptRepository;
        public ScriptOverrunCostReader(IScriptRepository scriptRepository)
        {
            this.scriptRepository = scriptRepository;    
        }
        
        public async Task<string> GetResponseStoreProcedure(object parameters, StreamContent file = null)
        {
            var report = await this.scriptRepository.GetReportOverrunCost(parameters);
            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromStoreQuery(report);
                return base64;
            }
        }

        public string GetResponseType()
        {
            return "base64";
        }
    }
}