using System.Diagnostics.Tracing;
using System;
using AutoMapper;

namespace Cemex.Core.Entities
{
    public interface IApiResponseFactory
    {
        ApiResponse<DTO> GetResponse<DTO, Entity>(object source);
    }

    public class ApiResponseFactory : IApiResponseFactory
    {
        private readonly IMapper mapper;

        public ApiResponseFactory(IMapper mapper)
        {
            this.mapper = mapper;
        }


        public ApiResponse<DTO> GetResponse<DTO, Entity>(object source)
        {
            var responseDestination = mapper.Map<DTO>(source);
            var apiResponse = new ApiResponse<DTO>(responseDestination);
            if (source?.GetType() == typeof(PageList<Entity>))
            {
                var page = (PageList<Entity>)source;
                apiResponse.Metadata = new Metadata()
                {
                    CurrentPage = page.CurrentPage,
                    TotalPage = page.TotalPage,
                    PageSize = page.PageSize,
                    TotalCount = page.TotalCount,
                    HasPrevPage = page.HasPrevPage,
                    HasNextPage = page.HasNextPage
                };
            }
            return apiResponse;
        }
    }
}