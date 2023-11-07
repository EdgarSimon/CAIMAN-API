using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Services
{
    public class LogErrorService : ILogErrorService
    {
        private readonly IUnitOfWork unitOfWork;
        public LogErrorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task InsertLog(string method, string exception, string mail, string trace)
        {
            await this.unitOfWork.LogErrorRepository.InsertLog(method, exception, mail, trace);
        }
    }
}
