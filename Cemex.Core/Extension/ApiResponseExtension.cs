using Cemex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemex.Core.Extension
{
    public static class ApiResponseExtension
    {
        public static ApiResponse<T> ToPagination<T>(this ApiResponse<T> obj, object objPageList)
        {

            Metadata result = new Metadata()
            {
                CurrentPage = (int)objPageList.GetType().GetProperty("CurrentPage").GetValue(objPageList, null),
                TotalPage = (int)objPageList.GetType().GetProperty("TotalPage").GetValue(objPageList, null),
                PageSize = (int)objPageList.GetType().GetProperty("PageSize").GetValue(objPageList, null),
                TotalCount = (int)objPageList.GetType().GetProperty("TotalCount").GetValue(objPageList, null),
                HasPrevPage = (bool)objPageList.GetType().GetProperty("HasPrevPage").GetValue(objPageList, null),
                HasNextPage = (bool)objPageList.GetType().GetProperty("HasNextPage").GetValue(objPageList, null)
            };

            obj.Metadata = result;

            return obj;
        }

    }
}
