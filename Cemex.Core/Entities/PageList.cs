using System;
using System.Collections.Generic;
using System.Linq;

namespace Cemex.Core.Entities
{
    public class PageList<T> : List<T>
    {
        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            this.TotalCount = count;
            this.PageSize = pageSize;
            this.CurrentPage = pageNumber;
            this.TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PageList<T> Create(IEnumerable<T> items, int pageNumber, int pageSize)
        {
            int count = items.Count();
            var _items = items.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            return new PageList<T>(_items, count, pageNumber, pageSize);
        }

        public static PageList<T> Create(IEnumerable<T> items, int totalCount, int pageNumber, int pageSize)
        {
            return new PageList<T>(items.ToList(), totalCount, pageNumber, pageSize);
        }

        public int CurrentPage 
        { 
            get; 
            set; 
        }

        public int TotalPage 
        { 
            get; 
            private set; 
        }

        public int PageSize 
        { 
            get; 
            set; 
        }

        public int TotalCount 
        { 
            get; 
            private set; 
        }

        public bool HasPrevPage
        {
            get
            {
                return this.CurrentPage > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return this.CurrentPage < this.TotalPage;
            }
        }

        public int? PrevPage
        {
            get
            {
                return this.HasPrevPage ? this.CurrentPage - 1 : (int?)null;
            }
        }

        public int? NextPage
        {
            get
            {
                return this.HasNextPage ? this.CurrentPage + 1 : (int?)null;
            }
        }
    }
}
