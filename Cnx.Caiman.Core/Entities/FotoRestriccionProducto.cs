using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class FotoRestriccionProducto
    {
        public long IdFotoRestriccionProducto { get; set; }
        public int IdFotoRestriccionIndex { get; set; }
        public int IdRestriccionProducto { get; set; }
        public int IdRestriccion { get; set; }
        public int IdProducto { get; set; }
        public int BRestriccion2 { get; set; }
        public DateTime DtCreacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public DateTime DtFoto { get; set; }
        public string Vc20UsuarioFoto { get; set; }
    }
}
