using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class RelConfiguracionMensual
    {
        public int IdRelConfiguracionMensual { get; set; }
        public int IdPagina { get; set; }
        public int IdZona { get; set; }
        public DateTime DtFecha { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }

        public virtual Pagina IdPaginaNavigation { get; set; }
        public virtual Zona IdZonaNavigation { get; set; }
    }
}
