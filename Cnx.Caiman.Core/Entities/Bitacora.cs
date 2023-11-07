using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Bitacora
    {
        public long IdBitacora { get; set; }
        public long Tid { get; set; }
        public int IdZona { get; set; }
        public string Vc50Evento { get; set; }
        public string Vc255Descripcion { get; set; }
        public DateTime DtCreacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
    }
}
