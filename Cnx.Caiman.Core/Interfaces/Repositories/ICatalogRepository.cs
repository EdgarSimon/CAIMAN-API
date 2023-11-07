using Cnx.Caiman.Core.Entities.QueryEntities.Catalog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface ICatalogRepository
    {
        Task<dynamic> ListCatalogAsync(Object parameters);
    }
}
