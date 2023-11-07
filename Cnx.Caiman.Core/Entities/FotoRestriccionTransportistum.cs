using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class FotoRestriccionTransportistum
    {
        public long IdFotoRestriccionTransportista { get; set; }
        public int IdFotoRestriccionIndex { get; set; }
        public int IdRestriccionTransportista { get; set; }
        public int IdRestriccion { get; set; }
        public int IdTransportista { get; set; }
        public int BRestriccion2 { get; set; }
        public DateTime DtCreacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime DtFoto { get; set; }
        public string Vc20UsuarioFoto { get; set; }
    }
}
