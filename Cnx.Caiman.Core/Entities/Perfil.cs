using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Perfil
    {
        public Perfil()
        {
            RelUsuarioPerfils = new HashSet<RelUsuarioPerfil>();
        }

        public int IdPerfil { get; set; }
        public string Vc40Nombre { get; set; }
        public string Vc10Nombre { get; set; }
        public string Vc80Descripcion { get; set; }
        public bool BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }

        public virtual ICollection<RelUsuarioPerfil> RelUsuarioPerfils { get; set; }
    }
}
