using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ContratoGeneral
    {
        public int IdContratoGeneral { get; set; }
        public int IdZona { get; set; }
        public int IdOrigen { get; set; }
        public int IdProducto { get; set; }
        public string Cedis { get; set; }
        public string VcContrato { get; set; }
        public string VcSapOrigen { get; set; }
        public string VcSapProducto { get; set; }
        public decimal? NPrecio { get; set; }
        public string UnidadMedida { get; set; }
        public bool? BActivo { get; set; }
        public DateTime? DtCreacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime? DtActualizacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public decimal? NPesoVolumetrico { get; set; }
    }
}
