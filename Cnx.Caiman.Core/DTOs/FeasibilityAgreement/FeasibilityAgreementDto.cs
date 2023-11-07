using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.FeasibilityAgreement
{
    public class FeasibilityAgreementDto
    {
        public List<OfferPriorityDto> OfferPriority { get; set; }
        public List<OfferShipperPriorityDto> OfferShipperPriority { get; set; }

    }
}