using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cnx.Caiman.Core.DTOs.Destination;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.Filters;
using Cnx.Caiman.Core.Entities.QueryEntities.Destino;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Exceptions;
using Cemex.Core.Extension;
using Microsoft.Extensions.Options;
using ClosedXML.Excel;
using Cnx.Caiman.Core.DTOs.Product;
using System.Linq;
using System.Dynamic;
using Cnx.Caiman.Core.Enums;

namespace Cnx.Caiman.Core.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IApiResponseFactory response;
        private readonly IMapper mapper;

        public DestinationService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IApiResponseFactory response, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.paginationConfiguration = options.Value;
            this.response = response;
            this.mapper = mapper;
        }
        public async Task<int> DeleteAsync(int idDestination, string username)
        {
            return await this.unitOfWork.DestinationRepository.DeleteAsync(idDestination, username);
        }

        public async Task<int> DeleteRelationInventoryAsync(int idDestination, int idRelation)
        {
            return await this.unitOfWork.DestinationRepository.DeleteRelationInventoryAsync(idDestination, idRelation);
        }

        public async Task<ApiResponse<IEnumerable<DestinationDto>>> GetAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            var destinations = await this.unitOfWork.DestinationRepository.GetAsync(filter.GetProperties());
            var destinationsPage = PageList<DestinoQuery>.Create(destinations, filter.Paging.PageNumber, filter.Paging.PageSize);
            return this.response.GetResponse<IEnumerable<DestinationDto>, DestinoQuery>(destinationsPage);
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            IEnumerable<DestinoQuery> destinations = await this.unitOfWork.DestinationRepository.GetAsync(filter.GetProperties());
            // CREATE EXCEL FILE
            using(var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<DestinoQuery>(destinations, filter.Columns, "Reporte Destinos");
                return new ApiResponse<string>(base64);
            }
            
        }

        public async Task<ApiResponse<IEnumerable<DestinationWithoutDistanceDto>>> GetWithoutDistanceAsync(ZoneIntFilter filter)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;
            var parameters = new ExpandoObject() as IDictionary<String, object>;
            parameters.Add("zona", filter.IdZona);
            var destinations = await this.unitOfWork.DestinationRepository.GetAsync(parameters);
            var destinationsPage = PageList<DestinoQuery>.Create(destinations, filter.PageNumber, filter.PageSize);
            return this.response.GetResponse<IEnumerable<DestinationWithoutDistanceDto>, DestinoQuery>(destinationsPage);
        }

        public async Task<ApiResponse<IEnumerable<RelUsoDto>>> GetDestinationProductsListAsync(PaginationQuery filter, int idDestination)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;
            var destinations = await this.unitOfWork.DestinationRepository.GetDestinationProductsListAsync(idDestination);
            var destinationsPage = PageList<RelUso>.Create(destinations, filter.PageNumber, filter.PageSize);
            return this.response.GetResponse<IEnumerable<RelUsoDto>, RelUso>(destinationsPage);
        }

        public async Task<ApiResponse<IEnumerable<RelDestinoInventarioDto>>> GetRelationDestinationInventoryAsync(PaginationQuery filter, int idDestination)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;
            var destinations = await this.unitOfWork.DestinationRepository.GetRelationDestinationInventoryAsync(idDestination);
            var destinationsPage = PageList<RelDestinoInventario>.Create(destinations, filter.PageNumber, filter.PageSize);
            return this.response.GetResponse<IEnumerable<RelDestinoInventarioDto>, RelDestinoInventario>(destinationsPage);
        }

        public async Task<ApiResponse<IEnumerable<DestinationDto>>> GetByZoneAllAsync(FilterZone filter, bool isagreement, string idFiltrados)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var destinations = await this.unitOfWork.DestinationRepository.GetByZoneAllAsync(Convert.ToInt32(filter.IdZona), isagreement, filter.Search);
            var destinationsPage = PageList<Destino>.Create(destinations, filter.PageNumber, filter.PageSize);

            if (!string.IsNullOrEmpty(idFiltrados))
            {
                foreach (var item in idFiltrados.Split(','))
                {
                    if (!destinationsPage.Exists(k => k.IdDestino == Convert.ToInt32(item)))
                    {
                        var product = destinations.FirstOrDefault(k => k.IdDestino == Convert.ToInt32(item));

                        if (product != null)
                            destinationsPage.Add(product);
                    }
                }
            }

            return this.response.GetResponse<IEnumerable<DestinationDto>, Destino>(destinationsPage);

        }

        public async Task<ApiResponse<IEnumerable<DestinationDto>>> GetRestrictionAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.DestinationRepository.GetRestrictionAsync(idZone, tid, filter.PageNumber, filter.PageSize, filter.Search);

            var entity = result.Key;
            var totalCount = result.Value;

            var responsePage = PageList<Destino>.Create(entity, totalCount, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<List<DestinationDto>>(entity);

            return new ApiResponse<IEnumerable<DestinationDto>>(map).ToPagination(responsePage);
        }

        public async Task<ApiResponse<IEnumerable<DestinationDto>>> GetRestrictionOneToOneAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.DestinationRepository.GetRestrictionOneToOneAsync(idZone, tid, filter.PageNumber, filter.PageSize, filter.Search);

            var entity = result.Key;
            var totalCount = result.Value;

            var responsePage = PageList<Destino>.Create(entity, totalCount, filter.PageNumber, filter.PageSize);
            var map = this.mapper.Map<List<DestinationDto>>(entity);

            return new ApiResponse<IEnumerable<DestinationDto>>(map).ToPagination(responsePage);
        }

        public async Task<ApiResponse<IEnumerable<DestinationDto>>> GetRestrictionInvolvedAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.DestinationRepository.GetRestrictionInvolvedAsync(idZone, tid);
            var resultPage = PageList<Destino>.Create(result, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<DestinationDto>, Destino>(resultPage);
        }

        public async Task<ApiResponse<IEnumerable<DestinationDto>>> GetRestrictionInvolvedOneToOneAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.DestinationRepository.GetRestrictionInvolvedOneToOneAsync(idZone, tid);
            var resultPage = PageList<Destino>.Create(result, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<DestinationDto>, Destino>(resultPage);
        }

        public async Task<int> InsertAsync(DestinationInsertDto data)
        {
            var response = await this.unitOfWork.DestinationRepository.InsertAsync(data);
            if(response == (int)StatusExceptions.ErrorDuplicate)
                throw new DuplicateException(MessageCodesErrors.Duplicate);
            return response;
        }

        public async Task InsertRestrictionAsync(DestinationRestrictionDto data)
        {
            if (data.tid == 0)
            {
                throw new BusinessException("The tid must be greater than zero.");
            }

            await this.unitOfWork.DestinationRepository.InsertRestrictionAsync(data);
        }

        public async Task InsertRestrictionOneToOneAsync(DestinationRestrictionDto data)
        {
            if (data.tid == 0)
            {
                throw new BusinessException("The tid must be greater than zero.");
            }

            await this.unitOfWork.DestinationRepository.InsertRestrictionOneToOneAsync(data.tid, data.value255);
        }

        public async Task<int> UpdateAsync(int idDestination, DestinationInsertDto data)
        {
            return await this.unitOfWork.DestinationRepository.UpdateAsync(idDestination, data);
        }

        public async Task<ApiResponse<IEnumerable<DestinationDto>>> GetDestinationClientListAsync(PaginationQuery filter, int idZone)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.DestinationRepository.GetDestinationClientListAsync(idZone);
            var resultPage = PageList<Destino>.Create(result, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<DestinationDto>, Destino>(resultPage);

        }

        public async Task<int> InsertInventoryProductAsync(RelInventoryInsertProductDto data, int idDestination)
        {
            return await this.unitOfWork.DestinationRepository.InsertInventoryProductAsync(data, idDestination);
        }

        public async Task<int> UpdateInventoryProductAsync(RelInventoryInsertProductDto data, int idDestination, int idRelation)
        {
            return await this.unitOfWork.DestinationRepository.UpdateInventoryProductAsync(data, idDestination, idRelation);
        }

        public async Task<ApiResponse<IEnumerable<ProductDto>>> GetProductsByZoneAsync(PaginationQuery filter, int idZone, int idDestination)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.DestinationRepository.GetProductsByZoneAsync(idZone, idDestination, filter.Search);
            var resultPage = PageList<Producto>.Create(result, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<ProductDto>, Producto>(resultPage);
        }

        public async Task<int> StoreRelationProductAsync(RelDestinationProductInsertDto data)
        {
            return await this.unitOfWork.DestinationRepository.StoreRelationProductAsync(data);
        }

        public async Task<int> UpdateRelationProductAsync(RelDestinationProductInsertDto data, int idRelUse)
        {
            return await this.unitOfWork.DestinationRepository.UpdateRelationProductAsync(data, idRelUse);
        }

        public async Task<int> DeleteRelationProductAsync(int idRelUse)
        {
            return await this.unitOfWork.DestinationRepository.DeleteRelationProductAsync(idRelUse);
        }

        public async Task<ApiResponse<IEnumerable<DestinationDto>>> getDestinationDistanceListAsync(PaginationQuery filter, int idZone)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.DestinationRepository.getDestinationDistanceListAsync(filter, idZone);

            var resultPage = PageList<Destino>.Create(result, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<DestinationDto>, Destino>(resultPage);
        }
    }
}

