using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.SubZone
{
    public class SubZoneInsertDto
    {
        public int IdZone { get; set; }
        public string Vc50Nombre { get; set; }
        
        [JsonIgnore]
        public string Vc20Usuario { get; set; }
    }
}
