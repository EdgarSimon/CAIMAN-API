using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.ValidacionesPrevias;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class PrevValidationsRepository: IPrevValidationsRepository
    {
        private readonly IDbContext dbContext;

        public PrevValidationsRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ValidacionesPreviasListar>> GetAsync(int IdPlanAssig, string element)
        {

            var parameters = new
            {
                idplanasignacion = IdPlanAssig,
                elemento = element
            };
            return await this.dbContext.QueryAsync<ValidacionesPreviasListar>("[dbo].[Evo_ValidacionesPreviasListar]", parameters: parameters);
        }

        public async Task<List<KeyValuePair<string, int>>> GetDvSEAsync(int IdPlanAssig)
        {
            var result = await this.dbContext.QueryAsync<KeyValuePair<string, int>>("[dbo].[Evo_ValidacionesPreviasListarDvsE]", parameters: new { idplanasignacion = IdPlanAssig });

            return result.ToList();
        }

        public async Task<List<PlanAsignacion>> GetOTvsDAsync(int IdPlanAssig)
        {
            var result = await this.dbContext.QueryAsync<PlanAsignacion>("[dbo].[Evo_ValidacionesPreviasListarOTvsD]", parameters: new { idplanasignacion = IdPlanAssig });

            return result.ToList();
        }
    }
}
