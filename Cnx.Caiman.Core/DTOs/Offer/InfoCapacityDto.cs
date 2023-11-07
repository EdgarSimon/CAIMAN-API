using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Offer
{
    public class InfoCapacityDto
    {
        public int oferta { get; set; }
        public int ofertatransporte { get; set; }
        public int demanda { get; set; }
        public List<InfoCapacityDetailsDto> details { get; set; }
    }
}
