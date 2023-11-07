using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Origin;
using Cnx.Caiman.Core.DTOs.Product;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    internal class RelProductionRepository : IRelProductionRepository
    {
        private readonly IDbContext dbContext;

        public RelProductionRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<RelProduccion>> GetAsync(int idOrigin)
        {
            var parameters = new {
                origen = idOrigin
            };
            return await this.dbContext.QueryAsync<RelProduccion, Producto, 
                RelProduccion>("[dbo].[Evo_ProduccionListar]",
                map: (relProduccion, production) =>
                {
                    relProduccion.Producto = production;
                    return relProduccion;
                },
                splitOn: "IdProducto",
                parameters: parameters);
        }

        public async Task<IEnumerable<Producto>> GetProductosByZoneAsync(int idOrigin, int idZone, string search)
        {
            var parameters = new {
                origen = idOrigin,
                idZona = idZone,
                busqueda = search
            };
            return await this.dbContext.QueryAsync<Producto>("[dbo].[Evo_OrigenListarProductosPorZona]",
                parameters: parameters);
        }

        public async Task<int> InsertProductOriginAsync(RelOriginProductInsertDto data)
        {
            try
            {
                var parameters = new {
                    idProducto = data.IdProducto,
                    idOrigen = data.IdOrigen,
                    precio = data.Precio,
                    vc20Usuario = data.Vc20Usuario
                };
                var response = await this.dbContext.ExecuteAsync("[dbo].[Evo_OrigenInsertarProducto]",
                    parameters: parameters);

                // await this.dbContext.ExecuteAsync("[dbo].[Evo_ProcesaInterfazContratos]",
                //     parameters: null);
                return response;
                
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> UpdateProductOriginAsync(RelOriginProductInsertDto data, int idRel)
        {
            try
            {
                var parameters = new {
                producto = idRel,
                precio = data.Precio,
                vc20Usuario = data.Vc20Usuario
                };
                return await this.dbContext.ExecuteAsync("[dbo].[OrigenActualizarProducto]",
                    parameters: parameters);
                    
                }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> DeleteProductOriginAsync(int idRel)
        {
            try
            {
                var parameters = new
                {
                    registro = idRel,
                };
                return await this.dbContext.ExecuteAsync("[dbo].[OrigenEliminarProducto]",
                    parameters: parameters);
                
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public async Task<IEnumerable<RelProduccion>> GetValuesOriginAsync(Object parameters)
        {
            return await this.dbContext.QueryAsync<RelProduccion, Producto, 
                Origen, RelProduccion>("[dbo].[Evo_OrigenListarValores]",
                map: (relProduccion, production, origen) =>
                {
                    relProduccion.Producto = production;
                    relProduccion.Origen = origen;
                    return relProduccion;
                },
                splitOn: "IdProducto, IdOrigen",
                parameters: parameters);
        }

        public async Task<int> UpdateCostProductOverrunAsync(CostProductOverrunUpdateDto data)
        {
            try 
            {
                return await this.dbContext.ExecuteAsync("[dbo].[OrigenActualizarProductoSobrecosto]", (Object)data);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
