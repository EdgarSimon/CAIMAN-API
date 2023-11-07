using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class Resultado
    {
        public int IdResultado { get; set; }
        public int IdPlanAsignacion { get; set; }
        public int? ICantidadInfactibles { get; set; }
        public int? ICantidadConveniosInfactibles { get; set; }
        public bool BCambio { get; set; }
        public bool BAceptacion { get; set; }
        public DateTime? DtFechaOptimizacion { get; set; }
        public DateTime? DtFechaAceptacion { get; set; }
        public string Vc20UsuarioAceptacion { get; set; }
        public int IArchivoCreado { get; set; }
    }
}
