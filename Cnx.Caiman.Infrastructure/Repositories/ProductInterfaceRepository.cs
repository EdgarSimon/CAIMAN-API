using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.ProductInterface;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class ProductInterfaceRepository: IProductInterfaceRepository
    {
        private readonly IDbContext dbContext;


        public ProductInterfaceRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> DeleteAsync(string vcsap)
        {
            try
            {
                var parameters = new {
                    vcsap = vcsap
                };
                return await this.dbContext.ExecuteAsync("[dbo].[EVO_spDeleteProductoInterfaz]", parameters: parameters);
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<ProductoInterfaz>> GetAsync(object parameters)
        {
            return await this.dbContext.QueryAsync<ProductoInterfaz>("[dbo].[EVO_spProductoInterfazListar]", parameters: parameters);
        }

        public async Task<int> InsertAsync(ProductInterfaceInsertDto parameters)
        {
            try
            {
                return await this.dbContext.ExecuteAsync("[dbo].[EVO_spInsertarProductoInterfaz]", parameters: (Object)parameters);
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> UpdateAsync(ProductInterfaceInsertDto data)
        {
            try
            {
                var parameters = new {
                    VcSap = data.VcSap,
                    vcNombre900 = data.VcNombre900,
                    IdProd55 = data.IdProd55,
                    VcNombre55 = data.VcNombre55,
                    NPesoVolumetrico = data.NPesoVolumetrico,
                    Vc20Usuario = data.Vc20Usuario,
                    VcBorrar = data.VcBorrar,
                    Procesado = data.Procesado,
                    BProcesado = data.BProcesado,
                };
                return await this.dbContext.ExecuteAsync("[dbo].[EVO_spActualizarProductoInterfaz]", parameters: parameters);
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
