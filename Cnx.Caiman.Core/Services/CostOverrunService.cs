using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cnx.Caiman.Core.DTOs.CostOverrun;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Microsoft.Extensions.Options;

namespace Cnx.Caiman.Core.Services
{
    public class CostOverrunService : ICostOverrunService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;

        public CostOverrunService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper Mapper)
        {
            this.unitOfWork = unitOfWork;
            paginationConfiguration = options.Value;
            this.mapper = Mapper;
        }
        public async Task<ApiResponse<IEnumerable<TypesCostOverrunDto>>> GetTypesOverrunAsync()
        {
            var costrruns = await this.unitOfWork.CostOverrunRepository.GetTypesOverrunAsync();
            var map = this.mapper.Map<IEnumerable<TypesCostOverrunDto>>(costrruns);
            return new ApiResponse<IEnumerable<TypesCostOverrunDto>>(map);
        }
    }
}
