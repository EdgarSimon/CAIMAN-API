using Cnx.Caiman.Core.DTOs.Concret;
using Cnx.Caiman.Core.DTOs.Offer;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface IConcretService
    {
        Task<ApiResponse<IEnumerable<DemandDto>>> GetConcretAsync(FilterGrid filter);
        Task<ApiResponse<ValidationDto>> ShowPhotoAsync(int idzone, DateTime date);
        Task<ApiResponse<InfoCapacityDto>> InfoCapacityAsync(OfferDto model);
        Task UpdateAsync(DemandUpdateDto model);
        Task InsertPhotoAsync(OfferInsertDto model);
        Task UpdateSicadiAsync(SicadiDemandDto model);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
    }
}
