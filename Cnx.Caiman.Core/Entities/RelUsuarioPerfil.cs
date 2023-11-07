using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class RelUsuarioPerfil
    {
        public int IdRelUsuarioPerfil { get; set; }
        public int IdUsuario { get; set; }
        public int IdZona { get; set; }
        public int IdPerfil { get; set; }
        public bool BActivo { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }

        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Zona IdZonaNavigation { get; set; }
    }
}
