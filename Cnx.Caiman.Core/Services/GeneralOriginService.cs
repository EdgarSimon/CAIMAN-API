using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs.Origin;
using Cnx.Caiman.Core.Entities;
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
    public class GeneralOriginService: IGeneralOriginService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IApiResponseFactory response;

        public GeneralOriginService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IApiResponseFactory response)
        {
            this.unitOfWork = unitOfWork;
            paginationConfiguration = options.Value;
            this.response = response;
        }

        public async Task<ApiResponse<object>> DeleteAsync(string PrmIdOrigen, string PrmUsuario)
        {
            await this.unitOfWork.GeneralOriginRepository.DeleteAsync(PrmIdOrigen, PrmUsuario);
            return response.GetResponse<Object, Object>(null);
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            IEnumerable<OrigenGeneral> origins = await this.unitOfWork.GeneralOriginRepository.GetAsync(filter.GetProperties());
            using(var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<OrigenGeneral>(origins, filter.Columns, "Reporte transportistas");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<ApiResponse<IEnumerable<GeneralOriginDto>>> GetAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            var origin = await this.unitOfWork.GeneralOriginRepository.GetAsync(filter.GetProperties());
            var originPage = PageList<OrigenGeneral>.Create(origin, filter.Paging.PageNumber, filter.Paging.PageSize);
            return this.response.GetResponse<IEnumerable<GeneralOriginDto>, OrigenGeneral>(originPage);
        }

        public async Task<ApiResponse<IEnumerable<GeneralOriginDto>>> GetAvailableAsync(int zoneId, PaginationQuery filter)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;
            var origin = await this.unitOfWork.GeneralOriginRepository.GetAvailableAsync(zoneId);
            var originPage = PageList<OrigenGeneral>.Create(origin, filter.PageNumber, filter.PageSize);
            return this.response.GetResponse<IEnumerable<GeneralOriginDto>, OrigenGeneral>(originPage);
        }

        public async Task<int> InsertAsync(GeneralOriginInsertDto data)
        {
            var response = await this.unitOfWork.GeneralOriginRepository.InsertAsync(data);
            if (response == (int)StatusExceptions.ErrorDuplicate)
                throw new DuplicateException(MessageCodesErrors.Duplicate);
            return response;
        }

        public async Task<ApiResponse<object>> UpdateAsync(int originId, GeneralOriginInsertDto data)
        {
            await this.unitOfWork.GeneralOriginRepository.UpdateAsync(originId, data);
            return response.GetResponse<Object, Object>(null);
        }
    }
}