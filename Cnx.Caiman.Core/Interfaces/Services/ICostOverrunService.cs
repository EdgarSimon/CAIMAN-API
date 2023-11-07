using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.CostOverrun;
using Cemex.Core.Entities;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface ICostOverrunService
    {
         Task<ApiResponse<IEnumerable<TypesCostOverrunDto>>> GetTypesOverrunAsync();
    }
}