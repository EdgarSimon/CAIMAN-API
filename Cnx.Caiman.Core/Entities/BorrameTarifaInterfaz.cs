using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class BorrameTarifaInterfaz
    {
        public int? IdOrigen { get; set; }
        public int? IdDestino { get; set; }
        public int? Distancia { get; set; }
        public double? Tarifa { get; set; }
        public int BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public int BInterfaz { get; set; }
    }
}
