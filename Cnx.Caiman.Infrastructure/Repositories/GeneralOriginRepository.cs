using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Origin;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class GeneralOriginRepository : IGeneralOriginRepository
    {
        private readonly IDbContext dbContext;

        public GeneralOriginRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> DeleteAsync(string PrmIdOrigen, string PrmUsuario)
        {
            try 
            {
                var parameters = new {
                    PrmIdOrigen = PrmIdOrigen,
                    PrmUsuario= PrmUsuario
                };
                return await this.dbContext.ExecuteAsync("[dbo].[OrigenGeneralEliminar]", parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        /// <summary>
        /// General origin excel
        /// </summary>
        /// <param name='filter'></param>
        /// <returns>General origin excel stream</returns>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /FilterGrid
        ///     {
        ///             "orderBy": { "column": "", "isDesc": 0 },//VCSAP,VC50NOMBRE,BPROPIO,BESLAB,CREADO,MODIFICADO,USUARIOMODIFICO,USUARIOCREO,MEDICIONVC50NOMBRE,
        ///             "paging":   { "pageNumber": 0, "pageSize": 0, "search": "string" },
        ///             "filters":  [
        ///                     {"Key": "vcSap", "value": "string"},
        ///                     {"Key": "vc50Nombre", "value": "string"},
        ///                     {"Key": "bPropio", "value": "string"},
        ///                     {"Key": "bEsLAB", "value": "string"},
        ///                     {"Key": "Creado", "value": "string"},
        ///                     {"Key": "Modificado", "value": "string"},
        ///                     {"Key": "UsuarioModifico", "value": "string"},
        ///                     {"Key": "UsuarioCreo", "value": "string"},
        ///                     {"Key": "MedicionVc50Nombre", "value": "string"}
        ///             ],
        ///             "Columns":  [
        ///                     {"Key": "vcSap", "value": "string"},
        ///                     {"Key": "vc50Nombre", "value": "string"},
        ///                     {"Key": "bPropio", "value": "string"},
        ///                     {"Key": "bEsLAB", "value": "string"},
        ///                     {"Key": "Creado", "value": "string"},
        ///                     {"Key": "Modificado", "value": "string"},
        ///                     {"Key": "UsuarioModifico", "value": "string"},
        ///                     {"Key": "UsuarioCreo", "value": "string"},
        ///                     {"Key": "MedicionVc50Nombre", "value": "string"}
        ///             ],
        ///     }
        ///
        /// </remarks>

        public async Task<IEnumerable<OrigenGeneral>> GetAsync(Object parameters)
        {
            return await this.dbContext.QueryAsync<OrigenGeneral, Medicion,
                OrigenGeneral>("[dbo].[Evo_OrigenGeneralListar]",
                map: (origenGeneral, medicion) =>
                {
                    origenGeneral._Medicion = medicion;
                    return origenGeneral;
                },
                splitOn: "idMedicion",
                parameters: parameters);
        }

        public async Task<IEnumerable<OrigenGeneral>> GetAvailableAsync(int idZone)
        {
            var parameters = new {
                idZona = idZone
            };
            return await this.dbContext.QueryAsync<OrigenGeneral>("[dbo].[Evo_OrigenGeneralListarDisponibles]", parameters);
        }

        public async Task<int> InsertAsync(GeneralOriginInsertDto data)
        {
            try 
            {
                return await this.dbContext.ExecuteScalarAsync<int>("[dbo].[Evo_OrigenGeneralInsertar]", (Object)data);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> UpdateAsync(int originId, GeneralOriginInsertDto data)
        {
            try 
            {
                var parameters = new {
                    prmIdOrigen = originId,
                    prmNombre = data.PrmNombre,
                    PrmIdSAP = data.PrmIdSAP,
                    PrmPropio = data.PrmPropio,
                    PrmActivo = data.PrmActivo,
                    PrmUsuario = data.PrmUsuario,
                    PrmMedicion = data.PrmMedicion,
                };
                return await this.dbContext.ExecuteAsync("[dbo].[OrigenGeneralActualizar]", parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}