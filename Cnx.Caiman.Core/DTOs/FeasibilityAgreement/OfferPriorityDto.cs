using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.FeasibilityAgreement
{
    public class OfferPriorityDto
    {
        public string Origen { get; set; }
        public string Producto { get; set; }
        public int Oferta { get; set; }
        public int Asignado { get; set; }
        public int Validacion { get; set; }
    }
}
