using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.ManualPlan
{
    public class ManualFilteShipperDTO
    {
        public int id { get; set; }
        public string Description { get; set; }

        public decimal Fee { get; set; }
        public int SingleAmount { get; set; }
        public int TripAmount { get; set; }

    }
}
