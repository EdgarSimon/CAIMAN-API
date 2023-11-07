using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Feasibility
{
    public class DemandFulfilledDto
    {
        public string Destino { get; set; }
        public string Producto { get; set; }
        public string Demanda_total { get; set; }
        public string Cantidad_Asignada { get; set; }
        public int IdDestino { get; set; }
        public int IdProducto { get; set; }
        public int IdFotoDemandaIndex { get; set; }
        public int IdPlanAsignacion { get; set; }
        public int IdResultado { get; set; }
        public int Validacion { get; set; }

    }
}
