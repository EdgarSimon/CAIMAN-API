using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.DTOs.Offer
{
    public class TransportOfferInsertDto
    {
        public float Oferta { get; set; }
        public string VcObservaciones { get; set; }
        public string Vc20usuario { get; set; }
        public int IdZone { get; set; }
        [JsonIgnore]
        public int IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
