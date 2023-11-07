using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.AssigPlan
{
    public class AssigPlanDto
    {
        public int IdPlanAsignacion { get; set; }
        public int IdZona { get; set; }
        public string Vc50Nombre { get; set; }
        public string Vc255Observaciones { get; set; }
        public bool BCostos { get; set; }
        public DateTime DtFecha { get; set; }
        public int? IdPlanAsignacionCopia { get; set; }
        public int IdFotoRestriccionIndex { get; set; }
        public int IdFotoOfertaTransporteIndex { get; set; }
        public int IdFotoOfertaIndex { get; set; }
        public int IdFotoDemandaIndex { get; set; }
        public int? IdFotoInventarioIndex { get; set; }
        public int IdFotoTransportistaIndex { get; set; }
        public int IdFotoOrigenIndex { get; set; }
        public int IdFotoDestinoIndex { get; set; }
        public int IdFotoProductoIndex { get; set; }
        public int IdFotoEnlaceIndex { get; set; }
        public int? IdFotoEnlacePropioIndex { get; set; }
        public int IdFotoRelProduccionIndex { get; set; }
        public int IdFotoRelUsoIndex { get; set; }
        public int IdFotoRelTraduccionRestriccionIndex { get; set; }
        public int IEstatus { get; set; }
        public bool? BMensual { get; set; }
        public bool BActivo { get; set; }
        public DateTime DtCreacion { get; set; }
        public DateTime DtActualizacion { get; set; }
        public UserDto Usuario { get; set; }
    }
}
