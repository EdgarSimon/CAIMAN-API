using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.ElementAssigPlan
{
    public class ElementPlanOfferDto
    {
        public int IdFotoOfertaIndex { get; set; }
        public string vc50nombreOrigen { get; set; }
        public string vc50nombreProducto { get; set; }
        public decimal Oferta { get; set; }
        public decimal Asignado { get; set; }
        public decimal Disponible { get; set; }
    }
}
