using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.AssigPlan
{
    public class AssigPlanInsertCopyDto
    {
        public int Plan { get; set; }
        [JsonIgnore]
        public string Vc20Usuario { get; set; }
        public long TID { get; set; }
        public int iDestino { get; set; }
        public int iDistancia { get; set; }
        public int iOrigen { get; set; }
        public int iProducto { get; set; }
        public int iTransportista { get; set; }
        public int iConvenio { get; set; }
        public int iViajes { get; set; }
        public int iOptimizacion { get; set; }
        public DateTime FechaObj { get; set; }

    }
}
