using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.ManualPlan
{
    public class ManualPlanInsertDTO
    {
        public int idzone { get; set; }
        public DateTime date { get; set; }
        [JsonIgnore]
        public string Vc20Usuario { get; set; }
    }
}
