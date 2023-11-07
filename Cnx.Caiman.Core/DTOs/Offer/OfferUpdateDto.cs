using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.Offer
{
    public class OfferUpdateDto
    {

        //      @OfertaTarde float,
        //@OfertaNoche float,

        public int IdOferta { get; set; }
        public float Oferta { get; set; }
        public string Observaciones { get; set; }
        [JsonIgnore]
        public string Vc20Usuario { get; set; }
         public int IdZone { get; set; }
        [JsonIgnore]
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }

    }
}
