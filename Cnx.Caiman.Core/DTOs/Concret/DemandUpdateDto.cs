using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.Concret
{
    public class DemandUpdateDto
    {
        public int iPrioridad1 { get; set; }
        public int iPrioridad2 { get; set; }
        public int iPrioridad3 { get; set; }
        public int idDemanda { get; set; }
        public float Demanda { get; set; }
        public string vcObservaciones { get; set; }
        public int IdZone { get; set; }
        [JsonIgnore]
        public int IdUsuario { get; set; }
        [JsonIgnore]
        public string Vc20Usuario { get; set; }
        public DateTime Fecha { get; set; }

    }
}
