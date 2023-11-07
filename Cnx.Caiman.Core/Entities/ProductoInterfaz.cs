using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ProductoInterfaz
    {
        public string VcSap { get; set; }
        public string VcNombre900 { get; set; }
        public string IdProd55 { get; set; }
        public string VcNombre55 { get; set; }
        public decimal? NPesoVolumetrico { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public string VcBorrar { get; set; }
        public bool Procesado { get; set; }
        public bool BProcesado { get; set; }
    }
}
