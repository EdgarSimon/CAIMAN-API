using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.User
{
    public class UserPermitUpdateDto
    {
        public int Idzone { get; set; }
        public int Iduser { get; set; }
        public List<UserchekUpdateDto> Page { get; set; }

    }
}
