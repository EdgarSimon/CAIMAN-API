using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Pagina
    {
        public Pagina()
        {
            RelConfiguracionMensuals = new HashSet<RelConfiguracionMensual>();
            RelUsuarioPermisos = new HashSet<RelUsuarioPermiso>();
        }

        public int IdPagina { get; set; }
        public int IdModulo { get; set; }
        public int IdSubModulo { get; set; }
        public string CIdentificacion { get; set; }
        public string Vc255NombrePagina { get; set; }
        public string Vc255Descripcion { get; set; }
        public short SiOrden { get; set; }
        public bool BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public int PaginaPermiso { get; set; }

        public virtual Modulo IdModuloNavigation { get; set; }
        public virtual ICollection<RelConfiguracionMensual> RelConfiguracionMensuals { get; set; }
        public virtual ICollection<RelUsuarioPermiso> RelUsuarioPermisos { get; set; }
    }
}
