namespace Cemex.Core.Entities.Filters
{
    public class PaginationQuery
    {
        public int PageNumber 
        { 
            get; 
            set; 
        }

        public int PageSize 
        { 
            get; 
            set; 
        }

        public string Search
        {
            get;
            set;
        }
    }
}
