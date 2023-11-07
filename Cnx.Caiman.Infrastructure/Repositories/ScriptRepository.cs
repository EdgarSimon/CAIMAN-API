using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;
using Dapper;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class ScriptRepository: IScriptRepository
    {
        private readonly IDbContext dbContext;

        public ScriptRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Script>> GetAsync(Object parameters)
        {
            using (var multiple = this.dbContext.QueryMultiple("[dbo].[EVO_SpScriptList]", parameters: parameters))
            {
              var scripts = await multiple.ReadAsync<Script>();
              var ScriptsParams = await multiple.ReadAsync<ScriptsParams>();
              foreach (var param in ScriptsParams)
              {
                var script = scripts.FirstOrDefault(_script => _script.IdScript == param.IdScript);
                if(script != null)
                  script.Params.Add(param);
              }
              return scripts;
            }
        }

        public async Task<List<KeyValuePair<string,IEnumerable<dynamic>>>> GetReportOverrunCost(Object parameters)
        {
            var response = await this.dbContext.QueryAsync<dynamic>("[dbo].[EVO_SpScriptReporteSobrecostos]", parameters);
            var reporteSobrecostos = new KeyValuePair<string, IEnumerable<dynamic>>("Reporte sobrecostos", response);
            return new List<KeyValuePair<string, IEnumerable<dynamic>>>(){reporteSobrecostos};
        }

        public async Task<List<KeyValuePair<string, IEnumerable<dynamic>>>> GetAndDeleteDestinationsManualRates(Object parameters, bool bBorrar = false)
        {
            if(bBorrar)
            {
                await this.dbContext.QueryAsync<dynamic>("[dbo].[Evo_EliminarTarifaManual]", parameters);
                return new List<KeyValuePair<string, IEnumerable<dynamic>>>();
            }
            else
            {
                using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_EliminarTarifaManual]", parameters: parameters))
                {
                    var eficiencia = await multiple.ReadAsync<dynamic>();
                    var cuboAnterio = await multiple.ReadAsync<dynamic>();
                    var avgGDI = await multiple.ReadAsync<dynamic>();
                    var reportEficiencia = new KeyValuePair<string, IEnumerable<dynamic>>("Eficiencia", eficiencia);
                    var reportCubaAnterio = new KeyValuePair<string, IEnumerable<dynamic>>("Cubo Anterior", cuboAnterio);
                    var reportGDI = new KeyValuePair<string, IEnumerable<dynamic>>("Promedio GDI", avgGDI);
                    return new List<KeyValuePair<string, IEnumerable<dynamic>>>(){reportEficiencia, reportCubaAnterio, reportGDI};
                }
            }
        }

        public async Task<List<KeyValuePair<string, IEnumerable<dynamic>>>> GetCuboTacticianPlan(Object parameters)
        {
            using (var multiple = this.dbContext.QueryMultiple("[dbo].[EVO_Cubo_Tactician_Plan]", parameters: parameters))
            {
                var final1 = await multiple.ReadAsync<dynamic>();
            var final2 = await multiple.ReadAsync<dynamic>();
                var final3 = await multiple.ReadAsync<dynamic>();
                var reportEficiencia = new KeyValuePair<string, IEnumerable<dynamic>>("Final", final1);
                var reportCubaAnterio = new KeyValuePair<string, IEnumerable<dynamic>>("Final", final2);
                var reportGDI = new KeyValuePair<string, IEnumerable<dynamic>>("Final", final3);
                return new List<KeyValuePair<string, IEnumerable<dynamic>>>(){reportEficiencia, reportCubaAnterio, reportGDI};
            }
        }

        public async Task<List<KeyValuePair<string, IEnumerable<dynamic>>>> InsertProductAsync(Object parameters)
        {
            using (var multiple = this.dbContext.QueryMultiple("[dbo].[EVO_InsertarProductoCantera]", parameters: parameters))
            {
                var productoCantera = await multiple.ReadAsync<dynamic>();
                var origenes = await multiple.ReadAsync<dynamic>();
                var vsapProducto = await multiple.ReadAsync<dynamic>();
                var vistaMateriales = await multiple.ReadAsync<dynamic>();
                var reportproductoCantera = new KeyValuePair<string, IEnumerable<dynamic>>("productoCantera", productoCantera);
                var reportorigeneso = new KeyValuePair<string, IEnumerable<dynamic>>("origenes", origenes);
                var reportvsapProducto = new KeyValuePair<string, IEnumerable<dynamic>>("VsapProducto", vsapProducto);
                var reportvistaMateriales = new KeyValuePair<string, IEnumerable<dynamic>>("Vista Materiales", vistaMateriales);
                return new List<KeyValuePair<string, IEnumerable<dynamic>>>(){reportproductoCantera, reportorigeneso, reportvsapProducto, reportvistaMateriales};
            }
        }

        public async Task<int> ExecuteUpdateCVP(DataTable table)
        {
          var parameters = new
            {
                tbexport = table.AsTableValuedParameter(table.TableName),
                dtFecha = table.ExtendedProperties["dtFecha"],
                bMensual = table.ExtendedProperties["bMensual"]
            };
            return await this.dbContext.ExecuteAsync("[dbo].[EVO_Actualizar_CVP]", parameters);
        }

        public async Task<dynamic> UpdateMonthlyPlan(Object parameters)
        {
          return await this.dbContext.QueryAsync<dynamic>("[dbo].[EVO_ActualizaPlanMensual]", parameters);
        }

        public async Task<dynamic> ProcessInterfaceProduct2Async(Object parameters)
        {
          return await this.dbContext.QueryAsync<dynamic>("[dbo].[EVO_ProcesaInterfazProductos2]", parameters);
        }
    }
}
