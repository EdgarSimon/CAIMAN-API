using Cemex.Core.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Cnx.Caiman.Core.DTOs.Offer
{
    public class OfferDto : PaginationQuery
    {
        public int idzone { get; set; }
        public DateTime date { get; set; }
    }
}
