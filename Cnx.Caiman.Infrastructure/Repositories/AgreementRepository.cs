using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.DTOs.Agreement;
using System.Data.SqlClient;
using System.Threading;
using Cnx.Caiman.Core.DTOs.Hour;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class AgreementRepository : IAgreementRepository
    {
        private readonly IDbContext dbContext;

        public AgreementRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> InfoAsync(int idzone)
        {
            var parameters = new { idZona = idzone };

            var result = await this.dbContext.QueryAsync<int>("[dbo].[EntidadListarInfo]", parameters: parameters);

            return result.FirstOrDefault();
        }

        public async Task<dynamic> ListSearchAsync(Object arguments)
        {
            var count = 0;
            var result = await this.dbContext.QueryAsync<Restriccion, RelTraduccionRestriccion, Usuario, int, Restriccion>("[dbo].[Evo_RestriccionListar]",
                map: (reestriccion, reltraduccionreestriccion, usuario, total) =>
                {
                    reestriccion.relTraduccionRestriccion = reltraduccionreestriccion;
                    reestriccion.Usuario = usuario;
                    count = total;

                    return reestriccion;
                },
                splitOn: "IdRestriccion, IdTraduccion, IdUsuario, count",
                parameters: arguments);

            return new
            {
                records = result,
                count = count
            };
        }

        public async Task<int> DeleteTransacAsync(long TID)
        {
            var parameters = new { TID = TID };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[TransaccionEliminar]", parameters: parameters);

            return result;
        }

        public async Task<int> DeleteAsync(int idagreement)
        {
            var parameters = new { IdRestriccion = idagreement };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[RestriccionEliminar]", parameters: parameters);

            return result;
        }

        public async Task<int> GetTIDAsync(string description)
        {
            var parameters = new { vc20Desc1 = description };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[TransaccionCrearConvencional]", parameters: parameters);

            return result;
        }

        public async Task<int> InsertAsync(AgreementSaveDto agreement)
        {
            var parameters = new
            {
                vcClave = agreement.vcClave,
                vcDescripcion = agreement.vcDescripcion,
                IdTransportista = agreement.IdTransportista,
                IdOrigen = agreement.IdOrigen,
                IdDestino = agreement.IdDestino,
                IdProducto = agreement.IdProducto,
                IdHorario = agreement.IdHorario,
                IdTransportista2 = agreement.IdTransportista2,
                IdOrigen2 = agreement.IdOrigen2,
                IdDestino2 = agreement.IdDestino2,
                IdProducto2 = agreement.IdProducto2,
                IdHorario2 = agreement.IdHorario2,
                iMin = agreement.iMin,
                iMax = agreement.iMax,
                TID = agreement.TID,
                idZona = agreement.idZona,
                iCantidadMin = agreement.iCantidadMin,
                iCantidadMax = agreement.iCantidadMax,
                iPor1 = agreement.iPor1,
                iPor2 = agreement.iPor2,
                bSirveA = agreement.bSirveA,
                EntidadAbsoluta = agreement.EntidadAbsoluta,
                EntidadSecundaria = agreement.EntidadSecundaria,
                Traduccion = agreement.Traduccion,
                vc20Usuario = agreement.vc20Usuario,
                operador = agreement.operador,
                idperfil = agreement.IdPerfil,
                idfrecuencia = agreement.idfrecuencia
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[RestriccionInsertar]", parameters: parameters);

            return result;
        }

        public async Task<int> UpdateAsync(AgreementSaveDto agreement)
        {
            var parameters = new
            {
                IdRestriccion = agreement.IdRestriccion,
                vcClave = agreement.vcClave,
                vcDescripcion = agreement.vcDescripcion,
                IdTransportista = agreement.IdTransportista,
                IdOrigen = agreement.IdOrigen,
                IdDestino = agreement.IdDestino,
                IdProducto = agreement.IdProducto,
                IdHorario = agreement.IdHorario,
                IdTransportista2 = agreement.IdTransportista2,
                IdOrigen2 = agreement.IdOrigen2,
                IdDestino2 = agreement.IdDestino2,
                IdProducto2 = agreement.IdProducto2,
                IdHorario2 = agreement.IdHorario2,
                iMin = agreement.iMin,
                iMax = agreement.iMax,
                TID = agreement.TID,
                idZona = agreement.idZona,
                iCantidadMin = agreement.iCantidadMin,
                iCantidadMax = agreement.iCantidadMax,
                iPor1 = agreement.iPor1,
                iPor2 = agreement.iPor2,
                bSirveA = agreement.bSirveA,
                EntidadAbsoluta = agreement.EntidadAbsoluta,
                EntidadSecundaria = agreement.EntidadSecundaria,
                Traduccion = agreement.Traduccion,
                vc20Usuario = agreement.vc20Usuario,
                operador = agreement.operador,
                idperfil = agreement.IdPerfil,
                idfrecuencia = agreement.idfrecuencia
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[RestriccionActualizar]", parameters: parameters);

            return result;
        }
        public async Task<int> UpdateDpAsync(AgreementDailyPlanDto model)
        {
            var parameters = new
            {
                idzona = model.idzone,
                idconvenio = model.idagreement,
                fecha = model.date.ToString("yyyy-MM-dd"),
                iendia = (model.select) ? 1 : 0,
                idusuario = model.iduser,
                todos = model.applyAll,
                ConvenioNoAplica = model.agreementexclude,
            };

            var result = this.dbContext.ExecuteAsync("[dbo].[Evo_ConvenioActualizar]", parameters: parameters).GetAwaiter().GetResult();

            return await Task.FromResult(result);            
        }

        public async Task<Restriccion> RestrictionInfoAsync(int idrestriction)
        {
            var result = await this.dbContext.QueryAsync<Restriccion, Restriccion2, Restriccion>("[dbo].[Evo_RestriccionInfo]",
                map: (reestriccion, restriccion2) =>
                {
                    reestriccion.Restriccion2 = restriccion2;

                    return reestriccion;
                },
                splitOn: "vc20Clave, idtransportista2",
                parameters: new { idrestriccion = idrestriction });

            return result.FirstOrDefault();
        }

        public async Task<EsqPivPron> FindInfoAsync(FindInfoDto model)
        {

            var parameters = new
            {
                idt = model.IdTransportista,
                ido = model.IdOrigen,
                idd = model.IdDestino,
                idp = model.IdProducto,
                idh = model.IdHorario,
                idt2 = model.IdTransportista2,
                ido2 = model.IdOrigen2,
                idd2 = model.IdDestino2,
                idp2 = model.IdProducto2,
                idh2 = model.IdHorario2,
                tid = model.TID,
                idrestriccion  = model.IdRestriccion
            };

            var result = await this.dbContext.QueryAsync<EsqPivPron>("[dbo].[EsqPivPronListarInfo]", parameters: parameters);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ConvenioFrecuencia>> FrequencyAsync()
        {
            return await this.dbContext.QueryAsync<ConvenioFrecuencia>("[dbo].[ListarFrecuenciasConvenio]");
        }

        public async Task<IEnumerable<RestriccionTipo>> ByTypeAsync()
        {
            return await this.dbContext.QueryAsync<RestriccionTipo>("[dbo].[Evo_RestriccionListarTipo]");
        }

        public async Task<IEnumerable<Perfil>> ProfileListAsync()
        {
            return await this.dbContext.QueryAsync<Perfil>("[dbo].[Evo_PerfilListarOpciones]");
        }

        public async Task<dynamic> GetByDailyPlanAsync(Object parameters)
        {
            var count = 0;
            var result = await this.dbContext.QueryAsync<Restriccion, RelTraduccionRestriccion, Convenio, int, Restriccion>("[dbo].[Evo_ConveniosListar]",
                map: (reestriccion, reltraduccionreestriccion, convenio, total) =>
                {
                    reestriccion.relTraduccionRestriccion = reltraduccionreestriccion;
                    reestriccion.Convenio = convenio;
                    count = total;

                    return reestriccion;
                },
                splitOn: "IdRestriccion, IdTraduccion, idconvenios, total",
                parameters: parameters);

            return new
            {
                records = result,
                count = count
            };
        }

        public async Task<IEnumerable<Horario>> GetRestrictionAsync(int idZona, long tid, string search)
        {
            var parameters = new { zona = idZona, TID = tid, Clave = "Horarios", palabra = search };
            return await this.dbContext.QueryAsync<Horario>("[dbo].[Evo_RestriccionHorarioListarDisponiblesFromTID]", parameters);
        }

        public async Task<IEnumerable<Horario>> GetRestrictionOnetoOneAsync(int idZona, long tid, string search)
        {
            var parameters = new { zona = idZona, TID = tid, Clave = "Horarios2", palabra = search };
            return await this.dbContext.QueryAsync<Horario>("[dbo].[Evo_RestriccionHorarioListarDisponiblesFromTID]", parameters);
        }

        public async Task<int> InsertRestrictionAsync(HourRestrictionDto model)
        {
            try
            {
                var parameters = new
                {
                    TID = model.tid,
                    vc20Clave = model.vcClave,
                    vc255Valor = model.value255,
                    bAplicaTodos = model.bAplicaTodos,
                    vcDatosExcluir = model.vcDatosExcluir
                };

                return await this.dbContext.ExecuteAsync("[dbo].[Evo_TransaccionInfoEstablecer]", parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
