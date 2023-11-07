using Cnx.Caiman.Core.DTOs.Catalog;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface ICatalogService
    {
        Task<ApiResponse<IEnumerable<CatalogDto>>> GetCatalogProductAsync(FilterGrid filter);
    }
}
