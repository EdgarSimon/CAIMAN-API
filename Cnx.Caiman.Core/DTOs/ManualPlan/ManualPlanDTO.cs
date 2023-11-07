using System;

namespace Cnx.Caiman.Core.DTOs.ManualPlan
{
    public class ManualPlanDto
    {
        public long IdPlanManual { get; set; }
        public int IdZona { get; set; }
        public string Vc50Nombre { get; set; }
        public DateTime DtFecha { get; set; }
        public int BAceptacion { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime? DtActualizacion { get; set; }
        public string Vc20UsuarioCreacion { get; set; }
        public string Vc20UsuarioActualizacion { get; set; }
        public DateTime? DtAutorizacion { get; set; }
        public string Vc20Autorizacion { get; set; }
        public int IArchivoCreado { get; set; }
    }
}
