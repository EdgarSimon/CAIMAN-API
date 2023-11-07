using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ViajeManual
    {
        public long IdViaje { get; set; }
        public long IdPlanManual { get; set; }
        public int IdZona { get; set; }
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public int IdTransportista { get; set; }
        public int IPrioridad { get; set; }
        public DateTime DtFecha { get; set; }
        public decimal NVolumen { get; set; }
        public int NViajes { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime? DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public int? IdCausa { get; set; }
        public string Vc255Desc { get; set; }
    }
}
