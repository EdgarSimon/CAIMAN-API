using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;
using Dapper;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class ProcFileRepository : IProcFileRepository
    {
        private readonly IDbContext dbContext;

        public ProcFileRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<LogInterfaz>> GetAsync(Object parameters)
        {
            return await this.dbContext.QueryAsync<LogInterfaz>("[dbo].[Evo_ProcInterfaceListar]", parameters: parameters);
        }

        public async Task<int> UploadDataFromDataTableAsync(string storeprocedure, DataTable data)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@tbexport", data, DbType.Object);
            parameters.Add("@filename", data.ExtendedProperties["Filename"]);

            return await this.dbContext.ExecuteScalarAsync<int>(storeprocedure, parameters: parameters);
        }
    }
}
