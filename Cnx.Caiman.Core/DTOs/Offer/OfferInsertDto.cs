using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.Offer
{
    public class OfferInsertDto
    {
        public int idzone { get; set; }
        public int Elemento { get; set; }
        public DateTime date { get; set; }
        [JsonIgnore]
        public string Vc20Usuario { get; set; }
    }
}
