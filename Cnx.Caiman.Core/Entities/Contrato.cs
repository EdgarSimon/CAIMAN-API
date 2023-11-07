using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Contrato
    {
        public long IdContrato { get; set; }
        public string VcSapcontrato { get; set; }
        public int? IdOrigen { get; set; }
        public string Cedis { get; set; }
        public int? IdProducto { get; set; }
        public decimal? NPrecio { get; set; }
        public decimal? NPesoVolumetrico { get; set; }
        public string VcSapProducto { get; set; }
        public DateTime DtCreacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioModificacion { get; set; }
        public DateTime? DtPlanMensual { get; set; }
        public int? IdContratoCopia { get; set; }
        public bool? BMensual { get; set; }
        public bool? BActivo { get; set; }
        public decimal? NPrecioCubo { get; set; }
        public decimal? NCalidadCubo { get; set; }
    }
}
