using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Interfaces.Providers
{
    public interface IRemoteConnection
    {
        Task<bool> UploadFileAsync(string File, string FileName, string FolderShare, string user, string pass, string server);
        Task<bool> UploadFileSMB1Async(string File, string FileName, string FolderShare, string user, string pass, string server);
        Task<bool> UploadFileFTPAsync(string Files, string FileName, string FolderShare, string user, string pass, string server);
    }
}
