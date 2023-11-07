using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.ManualPlan
{
    public class ManualPlanUpdateDto
    {
        public long idplan { get; set; }
        public DateTime fecha { get; set; }
        [JsonIgnore]
        public string Vc20Usuario { get; set; }
    }
}
