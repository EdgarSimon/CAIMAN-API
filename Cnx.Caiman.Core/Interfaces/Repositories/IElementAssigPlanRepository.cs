using Cnx.Caiman.Core.DTOs.ElementAssigPlan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IElementAssigPlanRepository
    {
        Task<List<dynamic>> ListAsync(int element, int idzone, int pivote, int idphoto);
        Task<List<KeyValuePair<int, string>>> ListPhotoAsync(int element, int idzone, int idplanassig);
        Task<KeyValuePair<int, int>> SearchPhotoAsync(int element, int idzone, int idplanassig);
        Task<int> UpdateAsync(ElementPlanUpdateDto model);
        Task<List<KeyValuePair<int, string>>> DayPhotoListAsync(int element, int idzone, DateTime date);
    }
}
