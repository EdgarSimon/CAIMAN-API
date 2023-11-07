using AutoMapper;
using Cnx.Caiman.Core.DTOs.AssigPlan;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Extension;
using ClosedXML.Excel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Services
{
    public class AssigPlanService: IAssigPlanService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;
        private readonly IApiResponseFactory response;
        public AssigPlanService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper Mapper, IApiResponseFactory response)
        {
            this.unitOfWork = unitOfWork;
            this.paginationConfiguration = options.Value;
            this.mapper = Mapper;
            this.response = response;
        }

        public async Task<ApiResponse<IEnumerable<AssigPlanDto>>> GetAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;

            var cedis = await this.unitOfWork.AssigPlanRepository.GetAsync(filter.GetProperties(hasIdUserProperties: false));

            var cedisPage = PageList<PlanAsignacion>.Create(cedis, filter.Paging.PageNumber, filter.Paging.PageSize);
            return this.response.GetResponse<IEnumerable<AssigPlanDto>, PlanAsignacion>(cedisPage);
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            var assingplan = (IEnumerable<PlanAsignacion>)await this.unitOfWork.AssigPlanRepository.GetAsync(filter.GetProperties());

            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<PlanAsignacion>(assingplan, filter.Columns, "Reporte asignacion de planes");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task UpdateAsync(AssigPlanUpdateDto model)
        {

            await this.unitOfWork.AssigPlanRepository.UpdateAsync(model);

        }

        public async Task UpdateStateAsync(AssigPlanstateDto model)
        {
            await this.unitOfWork.AssigPlanRepository.UpdatestateAsync(model);

        }

        public async Task InsertAsync(AssigPlanInsertDto model)
        {

            await this.unitOfWork.AssigPlanRepository.InsertAsync(model);

        }
        public async Task DeleteAsync(int IdPlanAsignacion, string vc20Usuario)
        {

            await this.unitOfWork.AssigPlanRepository.DeleteAsync(IdPlanAsignacion, vc20Usuario);

        }

        public async Task InsertCopyAsync(AssigPlanInsertCopyDto model)
        {

            await this.unitOfWork.AssigPlanRepository.InsertCopyAsync(model);

        }
    }
}
