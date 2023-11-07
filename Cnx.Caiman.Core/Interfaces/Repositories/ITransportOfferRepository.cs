using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Offer;
using Cnx.Caiman.Core.Entities.QueryEntities.Oferta;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface ITransportOfferRepository
    {
        Task<int> UpdateAsync(TransportOfferInsertDto data, int idTransportOffer);
        Task<IEnumerable<OfertaTransporteResult>> GetAsync(Object parameters);
        Task<int> ShowPhotoAsync(int idzone, DateTime date);

    }
}