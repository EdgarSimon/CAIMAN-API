using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Repositories
{
    public interface ILogErrorRepository
    {
        Task InsertLog(string method, string exception, string mail, string trace);
    }
}
