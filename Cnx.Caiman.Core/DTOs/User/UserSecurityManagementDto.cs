using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.User
{
    public class UserSecurityManagementDto
    {
        public int IdUser { get; set; }
        public int IdZone { get; set; }
        public int AgreementPermit { get; set; }
        public int ConcretPermit { get; set; }
        public int ShipperPermit { get; set; }
        public int OLPermit { get; set; }
    }
}
