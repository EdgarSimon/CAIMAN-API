using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.User
{
    public class RelUserPermissionsDto
    {
        public int IdRelUsuarioPermiso { get; set; }
        public int IdUsuario { get; set; }
        public int IdZona { get; set; }
        public int IdPagina { get; set; }
        public int IdPermiso { get; set; }
        public bool BActivo { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime DtFechaCreacion { get; set; }
    }
}
