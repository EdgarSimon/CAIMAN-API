using Cnx.Caiman.Core.Interfaces.Repositories;
using Cemex.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Infrastructure.Repositories
{
    public class LogErrorRepository: ILogErrorRepository
    {
        private readonly IDbContext dbContext;

        public LogErrorRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task InsertLog(string method, string exception, string mail, string trace)
        {

            var parameters = new
            {
                ApiMethod = method,
                Exception = exception,
                mail = mail,
                Trace = trace
            };

            await this.dbContext.ExecuteAsync("[dbo].[EvoInsertaLog]", parameters: parameters);
        }
    }
}
