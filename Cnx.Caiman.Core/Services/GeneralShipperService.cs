using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cnx.Caiman.Core.DTOs;
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
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Extensions.Options;

namespace Cnx.Caiman.Core.Services
{
    public class GeneralShipperService : IGeneralShipperService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;

        public GeneralShipperService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            paginationConfiguration = options.Value;
            this.mapper = mapper;
        }
        public async Task<ApiResponse<IEnumerable<GeneralShipperDto>>> GetAsync(FilterGrid filter)
        {
            // PAGE DATA
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            object objectMultiple = await this.unitOfWork.GeneralShipperRepository.GetAsync(filter.GetProperties(hasPaginationProperties: true));
            var shippers = (IEnumerable<TransportistaGeneral>)objectMultiple.GetType().GetProperty("records").GetValue(objectMultiple);
            var totalCount = (int)objectMultiple.GetType().GetProperty("count").GetValue(objectMultiple);
            // PAGINATION DATE
            var shippersPage = PageList<TransportistaGeneral>.Create(shippers, totalCount, filter.Paging.PageNumber, filter.Paging.PageSize);
            var shippersDto = this.mapper.Map<IEnumerable<GeneralShipperDto>>(shippersPage);
            // RESPONSE GENERAL SHIPPER
            return new ApiResponse<IEnumerable<GeneralShipperDto>>(shippersDto).ToPagination(shippersPage);
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            // PAGE DATA
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            object objectMultiple = await this.unitOfWork.GeneralShipperRepository.GetAsync(filter.GetProperties());
            var shippers = (IEnumerable<TransportistaGeneral>)objectMultiple.GetType().GetProperty("records").GetValue(objectMultiple);
            // CREATE EXCEL FILE
            using(var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<TransportistaGeneral>(shippers, filter.Columns, "Reporte transportistas");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<int> InsertAsync(GeneralShipperInsertDto data)
        {
            var response = await this.unitOfWork.GeneralShipperRepository.InsertAsync(data);
            if (response == (int)StatusExceptions.ErrorDuplicate)
                throw new DuplicateException(MessageCodesErrors.Duplicate);
            return response;
        }

        public async Task<int> DeleteAsync(int id, string username)
        {
            return await this.unitOfWork.GeneralShipperRepository.DeleteAsync(id, username);
        }

        public async Task<int> UpdateAsync(int IdTransportista, GeneralShipperUpdateDto data)
        {
            return await this.unitOfWork.GeneralShipperRepository.UpdateAsync(IdTransportista, data);
        }

        public ApiResponse<GeneralShipperDto> GetShipperByGeneralShipperAsync(ShipperByGeneralShipperDto data)
        {
            var generalShippers = this.unitOfWork.GeneralShipperRepository.GetShipperByGeneralShipperAsync(data);
            var shippersDto = this.mapper.Map<GeneralShipperDto>(generalShippers);
            return new ApiResponse<GeneralShipperDto>(shippersDto);
        }

        public async Task<ApiResponse<IEnumerable<GeneralShipperDto>>> GetShipperAvailableAsync(ZoneIntFilter filter)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;
            var shippers = await this.unitOfWork.GeneralShipperRepository.GetShipperAvailableAsync(filter.IdZona);
            var shippersPage = PageList<TransportistaGeneral>.Create(shippers, filter.PageNumber, filter.PageSize);
            var shippersDto = this.mapper.Map<IEnumerable<GeneralShipperDto>>(shippersPage);
            return new ApiResponse<IEnumerable<GeneralShipperDto>>(shippersDto).ToPagination(shippersPage);
        }
    }
}