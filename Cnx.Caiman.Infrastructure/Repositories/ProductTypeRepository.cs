using Cnx.Caiman.Core.DTOs.ProductType;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class ProductTypeRepository: IProductTypeRepository
    {
        private readonly IDbContext dbContext;

        public ProductTypeRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TipoProducto>> GetAsync(int idZone)
        {
            var parameters = new
            {
                idzona = idZone
            };
            return await this.dbContext.QueryAsync<TipoProducto>("[dbo].[Evo_TiposProductoListar]", parameters);
        }

        public async Task<int> UpdateAsync(ProductTypeUpdateDto model)
        {
            try
            {
                var parameters = new
                {
                    idtipoproducto = model.IdTipoProducto,
                    tipoproducto = model.vcTipoProducto,
                    usuario = model.vc20Usuario
                };
                return await this.dbContext.ExecuteAsync("[dbo].[TipoProductoActualizar]", parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> InsertAsync(ProductTypeInsertDto model)
        {
            try
            {
                var parameters = new
                {
                    idzona = model.IdZona,
                    tipoproducto = model.VcTipoProducto,
                    usuario = model.Vc20Usuario
                };
                return await this.dbContext.ExecuteAsync("[dbo].[TipoProductoInsertar]", parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> DeleteAsync(int idTipoProducto, string Vc20Usuario)
        {
            try
            {
                var parameters = new
                {
                    idtipoproducto = idTipoProducto,
                    usuario = Vc20Usuario,
                };
                return await this.dbContext.ExecuteAsync("[dbo].[TipoProductoEliminar]", parameters);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
