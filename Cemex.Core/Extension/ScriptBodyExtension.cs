using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cemex.Core.Entities;

namespace Cemex.Core.Extension
{
    public static class ScriptBodyExtension
    {
        public static dynamic GetProperties(this ScriptBody body)
        {
            var parameters = new ExpandoObject() as IDictionary<String, object>;
            if(body.Params != null)
            {

                foreach (var keyValue in body.Params)
                {
                    if(!string.IsNullOrEmpty(keyValue.Value) && keyValue.Key != "file")
                    {
                        string key = keyValue.Key.Replace(".","");
                        parameters.Add(key, keyValue.Value);
                    }
                }
            }
            return parameters;
        }

        public static StreamContent GetFile(this ScriptBody body)
        {
            if(body.Params != null)
            {
            
                foreach (var keyValue in body.Params)
                {
                    
                    if(!string.IsNullOrEmpty(keyValue.Value) && keyValue.Key == "file")
                    {
                        var bytes = Convert.FromBase64String(keyValue.Value.Substring(keyValue.Value.IndexOf(";base64,") + 8));
                        return new StreamContent(new MemoryStream(bytes));
                    }
                }
            }
            return null;
        }
    }
}
    