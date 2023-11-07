using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Cnx.Caiman.Core.Entities;
using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface IProcFileRepository
    {
        Task<int> UploadDataFromDataTableAsync(string storeprocedure, DataTable data);
        Task<IEnumerable<LogInterfaz>> GetAsync(Object parameters);
    }
}
