using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Convenio
    {
        public int IdConvenios { get; set; }
        public int IdRestriccion { get; set; }
        public int IdZona { get; set; }
        public DateTime DtFecha { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }

        public virtual Zona IdZonaNavigation { get; set; }
    }
}
