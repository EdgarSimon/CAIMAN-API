using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class RelPlanDiarioZonaTransportistum
    {
        public int IdRelPlanDiarioZonaTransportista { get; set; }
        public int IdUsuario { get; set; }
        public int IdZona { get; set; }
        public int IdTransportista { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Zona IdZonaNavigation { get; set; }
    }
}
