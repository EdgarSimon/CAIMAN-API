using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Entities;
using Cemex.Core.Exceptions;

namespace Cnx.Caiman.Core.Factories.ScriptFactory
{
    public class ScriptFactory
    {
        public static IScriptReader GetInstance(ScriptList idScript, IScriptRepository scriptRepository) 
        {
            switch (idScript)
            {
                case ScriptList.ScriptOverrunCost:
                    return new ScriptOverrunCostReader(scriptRepository);
                case ScriptList.UpdateMonthPlan:
                    return new ScriptUpdateMonthlyPlan(scriptRepository);
                case ScriptList.DeleteManualRates:
                    return new ScriptDeleteManualRates(scriptRepository);
                case ScriptList.UpdateCVP:
                    return new ScriptExecuteUpdateCVP(scriptRepository);
                case ScriptList.ProcessInterfaceProduct:
                    return new ScriptProcessInterfazProduct2(scriptRepository);
                case ScriptList.InsertProductOrigin:
                    return new ScriptInserProductAsync(scriptRepository);
                case ScriptList.PlanMonthlyTactician:
                    return new ScriptCuboTactician(scriptRepository);
                default:
                    throw new BusinessException("UnknownScript");
            }
        }
    }
}