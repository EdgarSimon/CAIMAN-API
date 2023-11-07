using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.ElementAssigPlan
{
    public class ElementPlanTransportDto
    {
        public int IdTransportista { get; set; }
        public string vc50nombreTransportista { get; set; }
        public decimal OfertaTotal { get; set; }
        public decimal AsignadoTotal { get; set; }
        public decimal DisponibleTotal { get; set; }

    }
}
