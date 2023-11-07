using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.AssigPlan
{
    public class AssigPlanUpdateDto
    {
        public int IdPlanAsignacion { get; set; }
        public string vc50Nombre { get; set; }
        public string vc255Observaciones { get; set; }
        public int costos { get; set; }

        [JsonIgnore]
        public string vc20Usuario { get; set; }
    }
}
