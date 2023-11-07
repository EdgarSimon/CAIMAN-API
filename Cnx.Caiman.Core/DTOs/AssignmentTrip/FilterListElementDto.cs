using Cemex.Core.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cnx.Caiman.Core.DTOs.AssignmentTrip
{
    public class FilterListElementDto: PaginationQuery
    {
        public string Element { get; set; }
        public int IdZone { get; set; }
        public int IdResult { get; set; }
    }
}
