using AutoMapper;
using Cnx.Caiman.Core.DTOs.Catalog;
using Cnx.Caiman.Core.Entities.QueryEntities.Catalog;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Extension;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Services
{
    public class CatalogService: ICatalogService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IApiResponseFactory response;
        private readonly IMapper mapper;

        public CatalogService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IApiResponseFactory response, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            paginationConfiguration = options.Value;
            this.response = response;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<CatalogDto>>> GetCatalogProductAsync(FilterGrid filter)
        {
            // PAGE DATA
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;

            filter.Filters.Add(new KeyValuePair<string, string>("prmCatalogo", "ProductoZona"));

            object objectMultiple = await this.unitOfWork.CatalogRepository.ListCatalogAsync(filter.GetProperties(hasPaginationProperties: true));
            var shippers = (IEnumerable<CatalogQuerys>)objectMultiple.GetType().GetProperty("records").GetValue(objectMultiple);
            var totalCount = (int)objectMultiple.GetType().GetProperty("count").GetValue(objectMultiple);

            // PAGINATION DATE
            var shippersPage = PageList<CatalogQuerys>.Create(shippers, totalCount, filter.Paging.PageNumber, filter.Paging.PageSize);
            var shippersDto = this.mapper.Map<IEnumerable<CatalogDto>>(shippersPage);
            // RESPONSE GENERAL SHIPPER
            return new ApiResponse<IEnumerable<CatalogDto>>(shippersDto).ToPagination(shippersPage);
        }
    }
}
