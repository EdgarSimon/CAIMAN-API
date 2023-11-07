using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.AssignmentTrip
{
    public class AceptAssignPlanDto
    {
        public int idresultado { get; set; }
        public DateTime fecha { get; set; }
        [JsonIgnore]
        public string Vc20Usuario { get; set; }

    }
}
