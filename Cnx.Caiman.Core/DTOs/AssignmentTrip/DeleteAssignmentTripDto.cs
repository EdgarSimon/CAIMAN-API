using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.AssignmentTrip
{
    public class DeleteAssignmentTripDto
    {
        public int idTrip { get; set; }
        [JsonIgnore]
        public string Vc20Usuario { get; set; }
    }
}
