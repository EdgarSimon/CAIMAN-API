using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.DTOs.Shipper;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.Filters;
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
    public class ShipperService: IShipperService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IApiResponseFactory response;

        public ShipperService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IApiResponseFactory response)
        {
            this.unitOfWork = unitOfWork;
            paginationConfiguration = options.Value;
            this.response = response;
        }

        public async Task<ApiResponse<IEnumerable<ShipperDto>>> GetAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            var shippers = await this.unitOfWork.ShipperRepository.GetAsync(filter.GetProperties());
            var shippersPage = PageList<Transportista>.Create(shippers, filter.Paging.PageNumber, filter.Paging.PageSize);
            return response.GetResponse<IEnumerable<ShipperDto>, Transportista>(shippersPage);
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            IEnumerable<Transportista> shippers = await this.unitOfWork.ShipperRepository.GetAsync(filter.GetProperties());
            using(var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<Transportista>(shippers, filter.Columns, "Reporte transportistas");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<int> InsertAsync(ShipperInsertDto data)
        {
            var response = await this.unitOfWork.ShipperRepository.InsertAsync(data);
            if (response == (int)StatusExceptions.ErrorDuplicate)
                throw new DuplicateException(MessageCodesErrors.Duplicate);
            return response;
        }

        public async Task InsertRestrictionAsync(ShipperRestrictionDto data)
        {
            if (data.tid == 0)
            {
                throw new BusinessException("The tid must be greater than zero.");
            }

            await this.unitOfWork.ShipperRepository.InsertRestrictionAsync(data);
        }

        public async Task InsertRestrictionOneToOneAsync(ShipperRestrictionDto data)
        {
            if (data.tid == 0)
            {
                throw new BusinessException("The tid must be greater than zero.");
            }

            await this.unitOfWork.ShipperRepository.InsertRestrictionOneToOneAsync(data.tid, data.value255);
        }

        public async Task<ApiResponse<Object>> DeleteAsync(string ShipperId, string User)
        {
            await this.unitOfWork.ShipperRepository.DeleteAsync(ShipperId, User);
            return response.GetResponse<Object, Object>(null);
        }

        public async Task<ApiResponse<Object>> UpdateAsync(ShipperUpdateDto data)
        {
            await this.unitOfWork.ShipperRepository.UpdateAsync(data);
            return response.GetResponse<Object, Object>(null);
        }

        public async Task<ApiResponse<IEnumerable<ShipperDto>>> GetMonthAsync(ZoneIntFilterDto data)
        {
            data.PageNumber = data.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : data.PageNumber;
            data.PageSize = data.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : data.PageSize;
            var shippers = await this.unitOfWork.ShipperRepository.GetMonthAsync(data.IdZone, data.Date);
            var shippersPage = PageList<Transportista>.Create(shippers, data.PageNumber, data.PageSize);
            return response.GetResponse<IEnumerable<ShipperDto>, Transportista>(shippersPage);
        }

        public async Task<ApiResponse<Object>> InsertMonthlyAsync(ShipperInsertMonthlyDto data)
        {
            await this.unitOfWork.ShipperRepository.InsertMonthlyAsync(data);
            return response.GetResponse<Object, Object>(null);
        }

        public async Task<ApiResponse<object>> UpdateMonthlyAsync(int idTransportista, ShipperInsertMonthlyDto data)
        {
            await this.unitOfWork.ShipperRepository.UpdateMonthlyAsync(idTransportista, data);
            return response.GetResponse<Object, Object>(null);
        }
        
        public async Task<ApiResponse<IEnumerable<ShipperDto>>> GetByZoneAllAsync(ZoneIntFilter filter, bool isagreement)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var shippers = await this.unitOfWork.ShipperRepository.GetByZoneAllAsync(filter.IdZona, isagreement, filter.Search);
            var shippersPage = PageList<Transportista>.Create(shippers, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<ShipperDto>, Transportista>(shippersPage);
        }

        public async Task<ApiResponse<IEnumerable<ShipperDto>>> GetRestrictionAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.ShipperRepository.GetRestrictionAsync(idZone, tid, filter.Search);
            var resultPage = PageList<Transportista>.Create(result, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<ShipperDto>, Transportista>(resultPage);
        }

        public async Task<ApiResponse<IEnumerable<ShipperDto>>> GetRestrictionOneToOneAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.ShipperRepository.GetRestrictionOneToOneAsync(idZone, tid);
            var resultPage = PageList<Transportista>.Create(result, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<ShipperDto>, Transportista>(resultPage);
        }

        public async Task<ApiResponse<IEnumerable<ShipperDto>>> GetRestrictionInvolvedAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.ShipperRepository.GetRestrictionInvolvedAsync(idZone, tid);
            var resultPage = PageList<Transportista>.Create(result, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<ShipperDto>, Transportista>(resultPage);
        }

        public async Task<ApiResponse<IEnumerable<ShipperDto>>> GetRestrictionInvolvedOneToOneAsync(PaginationQuery filter, int idZone, long tid)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.ShipperRepository.GetRestrictionInvolvedOneToOneAsync(idZone, tid);
            var resultPage = PageList<Transportista>.Create(result, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<ShipperDto>, Transportista>(resultPage);
        }
    }
}