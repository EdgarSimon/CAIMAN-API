using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class TempPmiTimer
    {
        public DateTime? DtFecha { get; set; }
        public int? IdZona { get; set; }
        public DateTime? DtInicio { get; set; }
        public DateTime? DtFin { get; set; }
    }
}
