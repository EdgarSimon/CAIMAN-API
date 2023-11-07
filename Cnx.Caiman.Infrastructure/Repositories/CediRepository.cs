using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.Filters;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Extension;
using Cemex.Core.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class CediRepository : ICediRepository
    {
        private readonly IDbContext dbContext;

        public CediRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> DeleteAsync(string prmVcSAP, string prmUsuario)
        {
            try
            {
                var parameters = new
                {
                    prmUsuario = prmUsuario,
                    prmVcSAP= prmVcSAP
                };
                return await this.dbContext.ExecuteAsync("[dbo].[spCedisEliminar]", parameters);
                
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<Cedi>> GetAsync(Object parameters)
        {
            return await this.dbContext.QueryAsync<Cedi>("[dbo].[Evo_spCedisListar]", parameters: parameters);
        }

        public async Task<int> InsertAsync(string prmVcSAP, string prmNombre, string prmUsuario)
        {
            try
            {
                var parameters = new
                {
                    prmVcSAP= prmVcSAP,
                    prmNombre = prmNombre,
                    prmUsuario = prmUsuario
                };
                return await this.dbContext.ExecuteScalarAsync<int>("[dbo].[Evo_spCedisInsertar]", parameters);

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> UpdateAsync(string prmVcSAP, string prmNombre, string prmUsuario)
        {
            try
            {
                var parameters = new
                {
                    prmVcSAP= prmVcSAP,
                    prmNombre = prmNombre,
                    prmUsuario = prmUsuario
                };
                return await this.dbContext.ExecuteAsync("[dbo].[spCedisActualizar]", parameters);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
