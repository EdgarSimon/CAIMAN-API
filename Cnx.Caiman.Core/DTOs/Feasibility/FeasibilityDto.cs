using Cnx.Caiman.Core.DTOs.PriorityList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.Feasibility
{
    public class FeasibilityDto
    {
        public List<ListLinkDto> link { get; set; }
        public List<OwnLinkDto> OwnLink { get; set; }
        public List<DemandvsOTDto> DemandvsOT { get; set; }
        public List<ProductOriginDto> ProductOrigin { get; set; }
        public List<ProductDestinationDto> ProductDestination { get; set; }
        public List<AssignOfferDto> AssignOffer { get; set; }
        public List<DemandFulfilledDto> DemandFulfilled { get; set; }
        public List<OfferHoursAssignDto> OfferHoursAssign { get; set; }
        public List<TravelRequestsDto> TravelRequests { get; set; }
        public List<PriorityOriginDto> PriorityOrigin { get; set; }
        public List<PriorityDemandDto> PriorityDemand { get; set; }
        public List<CapacityModelDto> CapacityDispatch { get; set; }
        public List<CapacityModelDto> CapacityReception { get; set; }
        public List<CapacityModelDto> CapacityDispatchCarrier { get; set; }
    }
}
