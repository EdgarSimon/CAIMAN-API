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
    public class ProductInterfaceExceptionRepository: IProductInterfaceExceptionRepository
    {
        private readonly IDbContext dbContext;


        public ProductInterfaceExceptionRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductoInterfazExcepcion>> GetAsync(object parameters)
        {
            return await this.dbContext.QueryAsync<ProductoInterfazExcepcion>("[dbo].[EVO_spListaProductoInterfazExcepcion]", parameters: parameters);
        }

        public async Task<int> InsertAsync(ProductInterfaceExceptionInsertDto parameters)
        {
            return await this.dbContext.ExecuteAsync("[dbo].[EVO_InsertarProductoInterfazExcepcion]", parameters: (Object)parameters);
        }

        public async Task<int> UpdateAsync(ProductInterfaceExceptionInsertDto parameters)
        {
            return await this.dbContext.ExecuteAsync("[dbo].[EVO_ActualizarProductoInterfazExcepcion]", parameters: (Object)parameters);
        }

        public async Task<int> DeleteAsync(string vcSap)
        {
            var parameters = new {
                vcsap = vcSap
            };
            return await this.dbContext.ExecuteAsync("[dbo].[EVO_EliminarProductoInterfazExcepcion]", parameters: (Object)parameters);
        }
    }
}
