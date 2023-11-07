using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Entities.Filters
{
    public class FeeQuery: PaginationQuery
    {
        public int IdOrigin { get; set; }
        public int IdProducto { get; set; }
        public int BTodos { get; set; }
    }
}