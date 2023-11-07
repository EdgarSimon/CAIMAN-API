using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ParametroZonaAdmonInventario
    {
        public int IdZona { get; set; }
        public DateTime DtFecha { get; set; }
        public decimal NDemandaMaxima { get; set; }
        public decimal NTotalOfertaInventario { get; set; }
    }
}
