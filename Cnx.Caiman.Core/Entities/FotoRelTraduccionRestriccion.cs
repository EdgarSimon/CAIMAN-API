using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class FotoRelTraduccionRestriccion
    {
        public int IdFotoRelTraduccionRestriccion { get; set; }
        public int IdFotoRelTraduccionRestriccionIndex { get; set; }
        public int IdTraduccion { get; set; }
        public int IdRestriccion { get; set; }
        public string Vc8000Traduccion { get; set; }
        public DateTime DtFoto { get; set; }
        public string Vc20UsuarioFoto { get; set; }
    }
}
