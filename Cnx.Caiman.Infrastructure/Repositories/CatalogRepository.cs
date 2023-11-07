using Cnx.Caiman.Core.Entities.QueryEntities.Catalog;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly IDbContext dbContext;

        public CatalogRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<dynamic> ListCatalogAsync(Object parameters)
        {
            IEnumerable<CatalogQuerys> shipperCollaction = null;
            int totalCount = 0;
            using (var multiple = this.dbContext.QueryMultiple("[dbo].[Evo_spBuscaCatalogo]", parameters: parameters))
            {
                shipperCollaction = await multiple.ReadAsync<CatalogQuerys>();
                totalCount = multiple.ReadSingle<int>();
            }
            return new
            {
                records = shipperCollaction,
                count = totalCount
            };
        }
    }
}
