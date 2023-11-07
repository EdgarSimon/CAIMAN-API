using AutoMapper;
using Cnx.Caiman.Core.DTOs.AssigPlan;
using Cnx.Caiman.Core.DTOs.PrevValidation;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Services
{
    public class PrevValidationsService: IPrevValidationsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;
        public PrevValidationsService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper Mapper)
        {
            this.unitOfWork = unitOfWork;
            this.paginationConfiguration = options.Value;
            this.mapper = Mapper;
        }


        public async Task<ApiResponse<List<ValidacionesPreviasListDto>>> GetAsync(int IdPlanAssig, string element)
        {
            var result = await this.unitOfWork.PrevValidationsRepository.GetAsync(IdPlanAssig, element);
            var map = this.mapper.Map<List<ValidacionesPreviasListDto>>(result);
            var response = new ApiResponse<List<ValidacionesPreviasListDto>>(map);
            return response;
        }

        public async Task<ApiResponse<List<KeyValuePair<string, int>>>> GetDvSEAsync(int IdPlanAssig)
        {
            var result = await this.unitOfWork.PrevValidationsRepository.GetDvSEAsync(IdPlanAssig);
            var response = new ApiResponse<List<KeyValuePair<string, int>>>(result);
            return response;
        }

        public async Task<ApiResponse<List<AssigPlanDto>>> GetOTvsDAsync(int IdPlanAssig)
        {
            var result = await this.unitOfWork.PrevValidationsRepository.GetOTvsDAsync(IdPlanAssig);
            var map = this.mapper.Map<List<AssigPlanDto>>(result);
            var response = new ApiResponse<List<AssigPlanDto>>(map);
            return response;
        }
    }
}
