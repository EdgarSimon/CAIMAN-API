using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Origin;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.Origen;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class OriginRepository: IOriginRepository
    {
        private readonly IDbContext dbContext;

        public OriginRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> DeleteAsync(string id, string user)
        {
            try 
            {
                var parameters = new {
                    id = id,
                    vc20Usuario = user,
                };
                return await this.dbContext.ExecuteAsync("[dbo].[OrigenEliminar]", parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public Task<IEnumerable<Origen>> GetAllAsync(int idZone)
        {
            throw new System.NotImplementedException();
        }


        public async Task<IEnumerable<OrigenQuery>> GetAsync(Object parameters)
        {
            
            return await this.dbContext.QueryAsync<OrigenQuery>
                ("[dbo].[Evo_OrigenListar]", parameters: parameters);
        }

        public async Task<IEnumerable<Origen>> GetByZoneAllAsync(int idZona,bool isagreement, string search)
        {
            var parameters = new
            {
                idzona = idZona,
                esRestriccion = isagreement,
                vcPalabra = search
            };
            return await this.dbContext.QueryAsync<Origen>("[dbo].[Evo_RestriccionListarOrigenesPorZona]", parameters);
        }

        public async Task<IEnumerable<Origen>> GetRestrictionAsync(int idZona, long tid, string phrase)
        {
            var parameters = new
            {
                zona = idZona,
                TID = tid,
                Clave = "Origenes",
                palabra = phrase
            };
            return await this.dbContext.QueryAsync<Origen>("[dbo].[Evo_RestriccionOrigenListarDisponibles]", parameters);
        }

        public async Task<IEnumerable<Origen>> GetRestrictionOneToOneAsync(int idZona, long tid)
        {
            var parameters = new
            {
                zona = idZona,
                TID = tid,
                Clave = "Origenes2"
            };
            return await this.dbContext.QueryAsync<Origen>("[dbo].[Evo_RestriccionOrigenListarDisponibles]", parameters);
        }

        public async Task<IEnumerable<Origen>> GetRestrictionInvolvedAsync(int idZona, long tid)
        {
            var parameters = new
            {
                zona = idZona,
                TID = tid,
                Clave = "Origenes"
            };
            return await this.dbContext.QueryAsync<Origen>("[dbo].[Evo_RestriccionOrigenListarInvolucrados]", parameters);
        }

        public async Task<IEnumerable<Origen>> GetRestrictionInvolvedOneToOneAsync(int idZona, long tid)
        {
            var parameters = new
            {
                zona = idZona,
                TID = tid,
                Clave = "Origenes2"
            };
            return await this.dbContext.QueryAsync<Origen>("[dbo].[Evo_RestriccionOrigenListarInvolucrados]", parameters);
        }
        public async Task<IEnumerable<Origen>> GetOriginNewDistanceAsync(int idorigin)
        {
            var parameters = new
            {
                destino = idorigin
            };
            return await this.dbContext.QueryAsync<Origen, Enlace, Origen>("[dbo].[Evo_OrigenListarNuevasDistancias]",
                map: (origen, enlace) =>
                {
                    origen.Enlace = enlace;

                    return origen;
                },
                splitOn: "IdEnlace",
                parameters: parameters);
        }

        public async Task<int> InsertAsync(OriginInsertDto data)
        {
            try 
            {
                 var parameters = new {
                    zona = data.Zona,
                    nombre = data.Nombre,
                    propio = data.Propio,
                    manana = data.Manana,
                    tarde = data.Tarde,
                    noche = data.Noche,
                    servirprioridad = data.Servirprioridad,
                    claveSicadi = data.ClaveSicadi,
                    claveSit = data.ClaveSit,
                    cargaaut = data.Cargaaut,
                    vc20usuario = data.Vc20usuario,
                    prmIdSAP = data.PrmIdSAP
                };
                return await this.dbContext.ExecuteScalarAsync<int>("[dbo].[Evo_OrigenInsertar]", parameters: parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> InsertMonthlyAsync(OriginInsertDto data)
        {
            try 
            {
                 var parameters = new {
                    zona = data.Zona,
                    nombre = data.Nombre,
                    propio = data.Propio,
                    manana = data.Manana,
                    tarde = data.Tarde,
                    noche = data.Noche,
                    servirprioridad = data.Servirprioridad,
                    claveSicadi = data.ClaveSicadi,
                    claveSit = data.ClaveSit,
                    cargaaut = data.Cargaaut,
                    vc20usuario = data.Vc20usuario,
                    prmIdSAP = data.PrmIdSAP
                };
                return await this.dbContext.ExecuteAsync("[dbo].[Evo_OrigenInsertar]", parameters: parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> UpdateAsync(int id, OriginInsertDto data)
        {
            try 
            {
                var parameters = new {
                    idOrigen = id,
                    vcNombre = data.Nombre,
                    bPropio = data.Propio,
                    iManana = data.Manana,
                    iTarde = data.Tarde,
                    iNoche = data.Noche,
                    servirprioridad = data.Servirprioridad,
                    claveSicadi = data.ClaveSicadi,
                    claveSit = data.ClaveSit,
                    cargaaut = data.Cargaaut,
                    vc20usuario = data.Vc20usuario,
                    vc4Cedis = data.Vc4Cedis,
                    vc25NombreCorto = data.Vc25NombreCorto
                };
                return await this.dbContext.ExecuteAsync("[dbo].[OrigenActualizar]", parameters: parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> InsertRestrictionOneToOneAsync(int tid, string value255)
        {
            try
            {
                var parameters = new
                {
                    TID = tid,
                    vc20Clave = "Origenes2",
                    vc255Valor = value255
                };

                return await this.dbContext.ExecuteAsync("[dbo].[TransaccionInfoEstablecerUnoAUno]", parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> InsertRestrictionAsync(OriginRestrictionDto model)
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