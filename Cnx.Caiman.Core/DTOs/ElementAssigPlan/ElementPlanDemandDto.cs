using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.ElementAssigPlan
{
    public class ElementPlanDemandDto
    {
        //IdFotoDemanda vc50nombreDestino   vc50nombreProducto Demanda Asignado Disponible
        public long IdFotoDemanda { get; set; }
        public string vc50nombreDestino { get; set; }
        public string vc50nombreProducto { get; set; }
        public decimal Demanda { get; set; }
        public decimal Asignado { get; set; }
        public decimal Disponible { get; set; }

    }
}

