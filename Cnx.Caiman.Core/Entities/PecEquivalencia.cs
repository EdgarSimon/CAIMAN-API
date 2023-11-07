using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class PecEquivalencia
    {
        public string Anterior { get; set; }
        public string Equivalente { get; set; }
        public short Tipo { get; set; }
    }
}
