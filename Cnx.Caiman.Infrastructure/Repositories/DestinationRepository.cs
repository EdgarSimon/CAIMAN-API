using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Destination;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.Destino;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Interfaces;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly IDbContext dbContext;

        public DestinationRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<int> DeleteAsync(int id, string user)
        {
            try 
            {
                var parameters = new {
                    id = id,
                    vc20Usuario = user,
                };
                return await this.dbContext.ExecuteAsync("[dbo].[DestinoEliminar]", parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> DeleteRelationInventoryAsync(int idDestination, int idRelation)
        {
            try 
            {
                var parameters = new {
                    idDestino = idDestination,
                    idRelacion = idRelation,
                };
                return await this.dbContext.ExecuteAsync("[dbo].[RelDestinoInventarioBorrar]", parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<DestinoQuery>> GetAsync(Object parameters)
        {
            return await this.dbContext.QueryAsync<DestinoQuery, Cedi, DestinoUbicacion,
                SubZona, DestinoQuery>("[dbo].[Evo_DestinoListar]", 
                map: (destino, cedi, destinoUbicacion, subzona) => {
                    destino.Cedi = cedi;
                    destino.DestinoUbicacion = destinoUbicacion;
                    destino.SubZona = subzona;
                    return destino;
                },
                splitOn: "vcdescripcion,lat,IdSubZona",
                parameters: parameters);
        }

        public async Task<IEnumerable<Destino>> GetWithoutDistanceAsync(int idZone)
        {
            var parameters = new
            {
                idzona = idZone
            };
            return await this.dbContext.QueryAsync<Destino>("[dbo].[Evo_DestinoListarSinDistancias]", parameters);
        }
  
        public async Task<IEnumerable<RelUso>> GetDestinationProductsListAsync(int idDestination)
        {                    
            var parameters = new
            {
                destino = idDestination
            };
            return await this.dbContext.QueryAsync<RelUso, Destino, Producto, RelUso>
                ("[dbo].[Evo_DestinoListarProductos]",
                map: (reluso, destino, producto) => {
                    reluso.Destino = destino;
                    reluso.Producto = producto;
                    return reluso;
                },
                splitOn: "IdDestino, IdProducto",
                parameters);
        }

        public async Task<IEnumerable<Producto>> GetProductsByZoneAsync(int idZone, int idDestination, string search)
        {
            var parameters = new
            {
                destino = idDestination,
                idZona = idZone,
                busqueda = search

            };
            return await this.dbContext.QueryAsync<Producto>("[dbo].[Evo_DestinoListarProductosPorZona]", parameters);
        }

        public async Task<int> StoreRelationProductAsync(RelDestinationProductInsertDto data)
        {
            try
            {
                var parameters = new
                {
                    idProducto = data.IdProducto,
                    idDestino = data.IdDestino,
                    iPorcMeta = data.IPorcMeta,
                    bAutoAbasto = data.BAutoAbasto,
                    nCapacidadMaxima = data.NCapacidadMaxima,
                    nCapacidadMinima = data.NCapacidadMinima,
                    iInventarioMultiplo = data.IInventarioMultiplo,
                    venta = data.Venta,
                    vcUsuario = data.Vc20usuario,
                    nOfertaEntrega = data.NOfertaEntrega,
                    bDemanda = data.BDemanda
                };
                return await this.dbContext.ExecuteAsync("[dbo].[Evo_DestinoInsertarProducto]", parameters: parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> UpdateRelationProductAsync(RelDestinationProductInsertDto data, int idRelUse)
        {
            try
            {
                var parameters = new
                {
                    idUso = idRelUse,
                    IPorcMeta = data.IPorcMeta,
                    BAutoAbasto = data.BAutoAbasto,
                    NCapacidadMaxima = data.NCapacidadMaxima,
                    NCapacidadMinima = data.NCapacidadMinima,
                    IInventarioMultiplo = data.IInventarioMultiplo,
                    Venta = data.Venta,
                    VcUsuario = data.Vc20usuario,
                    NOfertaEntrega = data.NOfertaEntrega,
                    BDemanda = data.BDemanda
                };
                return await this.dbContext.ExecuteAsync("[dbo].[DestinoProductoActualiza]", parameters: parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> DeleteRelationProductAsync(int idRelUse)
        {
            try
            {
                var parameters = new
                {
                    registro = idRelUse,
                };
                return await this.dbContext.ExecuteAsync("[dbo].[Evo_DestinoEliminarProducto]", parameters: parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<RelDestinoInventario>> GetRelationDestinationInventoryAsync(int idDestination)
        {                    
            var parameters = new
            {
                idDestino = idDestination,
            };
            return await this.dbContext.QueryAsync<RelDestinoInventario>("[dbo].[Evo_RelDestinoInventarioListar]", parameters);
        }

        public async Task<int> InsertAsync(DestinationInsertDto data)
        {
            try 
            {
                var parameters = new {
                    nombre = data.Nombre,
                    zona = data.Zona,
                    manana = data.Manana,
                    tarde = data.Tarde,
                    noche = data.Noche,
                    idsubzona = data.Idsubzona,
                    clavesicadi = data.Clavesicadi,
                    ClaveSit = data.ClaveSit,
                    AutoAbasto = data.AutoAbasto,
                    Pronostico = data.Pronostico,
                    venta = data.Venta,
                    vc20usuario = data.Vc20usuario,
                    vc12claveSAP = data.Vc12claveSAP
                };
                return await this.dbContext.ExecuteScalarAsync<int>("[dbo].[Evo_DestinoInsertar]", parameters: parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> InsertInventoryProductAsync(RelInventoryInsertProductDto data, int idDestination)
        {
            try
            {
                var parameters = new
                {
                    idDestino = idDestination,
                    vcNombre = data.Nombre,
                    iclave = data.Clave,
                    vcUsuario = data.Vc20usuario
                };
                // exec RelDestinoInventarioInsertar @idDestino=1760250,@vcNombre='producto nuevo 4',@iClave=123123,@vcUsuario='jrangelmn'
                return await this.dbContext.ExecuteAsync("[dbo].[RelDestinoInventarioInsertar]", parameters: parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

         public async Task<int> UpdateInventoryProductAsync(RelInventoryInsertProductDto data, int idDestination, int idRelation)
        {
            try
            {
                var parameters = new
                {
                    idDestino = idDestination,
                    idRelacion = idRelation,
                    vcNombre = data.Nombre,
                    iclave = data.Clave,
                };
                // exec RelDestinoInventarioInsertar @idDestino=1760250,@vcNombre='producto nuevo 4',@iClave=123123,@vcUsuario='jrangelmn'
                return await this.dbContext.ExecuteAsync("[dbo].[RelDestinoInventarioActualizar]", parameters: parameters);
            }
            catch (Exception ex)
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
                    vc20Clave = "Destinos2",
                    vc255Valor = value255
                };

                return await this.dbContext.ExecuteAsync("[dbo].[TransaccionInfoEstablecerUnoAUno]", parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> InsertRestrictionAsync(DestinationRestrictionDto model)
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

        public async Task<int> UpdateAsync(int idDestino, DestinationInsertDto data)
        {
            try 
            {
                var parameters = new {
                    idDestino = idDestino,
                    iManana = data.Manana,
                    iTarde = data.Tarde,
                    iNoche = data.Noche,
                    idsubzona = data.Idsubzona,
                    AutoAbasto = data.AutoAbasto,
                    Pronostico = data.Pronostico,
                    vc4cedis = data.Vc4cedis,
                    vc20usuario = data.Vc20usuario,
                    vc12claveSAP = data.Vc12claveSAP,
                    vc25NombreCorto = data.Vc25NombreCorto
                };
                return await this.dbContext.ExecuteAsync("[dbo].[DestinoActualizar]", parameters: parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<Destino>> GetByZoneAllAsync(int idZona, bool isagreement, string word)
        {
            var parameters = new
            {
                idzona = idZona,
                esRestriccion = isagreement,
                vcPalabra = word
            };
            return await this.dbContext.QueryAsync<Destino>("[dbo].[Evo_RestriccionListarDestinosPorZona]", parameters);
        }

        public async Task<KeyValuePair<List<Destino>, int>> GetRestrictionAsync(int idZona, long tid, int pageNumber, int pageSize, string search)
        {
            var parameters = new
            {
                zona = idZona,
                TID = tid,
                Clave = "Destinos",
                pageNumber,
                pageSize,
                vcPalabra = search
            };
            List<Destino> userCollection = null;
            int totalCount = 0;

            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_RestriccionDestinoListarDisponibles]", parameters: parameters))
            {
                userCollection = (await multiple.ReadAsync<Destino>()).ToList();
                totalCount = multiple.ReadSingle<int>();
            }

            return new KeyValuePair<List<Destino>, int>(userCollection, totalCount);
        }

        public async Task<KeyValuePair<List<Destino>, int>> GetRestrictionOneToOneAsync(int idZona, long tid, int pageNumber, int pageSize, string search)
        {
            var parameters = new
            {
                zona = idZona,
                TID = tid,
                Clave = "Destinos2",
                pageNumber,
                pageSize,
                vcPalabra = search
            };
            List<Destino> userCollection = null;
            int totalCount = 0;

            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_RestriccionDestinoListarDisponibles]", parameters: parameters))
            {
                userCollection = (await multiple.ReadAsync<Destino>()).ToList();
                totalCount = multiple.ReadSingle<int>();
            }

            return new KeyValuePair<List<Destino>, int>(userCollection, totalCount);
        }

        public async Task<IEnumerable<Destino>> GetRestrictionInvolvedAsync(int idZona, long tid)
        {
            var parameters = new
            {
                zona = idZona,
                TID = tid,
                Clave = "Destinos"
            };
            return await this.dbContext.QueryAsync<Destino>("[dbo].[Evo_RestriccionDestinoListarInvolucrados]", parameters);
        }

        public async Task<IEnumerable<Destino>> GetRestrictionInvolvedOneToOneAsync(int idZona, long tid)
        {
            var parameters = new
            {
                zona = idZona,
                TID = tid,
                Clave = "Destinos2"
            };
            return await this.dbContext.QueryAsync<Destino>("[dbo].[Evo_RestriccionDestinoListarInvolucrados]", parameters);
        }

        public async Task<IEnumerable<Destino>> GetDestinationClientListAsync(int idZone)
        {
            var parameters = new
            {
                zona = idZone
            };
            return await this.dbContext.QueryAsync<Destino>("[dbo].[Evo_DestinoClienteListarNuevos]", parameters);
        }

        public async Task<IEnumerable<Destino>> GetDistanceNewListAsync(int idZone)
        {
            var parameters = new
            {
                idzona = idZone
            };
            return await this.dbContext.QueryAsync<Destino>("[dbo].[Evo_OrigenListarNuevasDistancias]", parameters);
        }

        public async Task<IEnumerable<Destino>> getDestinationDistanceListAsync(PaginationQuery filter, int idZone)
        {
            var parameters = new
            {
                zona = idZone,
                nombre = filter.Search,
                pageNumber = filter.PageNumber,
                pageSize = filter.PageSize
            };
            return await this.dbContext.QueryAsync<Destino>("[dbo].[Evo_DestinoClienteListar]", parameters);
        }


    }
}