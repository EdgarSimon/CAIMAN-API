using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.ElementAssigPlan
{
    public class ElementPlanStockDto
    {
        public int IdDestino { get; set; }
        public string vc50nombreDestino { get; set; }
        public int IdProducto { get; set; }
        public string vc50nombreProducto { get; set; }
        public string nCapacidadMaxima { get; set; }
        public string nInventarioActual { get; set; }
        public string Entradas { get; set; }
        public string nSalidasPromedio { get; set; }
        public string nInventarioFinal { get; set; }
    }
}

