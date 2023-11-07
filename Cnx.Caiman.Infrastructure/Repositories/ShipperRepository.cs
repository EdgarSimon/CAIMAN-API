using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.DTOs.Shipper;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly IDbContext dbContext;

        public ShipperRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> DeleteAsync(string IdShipper, string user)
        {
            var parameters = new
            {
                id = IdShipper,
                vc20usuario = user
            };
            return await this.dbContext.ExecuteAsync("[dbo].[TransportistaEliminar]", parameters);
        }

        public async Task<IEnumerable<Transportista>> GetAsync(Object parameters)
        {
            return await this.dbContext.QueryAsync<Transportista>("[dbo].[Evo_TransportistaListar]", parameters);
        }

        public async Task<IEnumerable<Transportista>> GetMonthAsync(int idZona, DateTime date)
        {
            var parameters = new
            {
                idzona = idZona,
                dtfecha = date.ToString()
            };
            return await this.dbContext.QueryAsync<Transportista>("[dbo].[Evo_TransportistaListarMensual]", parameters);
        }

        public async Task<IEnumerable<Transportista>> GetOrdersByTripAsync(int idZona)
        {
            var parameters = new
            {
                idzona = idZona,
            };
            return await this.dbContext.QueryAsync<Transportista>("[dbo].[Evo_TransportistaListarMensual]", parameters);
        }

        public async Task<IEnumerable<Transportista>> GetRelationMonthAsync(int idZona, DateTime date)
        {
            var parameters = new
            {
                idzona = idZona,
                dtfecha = date.ToString()
            };
            return await this.dbContext.QueryAsync<Transportista>("[dbo].[TransportistaListarMensualRel]", parameters);
        }

        public async Task<IEnumerable<Transportista>> GetRelationMonthlyAsync(int idZona, DateTime date)
        {
            var parameters = new
            {
                idzona = idZona,
                dtfecha = date.ToString()
            };
            return await this.dbContext.QueryAsync<Transportista>("[dbo].[TransportistaListarMensualRel]", parameters);
        }

        public async Task<IEnumerable<Transportista>> GetValuesAsync(int idZona)
        {
            var parameters = new
            {
                idzona = idZona,
            };
            return await this.dbContext.QueryAsync<Transportista>("[dbo].[TransportistaListarMensualRel]", parameters);
        }

        public async Task<IEnumerable<Transportista>> GetValuesMonthAsync(int idZona, DateTime date)
        {
            var parameters = new
            {
                idzona = idZona,
                dtfecha = date.ToString()
            };
            return await this.dbContext.QueryAsync<Transportista>("[dbo].[TransportistaListarMensualRel]", parameters);
        }

        public async Task<int> InsertAsync(ShipperInsertDto data)
        {
            try 
            {
                var response = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[Evo_TransportistaInsertar]", (Object)data);
                return response;
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> InsertMonthlyAsync(ShipperInsertMonthlyDto data)
        {
            try
            {
                var parameters = new {
                    nombre = data.Nombre,
                    zona = data.Zona,
                    tarifa = data.Tarifa,
                    CostoTarifa = data.CostoTarifa,
                    servirprioridad = data.Servirprioridad,
                    iCantSencillos = data.ICantSencillos,
                    maneja = data.Maneja,
                    claveSit = data.ClaveSit,
                    dtfecha = data.Dtfecha.ToString(),
                    propio = data.Propio,
                    vc20usuario = data.Vc20usuario
                };
                return await this.dbContext.ExecuteAsync("[dbo].[TransportistaActualizarMensual", parameters: parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> UpdateAsync(ShipperUpdateDto data)
        {
            try
            {
                return await this.dbContext.ExecuteAsync("[dbo].[Evo_TransportistaActualizar]", (Object)data);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> UpdateMonthlyAsync(int idTransportista, ShipperInsertMonthlyDto data)
        {
            try
            {
                  var parameters = new {
                    transportista = idTransportista,
                    nombre = data.Nombre,
                    valor = data.Tarifa,
                    CostoTarifa = data.CostoTarifa,
                    servirprioridad = data.Servirprioridad,
                    iCantSencillos = data.ICantSencillos,
                    maneja = data.Maneja,
                    claveSit = data.ClaveSit,
                    propio = data.Propio
                };
                return await this.dbContext.ExecuteAsync("[dbo].[TransportistaActualizarMensual", parameters: parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<IEnumerable<Transportista>> GetByZoneAllAsync(int idZona, bool isagreement, string word)
        {
            var parameters = new
            {
                idzona = idZona,
                esRestriccion = isagreement,
                vcPalabra = word
            };
            return await this.dbContext.QueryAsync<Transportista>("[dbo].[Evo_RestriccionListarTransportistasPorZona]", parameters);
        }

        public async Task<IEnumerable<Transportista>> GetRestrictionAsync(int idZona, long tid, string phrase)
        {
            var parameters = new
            {
                zona = idZona,
                TID = tid,
                Clave = "Transportes",
                palabra = phrase
            };
            return await this.dbContext.QueryAsync<Transportista>("[dbo].[Evo_RestriccionTransportistaListarDisponibles]", parameters);
        }

        public async Task<IEnumerable<Transportista>> GetRestrictionOneToOneAsync(int idZona, long tid)
        {
            var parameters = new
            {
                zona = idZona,
                TID = tid,
                Clave = "Transportes2"
            };
            return await this.dbContext.QueryAsync<Transportista>("[dbo].[Evo_RestriccionTransportistaListarDisponibles]", parameters);
        }
        
        public async Task<IEnumerable<Transportista>> GetRestrictionInvolvedAsync(int idZona, long tid)
        {
            var parameters = new
            {
                zona = idZona,
                TID = tid,
                Clave = "Transportista"
            };
            return await this.dbContext.QueryAsync<Transportista>("[dbo].[Evo_RestriccionTransportistaListarInvolucrados]", parameters);
        }

        public async Task<IEnumerable<Transportista>> GetRestrictionInvolvedOneToOneAsync(int idZona, long tid)
        {
            var parameters = new
            {
                zona = idZona,
                TID = tid,
                Clave = "Transportista2"
            };
            return await this.dbContext.QueryAsync<Transportista>("[dbo].[Evo_RestriccionTransportistaListarInvolucrados]", parameters);
        }

        public async Task<int> InsertRestrictionOneToOneAsync(int tid, string value255)
        {
            try
            {
                var parameters = new {
                    TID = tid,
                    vc20Clave = "Transportistas2",
                    vc255Valor = value255
                };

                return await this.dbContext.ExecuteAsync("[dbo].[TransaccionInfoEstablecerUnoAUno]", parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> InsertRestrictionAsync(ShipperRestrictionDto model)
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