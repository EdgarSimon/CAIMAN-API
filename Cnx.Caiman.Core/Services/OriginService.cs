using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Origin;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.Filters;
using Cnx.Caiman.Core.Entities.QueryEntities.Origen;
using Cnx.Caiman.Core.Enums;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Exceptions;
using Cemex.Core.Extension;
using ClosedXML.Excel;
using Microsoft.Extensions.Options;

namespace Cnx.Caiman.Core.Services
{
    public class OriginService : IOriginService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IApiResponseFactory response;

        public OriginService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IApiResponseFactory response)
        {
            this.unitOfWork = unitOfWork;
            this.paginationConfiguration = options.Value;
            this.response = response;
        }

        public async Task<ApiResponse<object>> DeleteAsync(string idOrigin, string username)
        {
            await this.unitOfWork.OriginRepository.DeleteAsync(idOrigin, username);
            return response.GetResponse<Object, Object>(null);
        }

        public Task<ApiResponse<IEnumerable<OriginDto>>> GetAllAsyn(FilterZone filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ApiResponse<IEnumerable<OriginDto>>> GetByZoneAllAsync(FilterZone filter, bool isagreement, string idFiltrados)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var origin = await this.unitOfWork.OriginRepository.GetByZoneAllAsync(Convert.ToInt32(filter.IdZona), isagreement, filter.Search);
            var originPage = PageList<Origen>.Create(origin, filter.PageNumber, filter.PageSize);

            if (!string.IsNullOrEmpty(idFiltrados))
            {
                foreach (var item in idFiltrados.Split(','))
                {
                    if (!originPage.Exists(k => k.IdOrigen == Convert.ToInt32(item)))
                    {
                        var product = origin.FirstOrDefault(k => k.IdOrigen == Convert.ToInt32(item));

                        if (product != null)
                            originPage.Add(product);
                    }
                }
            }
            return this.response.GetResponse<IEnumerable<OriginDto>, Origen>(originPage);

        }

        public async Task<ApiResponse<IEnumerable<OriginQueryDto>>> GetAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            IEnumerable<OrigenQuery> origins = await this.unitOfWork.OriginRepository.GetAsync(filter.GetProperties());
            var originPage = PageList<OrigenQuery>.Create(origins, filter.Paging.PageNumber, filter.Paging.PageSize);
            return this.response.GetResponse<IEnumerable<OriginQueryDto>, OrigenQuery>(originPage);
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            IEnumerable<OrigenQuery> origins = await this.unitOfWork.OriginRepository.GetAsync(filter.GetProperties());
            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<OrigenQuery>(origins, filter.Columns, "Reporte Origenes");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<ApiResponse<IEnumerable<OriginDto>>> GetRestrictionAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.OriginRepository.GetRestrictionAsync(idZone, tid, filter.Search);
            var resultPage = PageList<Origen>.Create(result, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<OriginDto>, Origen>(resultPage);
        }

        public async Task<ApiResponse<IEnumerable<OriginDto>>> GetRestrictionOneToOneAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.OriginRepository.GetRestrictionOneToOneAsync(idZone, tid);
            var resultPage = PageList<Origen>.Create(result, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<OriginDto>, Origen>(resultPage);
        }

        public async Task<ApiResponse<IEnumerable<OriginDto>>> GetRestrictionInvolvedAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.OriginRepository.GetRestrictionInvolvedAsync(idZone, tid);
            var resultPage = PageList<Origen>.Create(result, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<OriginDto>, Origen>(resultPage);
        }

        public async Task<ApiResponse<IEnumerable<OriginDto>>> GetRestrictionInvolvedOneToOneAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.OriginRepository.GetRestrictionInvolvedOneToOneAsync(idZone, tid);
            var resultPage = PageList<Origen>.Create(result, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<OriginDto>, Origen>(resultPage);
        }

        public async Task<ApiResponse<IEnumerable<OriginDistanceDto>>> GetOriginNewDistanceAsync(PaginationQuery filter, int idorigin)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.OriginRepository.GetOriginNewDistanceAsync(idorigin);

            var resultPage = PageList<Origen>.Create(result, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<OriginDistanceDto>, Origen>(resultPage);
        }

        public async Task<int> InsertAsync(OriginInsertDto data)
        {
            var response = await this.unitOfWork.OriginRepository.InsertAsync(data);
            if(response == (int)StatusExceptions.ErrorDuplicate)
                throw new DuplicateException(MessageCodesErrors.Duplicate);
            return response;
        }

        public async Task InsertRestrictionAsync(OriginRestrictionDto data)
        {
            if (data.tid == 0)
            {
                throw new BusinessException("The tid must be greater than zero.");
            }

            await this.unitOfWork.OriginRepository.InsertRestrictionAsync(data);
        }

        public async Task InsertRestrictionOneToOneAsync(OriginRestrictionDto data)
        {
            if (data.tid == 0)
            {
                throw new BusinessException("The tid must be greater than zero.");
            }

            await this.unitOfWork.OriginRepository.InsertRestrictionOneToOneAsync(data.tid, data.value255);
        }
        public async Task<ApiResponse<object>> UpdateAsync(int idOrigin, OriginInsertDto data)
        {
            await this.unitOfWork.OriginRepository.UpdateAsync(idOrigin, data);
            return response.GetResponse<Object, Object>(null);
        }
    }
}
