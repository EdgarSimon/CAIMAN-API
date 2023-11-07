using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.User
{
    public class UserProfileUpdateDto
    {
        public int Idzone { get; set; }
        public int Iduser { get; set; }
        public int IdProfile { get; set; }
        public byte Acess { get; set; }

    }
}
