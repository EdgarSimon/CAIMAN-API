using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Entities.Filters
{
    public class FeeDestinationQuery: PaginationQuery
    {
        public int IdDestination { get; set; }
        public int IdProducto { get; set; }
        public int BTodos { get; set; }
    }
}