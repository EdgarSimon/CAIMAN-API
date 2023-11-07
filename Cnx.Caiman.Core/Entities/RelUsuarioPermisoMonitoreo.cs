using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class RelUsuarioPermisoMonitoreo
    {
        public int IdRelUsuarioPermisoMonitoreo { get; set; }
        public int IdZona { get; set; }
        public int IdUsuario { get; set; }
        public int IPermisoAgregados { get; set; }
        public int IPermisoConcretos { get; set; }
        public int IPermisoTransporte { get; set; }
        public int IPermisoOpLogisticas { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Zona IdZonaNavigation { get; set; }
    }
}
