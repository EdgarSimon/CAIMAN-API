using System;
using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.DTOs
{
    public class ZoneIntFilterDto: PaginationQuery
    {
        public int IdZone { get; set; }
        public DateTime Date {get; set; }
    }
}