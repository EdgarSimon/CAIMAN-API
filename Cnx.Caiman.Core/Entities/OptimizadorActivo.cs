using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class OptimizadorActivo
    {
        public string IdOptimizador { get; set; }
        public DateTime? DtFechaInicio { get; set; }
        public DateTime? DtUltimaAct { get; set; }
        public string IpAddress { get; set; }
        public int? LastConsec { get; set; }
    }
}
