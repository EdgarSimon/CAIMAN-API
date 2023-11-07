using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class RelTraduccionRestriccion
    {
        public int IdTraduccion { get; set; }
        public int IdRestriccion { get; set; }
        public string Vc8000Traduccion { get; set; }
    }
}
