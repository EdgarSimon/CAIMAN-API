using System;
using Cemex.Core.Entities.Filters;
using System.Text;
using System.Dynamic;
using System.Collections.Generic;

namespace Cemex.Core.Extension
{
    public static class FilterGridExtension
    {
        public static dynamic GetProperties(this FilterGrid filter, string propColumnName = null, bool hasPaginationProperties = false, bool hasIdUserProperties = false)
        {
            var parameters = new ExpandoObject() as IDictionary<String, object>;
            if(filter.Filters != null)
            {

                foreach (var keyValue in filter.Filters)
                {
                    if (hasIdUserProperties && keyValue.Key == "IdUsuario")
                    {
                        parameters.Add(keyValue.Key, keyValue.Value);
                    }

                    if(!string.IsNullOrEmpty(keyValue.Value) && keyValue.Key != "IdUsuario")
                    {
                        string key = keyValue.Key.Replace(".","");
                        parameters.Add(key, keyValue.Value);
                    }
                }
            }
            if(!string.IsNullOrEmpty(filter.OrderBy.Column))
            {
                string value = filter.OrderBy.Column.Replace(".","");
                parameters[propColumnName ?? "orderByColumn"] = value;
                parameters["@sortType"] = filter.OrderBy.IsDesc;
            }
            if(hasPaginationProperties)
            {
                parameters["pageNumber"] = filter.Paging.PageNumber.ToString();
                parameters["pageSize"] = filter.Paging.PageSize.ToString();
            }
            
            return parameters;
        }
    }
}
