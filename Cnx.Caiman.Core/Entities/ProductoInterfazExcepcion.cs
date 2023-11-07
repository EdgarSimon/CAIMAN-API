using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ProductoInterfazExcepcion
    {
        public string VcSap { get; set; }
        public string IdProd55 { get; set; }
        public string VcNombre55 { get; set; }
        public decimal? NPesoVolumetrico { get; set; }
        public DateTime? DtCreacion { get; set; }
        public DateTime? DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
    }
}
