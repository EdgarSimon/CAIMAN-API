using System;
using System.Collections.Generic;

#nullable disable

namespace Cnx.Caiman.Core.Entities
{
    public partial class ViajeSap
    {
        public string ItemNumber { get; set; }
        public string Destination { get; set; }
        public string ProductCode { get; set; }
        public string SourceCode { get; set; }
        public string CEDIS { get; set; }
        public string Dispatcher { get; set; }
        public string Volume { get; set; }
        public string UnitId { get; set; }
        public string ShippingDate { get; set; }
        public string VehicleId { get; set; }
        public string PayFreight { get; set; }
        //{
        //    get { return "4"; }
        //}
    }
}
