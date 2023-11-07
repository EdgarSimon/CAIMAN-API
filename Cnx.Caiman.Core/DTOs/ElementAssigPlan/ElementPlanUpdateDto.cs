using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.ElementAssigPlan
{
    public class ElementPlanUpdateDto
    {
        public int Elemento { get; set; }
        public int IdPlanAsignacion { get; set; }
        public int Id { get; set; }
        [JsonIgnore]
        public string Vc20Usuario { get; set; }
    }
}
