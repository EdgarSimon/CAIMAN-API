using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.ProductType
{
    public class ProductTypeUpdateDto
    {
        public int IdTipoProducto { get; set; }
        public string vcTipoProducto { get; set; }

        [JsonIgnore]
        public string vc20Usuario { get; set; }
    }
}
