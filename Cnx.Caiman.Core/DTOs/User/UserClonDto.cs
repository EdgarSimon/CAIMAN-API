using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.User
{
    public class UserClonDto
    {
        public int IdUserNew { get; set; }
        public int IdUserClone { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public string Vc20Usuario { get; set; }
    }
}
