using Cnx.Caiman.Core.DTOs.AssigPlan;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Exceptions;
using Cemex.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class AssigPlanRepository: IAssigPlanRepository
    {
        private readonly IDbContext dbContext;

        public AssigPlanRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<PlanAsignacion>> GetAsync(Object parameters)
        {
            var result = await this.dbContext.QueryAsync<PlanAsignacion, Usuario, PlanAsignacion>("[dbo].[Evo_PlanAsignacionListarU]",
                map: (plan, user) =>
                {
                    plan.Usuario = user;
                    return plan;
                },
                splitOn: "IdUsuario",
                parameters);

            return result.ToList();
        }

        public async Task<int> UpdateAsync(AssigPlanUpdateDto model)
        {
            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[PlanAsignacionActualizar]", parameters: model);

            return result;
        }

        public async Task<int> UpdatestateAsync(AssigPlanstateDto model)
        {
            var parameters = new
            {
                plan = model.IdPlanAsignacion,
                estatus = model.Estatus,
                usuario = model.Vc20Usuario
            };
            try
            {
                var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[OptCambiaEstatusPlan]", parameters: parameters);
                return result;
            }
            catch(Exception){

                return 0;
            }

        }

        public async Task<int> InsertAsync(AssigPlanInsertDto model)
        {
            int result = 0;
            var parameters = new
            {
                nombre = model.Nombre,
                observaciones = model.Observaciones,
                idzona = model.IdZona,
                dtfecha = model.dtFecha.ToString("yyyy-MM-dd"),
                vc20Usuario = model.Vc20Usuario
            };

            try
            {
                result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[Evo_PlanAsignacionInsertar]", parameters: parameters);

            }catch(SqlException ex)
            {
                throw new CreateValidationException(ex.Message);
            }

            return result;
        }

        public async Task<int> DeleteAsync(int IdPlanAsignacion, string vc20Usuario)
        {
            var parameters = new
            {
                IdPlanAsignacion = IdPlanAsignacion,
                vc20Usuario = vc20Usuario
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[PlanAsignacionEliminar]", parameters: parameters);

            return result;
        }

        public async Task<int> InsertCopyAsync(AssigPlanInsertCopyDto model)
        {
            var parameters = new
            {
                plan = model.Plan,
                usuario = model.Vc20Usuario,
                TID = model.TID,
                destino = model.iDestino,
                distancia = model.iDistancia,
                origen = model.iOrigen,
                producto = model.iProducto,
                transportista = model.iTransportista,
                convenio = model.iConvenio,
                viajes = model.iViajes,
                optimizacion = model.iOptimizacion,
                fechaObj = model.FechaObj.ToString("yyyy-MM-dd")
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[PlanAsignacionInsertarCopia]", parameters: parameters);

            return result;
        }
    }
}
