using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.Destination
{
    public class RelInventoryInsertProductDto
    {
        public string Nombre { get; set; }
        public int Clave { get; set; }
        [JsonIgnore]
        public string Vc20usuario { get; set; }
    }
}
