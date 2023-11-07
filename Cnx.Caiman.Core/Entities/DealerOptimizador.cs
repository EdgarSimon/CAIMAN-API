using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class DealerOptimizador
    {
        public string IdOptimizador { get; set; }
        public int? IdPlanAsignacion { get; set; }
        public DateTime? DtFechaInicio { get; set; }
        public DateTime? DtUltimaAct { get; set; }
        public int? IdEstatus { get; set; }
        public string VcProceso { get; set; }
    }
}
