using Cnx.Caiman.Core.DTOs.Destination;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface ISicadiService
    {
        Task<ApiResponse<IEnumerable<KeyValuePair<string, string>>>> GetSicadiAsync(int idZone);
        Task<ApiResponse<IEnumerable<DestinationDto>>> ListDetinacionAsync(PaginationQuery filter, int idZone);
        Task UpdateAsync(int idzone);
    }
}
