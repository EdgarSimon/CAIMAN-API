using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.AssigPlan
{
    public class AssigPlanstateDto
    {
        public int IdPlanAsignacion { get; set; }
        public int Estatus { get; set; }
        [JsonIgnore]
        public string Vc20Usuario { get; set; }

    }
}
