using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.AssignmentTrip
{
    public class InsertPlanTripDto
    {
        public int idzone { get; set; }
        public int Idorigin { get; set; }
        public int IdDetination { get; set; }
        public int IdProduct { get; set; }
        public int IdShipper { get; set; }
        public int IdHour { get; set; }
        [JsonIgnore]
        public string Vc20Usuario { get; set; }
        public string IdResult { get; set; }
    }
}
