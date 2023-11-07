using Cnx.Caiman.Core.DTOs.Offer;
using Cnx.Caiman.Core.Entities.QueryEntities.Oferta;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IOfferRepository
    {
        Task<bool> GetOfferAsync(int idZone);
        Task<int> ShowPhotoAsync(int idzone, DateTime date);
        Task<bool> OrdenVerifyCapacityAsync(int idzone, DateTime date, int capacity);
        Task<ValidaOrdenResult> CreatePhotoAsync(int idzone, DateTime date, int capacity);
        Task<dynamic> GetOfferListAsyc(Object parameters);
        Task<dynamic> GetOfferList2Asyc(Object parameters);
        Task<KeyValuePair<InfoCapacidadesResult, List<InfoCapacidadesDetalleResult>>> InfoCapacityAsync(int idzone, DateTime date);
        Task<int> UpdateOfferAsync(OfferUpdateDto model);
        Task<int> InsertOfferAsync(OfferInsertDto model, int element = 1);
        Task<int> UpdateOfferTwoAsync(OfferUpdateTwoDto model);
    }
}
