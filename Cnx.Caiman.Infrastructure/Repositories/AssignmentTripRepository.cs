using Cnx.Caiman.Core.DTOs.AssignmentTrip;
using Cnx.Caiman.Core.DTOs.ManualPlan;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.AsignacionViajes;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Exceptions;
using Cemex.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cnx.Caiman.Core.Entities.QueryEntities.TripsPlan;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class AssignmentTripRepository : IAssignmentTripRepository
    {
        private readonly IDbContext dbContext;

        public AssignmentTripRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task DeleteAsync(int Idtrip, string user)
        {
            var parameters = new { idViaje = Idtrip, usuario = user };

            await this.dbContext.ExecuteScalarAsync<int>("[dbo].[ViajeEliminar]", parameters: parameters);
        }

        public async Task<IEnumerable<KeyValuePair<int, string>>> getPlanAssigListAsyc(int idzone, DateTime date)
        {
            var parameters = new
            {
                idzona = idzone,
                dtfecha = date.ToString("yyyy-MM-dd")
            };

            var result = await this.dbContext.QueryAsync<KeyValuePair<int, string>>("[dbo].[Evo_PlanAsignacionListarPorDiaOrigen]", parameters: parameters);

            return result;
        }

        public async Task<dynamic> getAceptTripListAsyc(int resultTrip)
        {

            var result = await this.dbContext.QueryAsync<dynamic>("[dbo].[Evo_ViajeListarAceptacion]", parameters: new { resultado = resultTrip });

            return result.FirstOrDefault();
        }

        public async Task<ViajeListarCostosResult> getCostsAsyc(TripListCostsParamsDto model)
        {

            var result = await this.dbContext.QueryAsync<ViajeListarCostosResult>("[dbo].[ViajeListarCostos]", parameters: model);

            return result.FirstOrDefault();
        }

        public async Task<dynamic> ListTripAsync(Object parameters)
        {
            IEnumerable<ViajeListarResult> Collaction = null;
            int totalCount = 0;
            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_ViajeListar]", parameters: parameters))
            {
                Collaction = await multiple.ReadAsync<ViajeListarResult>();
                totalCount = multiple.ReadSingle<int>();
            }
            return new
            {
                records = Collaction,
                count = totalCount
            };
        }


        public async Task<int> AceptAssignPlanAsync(AceptAssignPlanDto model)
        {
            int resp;
            var parameters = new
            {
                idresultado = model.idresultado,
                usuario = model.Vc20Usuario,
                fecha = model.fecha.ToString("yyyy-MM-dd")
            };

            try
            {
                resp = await this.dbContext.ExecuteAsync("[dbo].[Evo_PlanAsignacionAceptar]", parameters);
            }
            catch (Exception ex)
            {
                throw new CreateValidationException(ex.Message);
            }


            return resp;
        }

        public async Task<List<PlanAsignacionEnviarASicadiResult>> PlanSendSicadiAsync(AceptAssignPlanDto model)
        {
            var parameters = new
            {
                idresultado = model.idresultado,
                usuario = model.Vc20Usuario,
                fecha = model.fecha.ToString("yyyy-MM-dd")
            };
            var result = await this.dbContext.QueryAsync<PlanAsignacionEnviarASicadiResult>("[dbo].[PlanAsignacionEnviarASicadi]", parameters: parameters);

            return result.ToList();
        }

        public async Task<string> SapFileJsonAsync()
        {
            var parameters = new
            {
                parameter = 1
            };
            var result = await this.dbContext.QueryAsync<string>("[dbo].[Evo_ParemeterSAPTrips]", parameters);

            return result.FirstOrDefault();
        }

        public async Task<KeyValuePair<List<ViajeSapFile>, string>> TripsSapFileAsync(AceptAssignPlanDto model)
        {
            var parameters = new
            {
                IdResultado = model.idresultado
            };

            List<ViajeSapFile> tripSapCollection = null;
            string namefile = "";


            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_ProcesaInterfazPlanEmbarques3]", parameters: parameters))
            {
                tripSapCollection = (await multiple.ReadAsync<ViajeSapFile>()).ToList();
                namefile = (await multiple.ReadAsync<string>()).FirstOrDefault();
            }

            var result = new KeyValuePair<List<ViajeSapFile>, string>
            (
                tripSapCollection,
                namefile
            );

            return result;
        }

        public async Task<TripsPlanAssigment> TripsSapAsync(AceptAssignPlanDto model)
        {
            var parameters = new
            {
                IdResultado = model.idresultado
            };

            TripsPlanAssigment result = new TripsPlanAssigment();
            //string namefile = "";
            //int Plan = 0;


            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_ProcesaInterfazPlanEmbarques2]", parameters: parameters))
            {
                result.details = new List<ViajeSap>();
                result.details = (await multiple.ReadAsync<ViajeSap>()).ToList();
                //namefile = (await multiple.ReadAsync<string>()).FirstOrDefault();
                result.AssignmentPlanID = (await multiple.ReadAsync<string>()).FirstOrDefault();
            }

            //var result = new KeyValuePair<List<ViajeSap>, string>
            //(
            //    tripSapCollection,
            //    namefile
            //);

            return result;
        }

        public async Task<int> UpdateStatusPlan(int AsigmmentId, int IdStatus, string PlanType,string MensajeAzure)
        {
            var parameters = new
            {
                IdPlan = AsigmmentId,
                TipoPlan = PlanType,
                IdEstatus = IdStatus,
                MensajeAzure = MensajeAzure
            };

            var result = await this.dbContext.ExecuteAsync("[dbo].[Evo_ActualizaPlan]", parameters: parameters);

            return result;
        }


        //apartado de edicion
        public async Task<dynamic> TripEditListAsync(Object parameters)
        {
            IEnumerable<ViajeListarEdicionResult> Collaction = null;
            int totalCount = 0;
            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_ViajeListarEdicion]", parameters: parameters))
            {
                Collaction = await multiple.ReadAsync<ViajeListarEdicionResult>();
                totalCount = multiple.ReadSingle<int>();
            }
            return new
            {
                records = Collaction,
                count = totalCount
            };
        }

        public async Task<IEnumerable<KeyValuePair<int, string>>> getTripCarrierListAsync(int idresult)
        {
            var parameters = new
            {
                idresultado = idresult
            };

            var result = await this.dbContext.QueryAsync<KeyValuePair<int, string>>("[dbo].[Evo_ViajeTransportistaListar]", parameters: parameters);

            return result;
        }

        public async Task<IEnumerable<KeyValuePair<int, string>>> getTripOriginListAsync(int idresult)
        {
            var parameters = new
            {
                idresultado = idresult
            };

            var result = await this.dbContext.QueryAsync<KeyValuePair<int, string>>("[dbo].[Evo_ViajeOrigenListar]", parameters: parameters);

            return result;
        }

        public async Task UpdateTripAsync(UpdateTripDto model)
        {
            try
            {
                var parameters = new
                {
                    idviaje = model.idviaje,
                    prioridad = model.prioridad,
                    idtransportista = model.idtransportista,
                    idorigen = model.idorigen,
                    usuario = model.Vc20Usuario,
                    bValidar = model.bValidar
                };

                await this.dbContext.ExecuteAsync("[dbo].[ViajeValidar]", parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //factibilidad

        public async Task<dynamic> ListsFactibilityAsync(int idzone, int validation, string date, int idresult)
        {
            var parameters = new
            {
                idzona = idzone,
                validacion = validation,
                dtfecha = date,
                idresultado = idresult
            };

            var result = await this.dbContext.QueryAsync<dynamic>("[dbo].[Evo_ValidacionesPosterioresListar]", parameters: parameters);

            return result;
        }

        public async Task<dynamic> ListsPriorityAsync(int idzone, int idresult, int entity)
        {
            var parameters = new
            {
                idzona = idzone,
                idresultado = idresult,
                iEntidad = entity
            };

            var result = await this.dbContext.QueryAsync<dynamic>("[dbo].[Evo_ValidacionesPosterioresListarPrioridadInfactible]", parameters: parameters);

            return result;
        }

        public async Task<dynamic> ListFeasibilityAgreementAsync(Object parameters)
        {
            IEnumerable<RestriccionListarIncumplidoResult> Collaction = null;
            int totalCount = 0;
            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_RestriccionListarIncumplido]", parameters: parameters))
            {
                Collaction = await multiple.ReadAsync<RestriccionListarIncumplidoResult>();
                totalCount = multiple.ReadSingle<int>();
            }
            return new
            {
                records = Collaction,
                count = totalCount
            };
        }

        public async Task ReevaluateTripAsync(int result)
        {
            try
            {
                var parameters = new
                {
                    idresultado = result
                };

                await this.dbContext.ExecuteAsync("[dbo].[FactibilidadReevaluar]", parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<KeyValuePair<int, string>>> getFilterListElementAsync(FilterListElementDto model)
        {
            var parameters = new
            {
                elemento = model.Element,
                idzona = model.IdZone,
                idresultado = model.IdResult,
                nombre = model.Search
            };

            var result = await this.dbContext.QueryAsync<KeyValuePair<int, string>>("[dbo].[Evo_FiltroListarElementosViajeNuevo]", parameters: parameters);

            return result;
        }

        public async Task<int> InsertPlanTripAsync(InsertPlanTripDto model)
        {
            var parameters = new
            {
                idzona = model.idzone,
                idOrigen = model.Idorigin,
                idDestino = model.IdDetination,
                idProducto = model.IdProduct,
                idTransportista = model.IdShipper,
                iHorario = model.IdHour,
                vcUsuario = model.Vc20Usuario,
                idresultado = model.IdResult
            };

            var result = await this.dbContext.QueryAsync<int>("[dbo].[PlanInsertarViaje]", parameters: parameters);

            return result.FirstOrDefault();
        }

    }
}
