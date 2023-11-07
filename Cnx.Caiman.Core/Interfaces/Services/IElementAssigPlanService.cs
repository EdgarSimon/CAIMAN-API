using Cnx.Caiman.Core.DTOs.ElementAssigPlan;
using Cemex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IElementAssigPlanService
    {
        Task<ApiResponse<List<ElementPlanStockDto>>> ListStockAsync(int idzone, int pivote, int idphoto);
        Task<ApiResponse<List<ElementPlanOfferDto>>> ListOfferAsync(int idzone, int pivote, int idphoto);
        Task<ApiResponse<List<ElementPlanTransportDto>>> ListTransportAsync(int idzone, int pivote, int idphoto);
        Task<ApiResponse<List<ElementPlanDemandDto>>> ListDemandAsync(int idzone, int pivote, int idphoto);
        Task<ApiResponse<List<KeyValuePair<int, string>>>> ListPhotoAsync(int element, int idzone, int idplanassig);
        Task<ApiResponse<List<KeyValuePair<int, string>>>> DayPhotoListAsync(int element, int idzone, DateTime date);
        Task<ApiResponse<KeyValuePair<int, int>>> SearchPhotoAsync(int element, int idzone, int idplanassig);
        Task UpdateAsync(ElementPlanUpdateDto model);
    }
}
