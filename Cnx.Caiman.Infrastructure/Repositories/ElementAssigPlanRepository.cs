using Cnx.Caiman.Core.DTOs.ElementAssigPlan;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class ElementAssigPlanRepository: IElementAssigPlanRepository
    {
        private readonly IDbContext dbContext;

        public ElementAssigPlanRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<dynamic>> ListAsync(int element, int idzone, int pivote, int idphoto)
        {
            var parameters = new
            {
                elemento = element,
                idzona = idzone,
                pivote  = pivote,
                idfoto  = idphoto
            };

            var result = await this.dbContext.QueryAsync<dynamic>("[dbo].[Evo_PlanAsignacionListarElementos]", parameters: parameters);

            return result.ToList();
        }

        public async Task<List<KeyValuePair<int, string>>> ListPhotoAsync(int element, int idzone, int idplanassig)
        {
            var parameters = new
            {
                elemento = element,
                idzona = idzone,
                idplanasignacion = idplanassig,
            };

            var result = await this.dbContext.QueryAsync<KeyValuePair<int, string>>("[dbo].[Evo_FotoListar]", parameters: parameters);

            return result.ToList();
        }

        public async Task<KeyValuePair<int, int>> SearchPhotoAsync(int element, int idzone, int idplanassig)
        {
            var parameters = new
            {
                elemento = element,
                idzona = idzone,
                idplanasignacion = idplanassig,
            };

            var result = await this.dbContext.QueryAsync<KeyValuePair<int, int>>("[dbo].[Evo_FotoBuscar]", parameters: parameters);

            return result.FirstOrDefault();
        }

        public async Task<int> UpdateAsync(ElementPlanUpdateDto model)
        {
            var parameters = new
            {
                elemento = model.Elemento,
                idplanasignacion = model.IdPlanAsignacion,
                index = model.Id,
                vc20Usuario = model.Vc20Usuario
            };

            var result = await this.dbContext.ExecuteScalarAsync<int>("[dbo].[Evo_PlanAsignacionActualizarElementos]", parameters: parameters);

            return result;
        }

        public async Task<List<KeyValuePair<int, string>>> DayPhotoListAsync(int element, int idzone, DateTime date)
        {
            var parameters = new
            {
                elemento = element,
                idzona = idzone,
                fecha = date.ToString("yyyy-MM-dd"),
            };

            var result = await this.dbContext.QueryAsync<KeyValuePair<int, string>>("[dbo].[Evo_FotoDiaListar]", parameters: parameters);

            return result.ToList();
        }
    }
}
