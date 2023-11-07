using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Services
{
    public interface ILogErrorService
    {
        Task InsertLog(string method, string exception, string mail, string trace);
    }
}
