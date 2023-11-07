using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnx.Caiman.Core.DTOs;
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
    public class CediService : ICediService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IApiResponseFactory response;

        public CediService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IApiResponseFactory response)
        {
            this.unitOfWork = unitOfWork;
            paginationConfiguration = options.Value;
            this.response = response;
        }

        public async Task<int> DeleteAsync(string PrmVcSAP, string PrmUsuario)
        {
            return await this.unitOfWork.CediRepository.DeleteAsync(PrmVcSAP, PrmUsuario);
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            IEnumerable<Cedi> cedis = await this.unitOfWork.CediRepository.GetAsync(filter.GetProperties());   
            using(var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<Cedi>(cedis, filter.Columns, "Reporte Cedis");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<ApiResponse<IEnumerable<CediDto>>> GetAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            var cedis = await this.unitOfWork.CediRepository.GetAsync(filter.GetProperties());
            var cedisPage = PageList<Cedi>.Create(cedis, filter.Paging.PageNumber, filter.Paging.PageSize);
            return this.response.GetResponse<IEnumerable<CediDto>, Cedi>(cedisPage);
        }

        public async Task<int> InsertAsync(UpdateCedisDto data)
        {
            var response = await this.unitOfWork.CediRepository.InsertAsync(data.prmVcSAP, data.prmNombre, data.prmUsuario);
            if (response == (int)StatusExceptions.ErrorDuplicate)
                throw new DuplicateException(MessageCodesErrors.Duplicate);
            return response;
        }

        public async Task<ApiResponse<Object>> UpdateAsync(UpdateCedisDto data)
        {
            await this.unitOfWork.CediRepository.UpdateAsync(data.prmVcSAP, data.prmNombre, data.prmUsuario);
            return response.GetResponse<Object, Object>(null);
        }
    }
}
