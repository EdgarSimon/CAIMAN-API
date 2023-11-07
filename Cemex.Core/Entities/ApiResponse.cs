using System;
using AutoMapper;

namespace Cemex.Core.Entities
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data, string ResponseType = "")
        {
            this.Data = data;
            this.Status = 200;
            this.Message = "OK";
            this.ResponseType = ResponseType;
        }

        public T Data 
        { 
            get; 
            set; 
        }

        public string ResponseType
        { 
            get; 
            set; 
        }

        public string Message 
        { 
            get; 
            set; 
        }

        public int Status 
        { 
            get; 
            set; 
        }

        public Metadata Metadata 
        { 
            get; 
            set; 
        }
    }
}
