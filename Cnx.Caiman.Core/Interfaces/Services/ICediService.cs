using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.Entities;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Interfaces;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface ICediService
    {
        Task<ApiResponse<IEnumerable<CediDto>>> GetAsync(FilterGrid filter);
        Task<ApiResponse<string>> ExportAsync(FilterGrid filter);
        Task<int> DeleteAsync(string PrmVcSAP, string PrmUsuario);
        Task<int> InsertAsync(UpdateCedisDto data);
        Task<ApiResponse<Object>> UpdateAsync(UpdateCedisDto data);
    }
}
