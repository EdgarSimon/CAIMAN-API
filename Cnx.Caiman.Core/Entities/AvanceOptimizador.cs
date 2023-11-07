using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class AvanceOptimizador
    {
        public int IdZona { get; set; }
        public string VcNombreZona { get; set; }
        public string VcUsuario { get; set; }
        public int IdPlan { get; set; }
        public DateTime DtFechaInicio { get; set; }
        public DateTime DtFechaUltimaAct { get; set; }
        public string FPorcenAvance { get; set; }
        public double FMejorEncontrado { get; set; }
        public int IConvenios { get; set; }
        public int ICostoProd { get; set; }
        public double FCostoTrans { get; set; }
        public int IInfactibles { get; set; }
    }
}
