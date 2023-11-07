using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Destination
{
    public class RelDestinoInventarioDto
    {
        public int idDestino { get; set; }
        public int idRelacion { get; set; }
        public int iClaveSicadiRelacion { get; set; }
        public string vcNombre { get; set; }
        public string vc20UsuarioCreacion { get; set; }
        public DateTime dtCreacion { get; set; }
    }
}
