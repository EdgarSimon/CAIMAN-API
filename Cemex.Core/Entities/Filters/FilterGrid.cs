using System.Collections.Generic;

namespace Cemex.Core.Entities.Filters
{
    public class FilterGrid
    {
        public OrderBy OrderBy 
        {
            get; 
            set; 
        }
        public PaginationQuery Paging
        { 
            get; 
            set;
        }
        public List<KeyValuePair<string, string>> Filters 
        { 
            get; 
            set;
        }
        public List<KeyValuePair<string, string>> Columns { 
            get; 
            set; 
        }
    }
}