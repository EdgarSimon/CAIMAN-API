using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.CostOverrun;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class CostOverrunRepository : ICostOverrunRepository
    {
        private readonly IDbContext dbContext;

        public CostOverrunRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TipoSobreconsumo>> GetTypesOverrunAsync()
        {
            return await this.dbContext.QueryAsync<TipoSobreconsumo>("[dbo].[Evo_TipoSCListar]", parameters: null);
        }
    }
}
