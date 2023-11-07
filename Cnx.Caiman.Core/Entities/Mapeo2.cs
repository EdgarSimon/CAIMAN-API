using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Mapeo2
    {
        public int? IdPlanAsignacion { get; set; }
        public int? IdConvenio { get; set; }
        public string Vc8000Mapeo { get; set; }
        public decimal? NCantidad { get; set; }
        public DateTime? DtCreacion { get; set; }
        public DateTime? DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
    }
}
