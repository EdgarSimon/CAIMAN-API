using Cnx.Caiman.Core.DTOs.Product;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly IDbContext dbContext;


        public ProductRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Producto>> GetByZoneAllAsync(int idZona,bool isagreement, string search)
        {
            var parameters = new
            {
                idzona = idZona,
                esRestriccion = isagreement,
                vcPalabra = search
            };
            return await this.dbContext.QueryAsync<Producto>("[dbo].[Evo_RestriccionListarProductosPorZona]", parameters);
        }

        public async Task<IEnumerable<Producto>> GetRestrictionAsync(int idZona, long tid, string search)
        {
            var parameters = new { zona = idZona, TID = tid, Clave = "Productos", palabra = search };
            return await this.dbContext.QueryAsync<Producto>("[dbo].[Evo_RestriccionProductoListarDisponibles]", parameters);
        }

        public async Task<dynamic> GetProductDestinationByIdAsync(int idDestination, int pageNumber, int pageSize)
        {
            var parameters = new { 
                destino = idDestination,
                pageNumber = pageNumber,
                pageSize = pageSize
            };
            IEnumerable<Producto> products = null;
            int totalCount = 0;
            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_DestinoListarProductosPorId]", parameters: parameters))
            {
                products = await multiple.ReadAsync<Producto>();
                totalCount = multiple.ReadSingle<int>();
            }
            return new
            { 
                records = products,
                count = totalCount
            };
        }

        public async Task<IEnumerable<Producto>> GetRestrictionOneToOneAsync(int idZona, long tid)
        {
            var parameters = new { zona = idZona, TID = tid, Clave = "Productos2" };
            return await this.dbContext.QueryAsync<Producto>("[dbo].[Evo_RestriccionProductoListarDisponibles]", parameters);
        }

        public async Task<IEnumerable<Producto>> GetRestrictionInvolvedAsync(int idZona, long tid)
        {
            var parameters = new { zona = idZona, TID = tid, Clave = "Productos" };
            return await this.dbContext.QueryAsync<Producto>("[dbo].[Evo_RestriccionProductoListarInvolucrados]", parameters);
        }

        public async Task<IEnumerable<Producto>> GetRestrictionInvolvedOneToOneAsync(int idZona, long tid)
        {
            var parameters = new { zona = idZona, TID = tid, Clave = "Productos2" };
            return await this.dbContext.QueryAsync<Producto>("[dbo].[Evo_RestriccionProductoListarInvolucrados]", parameters);
        }

        public async Task<int> InsertRestrictionOneToOneAsync(int tid, string value255)
        {
            try
            {
                var parameters = new { TID = tid, vc20Clave = "Productos2", vc255Valor = value255 };
                return await this.dbContext.ExecuteAsync("[dbo].[TransaccionInfoEstablecerUnoAUno]", parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<IEnumerable<Producto>> GetProductsByOriginAsync(int idOrigin)
        {
            var parameters = new
            {
                origen = idOrigin,
            };
            return await this.dbContext.QueryAsync<Producto>("[dbo].[Evo_OrigenListarProductos]", parameters: parameters);
        }

        public async Task<IEnumerable<Producto>> GetAsync(Object parameters)
        {
            return await this.dbContext.QueryAsync<Producto, TipoProducto,
                Producto>("[dbo].[Evo_ProductoListar]", 
                map: (producto, tipoProducto) =>
                {
                    producto.TipoProducto = tipoProducto;
                    return producto;
                },
                splitOn: "IdTipoProducto",
                parameters: parameters);
        }

        public async Task<IEnumerable<TipoProducto>> GetTypesProductsAsync(int idZona, bool? aplyAll)
        {
            var parameters = new
            {
                idzona = idZona,
                btodos = aplyAll
            };
            return await this.dbContext.QueryAsync<TipoProducto>("[dbo].[Evo_TiposProductoListarP]", parameters: parameters);
        }

        public async Task<int> UpdateAsync(int idProduct, ProductInsertDto data)
        {
            try 
            {
                var parameters = new {
                    idProducto = idProduct,
                    vcProducto = data.VcNombre,
                    iTipo = data.ITipo,
                    vcClave = data.VcClave,
                    iClaveSit = data.IClaveSit,
                    vc20usuario = data.Vc20usuario,
                    vc25NombreCorto = data.Vc25NombreCorto
                };
                return await this.dbContext.ExecuteAsync("[dbo].[ProductoActualizar]", parameters: parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> InsertRestrictionAsync(ProductRestrictionDto model)
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
        
        public async Task<int> UpdateRelationMonthlyAsync(int idProduct, ProductoRelationMonthlyUpdateDto data)
        {
            try 
            {
                var parameters = new {
                    idProducto = idProduct,
                    iAcceso = data.IAcceso,
                    idPagina = data.IdPagina,
                    dtFecha = data.DtFecha,
                    vcUsuario = data.VcUsuario
                };
                return await this.dbContext.ExecuteAsync("[dbo].[ProductoActualizarMensualRel]", parameters: parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> DeleteAsync(string idProduct, string user)
        {
            try 
            {
                var parameters = new {
                    idProducto = idProduct,
                    vc20usuario = user
                };
                return await this.dbContext.ExecuteAsync("[dbo].[Evo_ProductoEliminar]", parameters: parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> InsertAsync(ProductInsertDto data)
        {
            try 
            {
                var parameters = new {
                    vcNombre = data.VcNombre,
                    iTipo = data.ITipo,
                    idZona = data.IdZona,
                    vcClave = data.VcClave,
                    iClaveSit = data.IClaveSit,
                    vc20usuario = data.Vc20usuario
                };
                var response = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[Evo_ProductoInsertar]", parameters: parameters);
                return response;
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> InsertMonthlyAsync(ProductInsertDto data)
        {
            try 
            {
                var parameters = new {
                    vcNombre = data.VcNombre,
                    tipo = data.ITipo,
                    idZona = data.IdZona,
                    clave = data.VcClave,
                    claveSit = data.IClaveSit,
                    vc20usuario = data.Vc20usuario,
                    dtfecha = data.Dtfecha?.ToString()
                };
                return await this.dbContext.ExecuteAsync("[dbo].[ProductoInsertarMensual]", parameters: parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> InsertShortAsync(ProductShortInsertDto data)
        {
            try 
            {
                var parameters = new {
                    vcNombre = data.VcNombre,
                    idZona = data.IdZona,
                    IdProdGral = data.IdProdGral,
                    vc20usuario = data.Vc20Usuario
                };
                var response = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[Evo_ProductoInsertar2]", parameters: parameters);
                return response;
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public async Task<dynamic> GetProductDistanceByIdAsync(int idDestination, PaginationQuery filter)
        {
            var parameters = new
            {
                destino = idDestination,
                nombre = filter.Search,
                pageNumber = filter.PageNumber,
                pageSize = filter.PageSize
            };
            IEnumerable<Producto> products = null;
            int totalCount = 0;
            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_DestinoProductoCombo]", parameters: parameters))
            {
                products = await multiple.ReadAsync<Producto>();
                totalCount = multiple.ReadSingle<int>();
            }
            return new
            {
                records = products,
                count = totalCount
            };
        }
    }
}
