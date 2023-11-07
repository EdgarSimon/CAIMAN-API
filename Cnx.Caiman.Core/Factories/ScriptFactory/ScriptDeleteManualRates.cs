using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Extension;
using ClosedXML.Excel;

namespace Cnx.Caiman.Core.Factories.ScriptFactory
{
    public class ScriptDeleteManualRates : IScriptReader
    {
        private string responseType;
        private readonly IScriptRepository scriptRepository;
        public ScriptDeleteManualRates(IScriptRepository scriptRepository)
        {
            this.scriptRepository = scriptRepository;    
        }
        public async Task<string> GetResponseStoreProcedure(object parameters, StreamContent file = null)
        {
            var value = this.GetValueObject(parameters, "bBorrar");
            if(value == "true" || value == "1") {
                await this.scriptRepository.GetAndDeleteDestinationsManualRates(parameters, true);
                this.responseType = "";
                return "";
            }
            else {
                var report = await this.scriptRepository.GetAndDeleteDestinationsManualRates(parameters, false);
                using (var workbook = new XLWorkbook())
                {
                    string base64 = workbook.GetExcelFromStoreQuery(report);
                    this.responseType = "base64";
                    return base64;
                }
            }
        }

        private string GetValueObject(object parameters, string keyvalue)
        {
            var _object = (IDictionary<string,object>)parameters;
            string val = (string)_object[keyvalue];
            return val;

            // var value = (dataValue != null) ?  dataValue.GetValue(parameters, null) : "";
            // var response = (dataValue != null) ? dataValue.ToString() : "";

            // return response;
        }

        public string GetResponseType()
        {
            return this.responseType;
        }
    }
}