using Cnx.Caiman.Core.DTOs.ManualPlan;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.CuboDiario;
using Cnx.Caiman.Core.Entities.QueryEntities.PlanManualInfo_Nvo;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cnx.Caiman.Infrastructure.Filters;
using Cemex.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cnx.Caiman.Core.Entities.QueryEntities.TripsPlan;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class ManualPlanRepository : IManualPlanRepository
    {
        private readonly IDbContext dbContext;

        public ManualPlanRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<PlanManual>> GetPlanAsync(int idzone, DateTime date)
        {

            var parameters = new
            {
                dtFecha = date.ToString("yyyy-MM-dd"),
                idZona = idzone
            };
            return await this.dbContext.QueryAsync<PlanManual>("[dbo].[Evo_PlanManualListar]", parameters: parameters);
        }

        public async Task<dynamic> GetManualInfoAsync(Object properties)
        {
            PlanManualResult ManualPlanCollection = null;
            List<ViajeManualResult> ViajeManualuserCollection = null;
            int total = 0;

            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_PlanManualInfo_Nvo]", parameters: properties))
            {
                ManualPlanCollection = (await multiple.ReadAsync<PlanManualResult>()).FirstOrDefault();
                ViajeManualuserCollection = (await multiple.ReadAsync<ViajeManualResult>()).ToList();
                total = (await multiple.ReadAsync<int>()).FirstOrDefault();
            }

            var result = new
            {
                ManualPlanCollection,
                ViajeManualuserCollection,
                total
            };

            return result;
        }


        public async Task<int> InsertAsync(int idzone, DateTime date, string user)
        {
            var parameters = new
            {
                idzona = idzone,
                sFecha = date.ToString("yyyy-MM-dd"),
                usuario = user
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[PlanManualNuevo]", parameters: parameters);

            return result;
        }


        public async Task<int> AuthorizeAsync(ManualPlanUpdateDto model)
        {
            var parameters = new
            {
                idPlanManual = model.idplan,
                usuario = model.Vc20Usuario
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[PlanManualAutorizar]", parameters: parameters);

            return result;
        }

        public async Task<TripsPlanAssigment> AcceptAsync(ManualPlanUpdateDto model)
        {
            var parameters = new
            {
                idPlanManual = model.idplan,
                usuario = model.Vc20Usuario
            };

            TripsPlanAssigment result = new TripsPlanAssigment();

            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_PlanManualAceptar]", parameters: parameters))
            {
                result.details = new List<ViajeSap>();
                result.details = (await multiple.ReadAsync<ViajeSap>()).ToList();
                result.AssignmentPlanID = (await multiple.ReadAsync<string>()).FirstOrDefault();
            }


            return result;
        }

        public async Task<KeyValuePair<List<ViajeManualSap>, string>> AcceptFileAsync(ManualPlanUpdateDto model)
        {
            var parameters = new
            {
                idPlanManual = model.idplan,
                usuario = model.Vc20Usuario
            };

            List<ViajeManualSap> tripPlanCollection = null;
            string namefile = "";


            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_PlanManualAceptar3]", parameters: parameters))
            {
                tripPlanCollection = (await multiple.ReadAsync<ViajeManualSap>()).ToList();
                namefile = (await multiple.ReadAsync<string>()).FirstOrDefault();
            }

            var result = new KeyValuePair<List<ViajeManualSap>, string>
            (
                tripPlanCollection,
                namefile
            );

            return result;
        }


        public async Task<dynamic> DailyCubeAsync(int idzone, string search, int? iddestination)
        {
            var parameters = new { IdZona = idzone, nombre = search, idDestino = iddestination };

            List<CuboCaimanReal> DestinationProductCollection = null;
            List<CuboDiario> CubeDailyCollection = null;
            string UM = "";


            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_ObtenerCuboDiarioAgg]", parameters: parameters))
            {
                DestinationProductCollection = (await multiple.ReadAsync<CuboCaimanReal>()).ToList();
                CubeDailyCollection = (await multiple.ReadAsync<CuboDiario>()).ToList();
                UM = (await multiple.ReadAsync<string>()).FirstOrDefault();
            }

            var result = new
            {
                destinationProduct = DestinationProductCollection,
                originShipper = CubeDailyCollection,
                UM
            };

            return result;
        }

        public async Task<int> InsertTripManualAsync(ManualTripDto model)
        {
            var parameters = new
            {
                idViaje = model.idTrip,
                idPlanManual = model.idManualPlan,
                fecha = model.date.ToString("yyyy-MM-dd"),
                idDestino = model.idDestination,
                idProducto = model.idProduct,
                idOrigen = model.idOrigin,
                idTransportista = model.idShidder,
                iPrioridad = model.iPriority,
                volumen = model.amount,
                viajes = model.Trips,
                tamanoLote = model.lotsize,
                usuario = model.Vc20Usuario,
                idCausa = model.idcause,
                comentario = model.remark
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[InsertarViajeManual]", parameters: parameters);

            return result;
        }

        public async Task<int> DeleteAsync(long idtrip)
        {
            try
            {
                var parameters = new
                {
                    idViaje = idtrip,
                };
                return await this.dbContext.ExecuteAsync("[dbo].[ViajeManualEliminar]", parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<int> FileCreateAsync(long plan, string file, string name,string Typeplan)
        {
            try
            {
                var parameters = new
                {
                    idPlan  = plan,
                    Archivo = file,
                    Nombre = name,
                    TipoPlan  = Typeplan
                };
                return await this.dbContext.ExecuteAsync("[dbo].[Evo_CreaPlanFile]", parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
