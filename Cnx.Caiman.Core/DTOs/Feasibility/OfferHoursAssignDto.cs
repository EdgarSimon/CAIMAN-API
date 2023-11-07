using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Feasibility
{
    public class OfferHoursAssignDto
    {
        public string Transportista { get; set; }
        public decimal Oferta { get; set; }
        public int Asignado { get; set; }
        public int Validacion { get; set; }
    }
}
