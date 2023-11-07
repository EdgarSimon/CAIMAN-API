using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Offer;
using Cnx.Caiman.Core.Entities;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface ITransportOfferService
    {
        Task<int> UpdateAsync(TransportOfferInsertDto data, int idTransportOffer);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
        Task<ApiResponse<IEnumerable<TransportOfferDto>>> GetAsync(FilterGrid filter);
        Task<ApiResponse<ValidationDto>> ShowPhotoAsync(int idzone, DateTime date);
    }
}