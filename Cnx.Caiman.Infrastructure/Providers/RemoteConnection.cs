using Cnx.Caiman.Core.Interfaces.Providers;
using Cemex.Core.Exceptions;
using SMBLibrary;
using SMBLibrary.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Infrastructure.Providers
{
    public class RemoteConnection : IRemoteConnection
    {
        private int count = 1;

        public async Task<bool> UploadFileAsync(string Files, string FileName, string FolderShare, string user, string pass, string server)
        {
            try
            {
                using (var client = new FileShareClient(server, user, pass, FolderShare))
                {
                    object handle;
                    FileStatus status;
                    bool connected = client.Connect();
                    if (!connected)
                    {
                        throw new InvalidOperationException("NoConnectRemote: " + server);
                    }
                    else
                    {
                        var share = client.Share;


                        NTStatus ntStatus = share.CreateFile(out handle, out status, FileName, AccessMask.GENERIC_WRITE | AccessMask.SYNCHRONIZE,
                            0, ShareAccess.None,
                            CreateDisposition.FILE_CREATE,
                            CreateOptions.FILE_NON_DIRECTORY_FILE | CreateOptions.FILE_SYNCHRONOUS_IO_ALERT,
                            null);


                        if (ntStatus == NTStatus.STATUS_SUCCESS)
                        {
                            int numberOfBytesWritten;
                            byte[] data = ASCIIEncoding.UTF8.GetBytes(Files);
                            var tStatus = share.WriteFile(out numberOfBytesWritten, handle, 0, data);
                            if (tStatus != NTStatus.STATUS_SUCCESS)
                            {
                                throw new InvalidOperationException("FailedWriteFile: " + server);
                            }

                            share.CloseFile(handle);
                        }
                        else
                        {
                            throw new InvalidOperationException("DuplicateFileError: " + server);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("FileShareClient: " + server + " " + ex.Message);
            }

            return true;
        }

        public async Task<bool> UploadFileSMB1Async(string Files, string FileName, string FolderShare, string user, string pass, string server)
        {

            SMB1Client clientSMB1 = new SMB1Client();
            bool isConnected = clientSMB1.Connect(server, SMBTransportType.NetBiosOverTCP);
            if (!isConnected)
            {
                throw new InvalidOperationException("NoConnectRemote: " + server);
            }
            NTStatus status = clientSMB1.Login(server, user, pass);
            if (status == NTStatus.STATUS_INVALID_SMB)
            {
                clientSMB1.Logoff();
                clientSMB1.Disconnect();

                if (count <= 3)
                {
                    count = count + 1;
                    await UploadFileSMB1Async(Files, FileName, FolderShare, user, pass, server);

                }
                else
                {
                    throw new InvalidOperationException("SMB: " + status.ToString());
                }

                return true;
            }

            try
            {
                SMB1FileStore fileStore = clientSMB1.TreeConnect(FolderShare, out status) as SMB1FileStore;
                string filePath = @"\\" + FileName;

                object fileHandle;
                FileStatus fileStatus;

                status = fileStore.CreateFile(out fileHandle, out fileStatus, filePath, AccessMask.GENERIC_WRITE | AccessMask.SYNCHRONIZE,
                            0, ShareAccess.None,
                            CreateDisposition.FILE_CREATE,
                            CreateOptions.FILE_NON_DIRECTORY_FILE | CreateOptions.FILE_SYNCHRONOUS_IO_ALERT,
                            null);
                if (status == NTStatus.STATUS_SUCCESS)
                {
                    byte[] data = System.Text.ASCIIEncoding.UTF8.GetBytes(Files);
                    MemoryStream streamData = new MemoryStream(data);

                    int indexOffset = 0;
                    byte[] buffer = new byte[(int)fileStore.MaxWriteSize];

                    int read;
                    while ((read = streamData.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        if (read < (int)fileStore.MaxWriteSize)
                        {
                            Array.Resize<byte>(ref buffer, read);
                        }

                        int numberOfBytesWritten;
                        status = fileStore.WriteFile(out numberOfBytesWritten, fileHandle, indexOffset, buffer);
                        if (status != NTStatus.STATUS_SUCCESS)
                        {
                            throw new InvalidOperationException("FailedWriteFile: " + server);
                        }
                        indexOffset += read;
                    }

                    fileStore.CloseFile(fileHandle);
                }

                fileStore.Disconnect();
                clientSMB1.Logoff();
                clientSMB1.Disconnect();

            }
            catch (Exception ex)
            {
                clientSMB1.Disconnect();
                throw new InvalidOperationException("FileShareClient: " + server + " " + ex.Message);
            }

            return await Task.FromResult(true);
        }

        private async Task DeleteFile(SMB2FileStore share, string FileName)
        {
            object handle;
            FileStatus status;
            NTStatus ntStatus = share.CreateFile(out handle, out status, FileName, AccessMask.GENERIC_WRITE | AccessMask.DELETE | AccessMask.SYNCHRONIZE,
                0, ShareAccess.None, CreateDisposition.FILE_OPEN,
                CreateOptions.FILE_NON_DIRECTORY_FILE | CreateOptions.FILE_SYNCHRONOUS_IO_ALERT, null);

            if (ntStatus == NTStatus.STATUS_SUCCESS)
            {
                FileDispositionInformation fileDispositionInformation = new FileDispositionInformation();
                fileDispositionInformation.DeletePending = true;
                share.SetFileInformation(handle, fileDispositionInformation);
                
                share.CloseFile(handle);
            }            
        }

        public async Task<bool> UploadFileFTPAsync(string Files, string FileName, string FolderShare, string user, string pass, string server)
        {

            Uri url = new Uri("ftp://" + server + "/" + FolderShare + "/" + FileName);

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(user, pass);

            // Copy the contents of the file to the request stream.
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(Files);
            writer.Flush();
            stream.Position = 0;

            using (Stream requestStream = request.GetRequestStream())
            {
                await stream.CopyToAsync(requestStream);
            }

            return true;
        }

        }
}
