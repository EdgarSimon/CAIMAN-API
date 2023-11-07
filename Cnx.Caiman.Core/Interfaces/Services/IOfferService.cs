using Cnx.Caiman.Core.DTOs.Offer;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IOfferService
    {
        Task<ApiResponse<bool>> GetOfferAsync(int idzone);
        Task<ApiResponse<ValidationDto>> ShowPhotoAsync(int idzone, DateTime date);
        Task<ApiResponse<IEnumerable<ListOfferDto>>> ListSearchAsync(FilterGrid filter);
        Task<ApiResponse<IEnumerable<ListOfferDto>>> ListSearch2Async(FilterGrid filter);
        Task<ApiResponse<InfoCapacityDto>> InfoCapacityAsync(OfferDto model);
        Task UpdateOfferAsync(OfferUpdateDto model);
        Task InsertOfferAsync(OfferInsertDto model);
        Task UpdateOfferTwoAsync(OfferUpdateTwoDto model);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
        Task<ApiResponse<string>> Export2Async(FilterGrid filter);
    }
}