using System;

namespace Cnx.Caiman.Core.Entities
{
    public class RelDestinoInventario
    {
        public int idDestino {get; set; }
        public int idRelacion {get; set; }
        public int iClaveSicadiRelacion {get; set; }
        public string vcNombre {get; set; }
        public string vc20UsuarioCreacion {get; set; }
        public DateTime dtCreacion {get; set; }
    }
}