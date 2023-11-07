using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.AssigPlan
{
    public class AssigPlanInsertDto
    {
        public string Nombre { get; set; }
        public string Observaciones { get; set; }
        public int IdZona { get; set; }
        public DateTime dtFecha { get; set; }

        [JsonIgnore]
        public string Vc20Usuario { get; set; }
    }
}
