using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.ManualPlan
{
    public class ManualTripDto
    {

        public long idTrip { get; set; }
        public long idManualPlan { get; set; }
        public DateTime date { get; set; }
        public int idDestination { get; set; }
        public int idProduct { get; set; }
        public int idOrigin { get; set; }
        public int idShidder { get; set; }
        public int iPriority { get; set; }
        public float amount { get; set; }
        public int Trips { get; set; }
        public float lotsize { get; set; }
        [JsonIgnore]
        public string Vc20Usuario { get; set; }
        public Nullable<int> idcause { get; set; }
        public string remark { get; set; }
    }
}
