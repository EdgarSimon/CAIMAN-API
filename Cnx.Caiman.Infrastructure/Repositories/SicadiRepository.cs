using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class SicadiRepository: ISicadiRepository
    {
        private readonly IDbContext dbContext;

        public SicadiRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetSicadiAsync(int idzone)
        {

            var result = await this.dbContext.QueryAsync<KeyValuePair<string, string>>("[dbo].[Evo_InfoTraerDeSicadi]",
                                                                                                parameters: new { idzona = idzone, elemento = 4 });

            return result;
        }

        public async Task<int> UpdateAsync(int idzone)
        {
            try
            {
                return await this.dbContext.ExecuteAsync("[dbo].[EnlaceActualizarTarifasNuevosDestinos]", parameters: new { idzona = idzone });
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
