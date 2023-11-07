using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Offer
{
    public class OfferUpdateTwoDto
    {
        public int IdOferta { get; set; }
        public float OfertaManiana { get; set; }
        public float OfertaTarde { get; set; }
        public float OfertaNoche { get; set; }
        public string Observaciones { get; set; }
        public string VcUsuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
