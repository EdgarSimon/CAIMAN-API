using System.Collections.Generic;
using System.Net.Http;

namespace Cemex.Core.Entities
{
    public enum ScriptList
    {
        ScriptOverrunCost = 1,
        UpdateMonthPlan = 2,
        ProcessInterfaceProduct = 3,
        UpdateMonthPlanCaiman = 4,
        PlanMonthlyTactician = 5,
        InsertProductOrigin = 6,
        DeleteManualRates = 7,
        UpdateCVP = 8,
    }
    public class ScriptBody
    {
        public ScriptList idSp { get; set; }
        public List<KeyValuePair<string, string>> Params 
        { 
            get; 
            set;
        }
        public StreamContent streamContent { get; set; }
    }
}