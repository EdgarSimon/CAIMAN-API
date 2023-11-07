using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Offer;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.Oferta;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class TransportOfferRepository : ITransportOfferRepository
    {
        private readonly IDbContext dbContext;

        public TransportOfferRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<OfertaTransporteResult>> GetAsync(Object parameters)
        {
            return await this.dbContext.QueryAsync<OfertaTransporteResult>("dbo.Evo_OfertaTransporteListar", parameters);
        }

        public async Task<int> UpdateAsync(TransportOfferInsertDto data, int idTransportOffer)
        {
            try
            {
                var parameters = new
                {
                    idOfertaTransporte = idTransportOffer,
                    Oferta = data.Oferta,
                    vcObservaciones = data.VcObservaciones,
                    usuario = data.Vc20usuario,
                    fecha = data.Fecha.ToString()
                };
                return await this.dbContext.ExecuteAsync("dbo.OfertaTransporteActualizar", parameters);
            }
            catch(Exception ex)
            { 
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<int> ShowPhotoAsync(int idzone, DateTime date)
        {
            var parameters = new
            {
                dtfecha = date.ToString("yyyy-MM-dd"),
                idzona = idzone
            };
            var result = await this.dbContext.QueryAsync<int>("[dbo].[CrearFotoOfertaTransporteMostrar]", parameters: parameters);

            return result.FirstOrDefault();
        }
    }
}