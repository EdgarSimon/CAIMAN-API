using Cnx.Caiman.Core.DTOs.SubZone;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class SubZoneRepository: ISubZoneRepository
    {
        private readonly IDbContext dbContext;

        public SubZoneRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<SubZona>> GetAsync(int idzone)
        {
            var parameters = new { zona = idzone };

            var result = await this.dbContext.QueryAsync<SubZona>("[dbo].[Evo_SubZonaListar]", parameters: parameters);

            return result.ToList();
        }

        public async Task<IEnumerable<SubZona>> GetAllByZonaAsync(int idzone)
        {
            var parameters = new { zona = idzone };
            return await this.dbContext.QueryAsync<SubZona>("[dbo].[Evo_SubZonaListarD]", parameters: parameters);
        }

        public async Task<int> PutAsync(SubZoneInsertDto model)
        {
            var parameters = new
            {
                idzona = model.IdZone,
                subzona = model.Vc50Nombre,
                usuario = model.Vc20Usuario
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[SubZonaInsertar]", parameters: parameters);

            return result;
        }

        public async Task<int> PostAsync(SubZoneUpdateDto model)
        {
            var parameters = new
            {
                idsubzona = model.IdSubZone,
                subzona = model.Vc50Nombre,
                usuario = model.Vc20Usuario
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[SubzonaActualizar]", parameters: parameters);

            return result;
        }

        public async Task<int> DeleteAsync(int idsubzone, string user)
        {
            var parameters = new
            {
                idsubzona = idsubzone,
                usuario = user
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[SubZonaEliminar]", parameters: parameters);

            return result;
        }
        public async Task<IEnumerable<KeyValuePair<int, string>>> GetByZoneOptionAllAsync(int idzone)
        {
            var parameters = new { elemento = "sz", idzona = idzone };
            return await this.dbContext.QueryAsync<KeyValuePair<int, string>>("[dbo].[Evo_FiltroListarElementos]", parameters: parameters);
        }
    }
}
