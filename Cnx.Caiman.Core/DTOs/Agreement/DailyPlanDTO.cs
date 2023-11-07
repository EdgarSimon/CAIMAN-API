using Cemex.Core.Entities.Filters;
using System;

namespace Cnx.Caiman.Core.DTOs.Agreement
{
    public class DailyPlanDto: PaginationQuery
    {
        public int iduser { get; set; }

        public int idzone { get; set; }

        public DateTime date { get; set; }

    }
}
