using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.ManualPlan
{
    public class CubeDailyAggDto
    {
        public string UM { get; set; }
        public List<ManualFilterDestinationDto> destination { get; set; }
    }
}
