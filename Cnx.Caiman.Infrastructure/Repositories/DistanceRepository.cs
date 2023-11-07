using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Distance;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.TariffDestinationProduct;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class DistanceRepository : IDistanceRepository
    {
        private readonly IDbContext dbContext;

        public DistanceRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<TarifaConsultarDestinoProducto>> TariffConsultOriginProductAsync(Object parameters)
        {
            return await this.dbContext.QueryAsync<TarifaConsultarDestinoProducto>("[dbo].[Evo_TarifaConsultarOrigenProducto]", parameters);
        }

        public async Task<IEnumerable<TarifaConsultarDestinoProducto>> TariffConsultDestinationProductAsync(Object parameters)
        {
            return await this.dbContext.QueryAsync<TarifaConsultarDestinoProducto>("[dbo].[Evo_TarifaConsultarDestinoProducto]", parameters);
        }

        public async Task<int> UpdateAsync(DistanceUpdateDto data)
        {
            try 
            {
                return await this.dbContext.ExecuteAsync("[dbo].[TarifaActualizaOrigenDestinoProducto]", (Object)data);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}