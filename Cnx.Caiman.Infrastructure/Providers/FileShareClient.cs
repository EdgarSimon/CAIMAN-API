using SMBLibrary;
using SMBLibrary.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Cnx.Caiman.Infrastructure.Providers
{
    internal class FileShareClient : SMB2Client, IDisposable
    {
        private readonly string _domainName;
        private readonly string _username;
        private readonly string _password;
        private readonly string _shareName;
        private SMB2FileStore _fileStore;
        private NTStatus _status;
        private bool _connected;

        public FileShareClient(string domainName, string userName, string password, string shareName)
        {
            _domainName = domainName;
            _username = userName;
            _password = password;
            _shareName = shareName;
        }

        public SMB2FileStore Share => _fileStore;

        public bool Connect()
        {
            _connected = base.Connect(_domainName, SMBTransportType.DirectTCPTransport);

            if (_connected)
            {
                _status = Login(_domainName, _username, _password);
                if (_status == NTStatus.STATUS_SUCCESS)
                {
                    _fileStore = TreeConnect(_shareName, out _status) as SMB2FileStore;
                    return true;
                }
            }

            return false;
        }

        public void Disconnect()
        {
            if (_connected && _status == NTStatus.STATUS_SUCCESS)
                Logoff();

            if (_connected)
                base.Disconnect();
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}
