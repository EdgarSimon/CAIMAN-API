using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ProductoGeneral
    {
        public int IdProductoGeneral { get; set; }
        public string IdProd55 { get; set; }
        public string VcNombre55 { get; set; }
        public bool BActivo { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime DtCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string VcSapProducto { get; set; }
        public string VcNombre900 { get; set; }
        public decimal? NPesoVolumetrico { get; set; }
        public string Jerarquia { get; set; }
        public string J1 { get; set; }
        public string J2 { get; set; }
        public string J3 { get; set; }
        public string J4 { get; set; }
        public string J5 { get; set; }
        public string Vc20NombreCorto { get; set; }
        public string Vc50NombreGenerico { get; set; }
        public string Vc20SufijoOrigen { get; set; }
    }
}
