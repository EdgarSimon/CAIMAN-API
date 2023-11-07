using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.ProductType
{
    public class ProductTypeDto
    {
        public int IdTipoProducto { get; set; }
        public string Vc20TipoProducto { get; set; }
        public int IdCadena { get; set; }
        public int IdZona { get; set; }
        public bool BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
    }
}
