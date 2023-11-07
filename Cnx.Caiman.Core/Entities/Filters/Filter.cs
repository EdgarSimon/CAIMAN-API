using System;
using Cemex.Core.Entities.Filters;

namespace Cnx.Caiman.Core.Entities.Filters
{
    public class Filter : PaginationQuery
    {
        public string Zone 
        { 
            get; 
            set; 
        }

        public DateTime Date
        { 
            get; 
            set; 
        }
    }
}