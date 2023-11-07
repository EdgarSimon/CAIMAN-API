using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.ProductType
{
    public class ProductTypeInsertDto
    {
        public int IdZona { get; set; }
        public string VcTipoProducto { get; set; }
        [JsonIgnore]
        public string Vc20Usuario { get; set; }

    }
}
