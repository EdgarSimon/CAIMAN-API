using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.User
{
    public class UserZoneUpdateDto
    {
        public int iduser { get; set; }
        public List<UserchekUpdateDto> zona { get; set; }
    }
}
