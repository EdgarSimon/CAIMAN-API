using AutoMapper;
using Cnx.Caiman.Core.DTOs.Destination;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Services
{
    public class SicadiService: ISicadiService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;
        private readonly IApiResponseFactory response;
        public SicadiService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper Mapper, IApiResponseFactory response)
        {
            this.unitOfWork = unitOfWork;
            this.paginationConfiguration = options.Value;
            this.mapper = Mapper;
            this.response = response;
        }


        public async Task<ApiResponse<IEnumerable<KeyValuePair<string, string>>>> GetSicadiAsync(int idZone)
        {
            var entity = await this.unitOfWork.SicadiRepository.GetSicadiAsync(idZone);
            var responseSicadi = new ApiResponse<IEnumerable<KeyValuePair<string, string>>>(entity);

            return responseSicadi;
        }



        public async Task<ApiResponse<IEnumerable<DestinationDto>>> ListDetinacionAsync(PaginationQuery filter, int idZone)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.PageSize;

            var result = await this.unitOfWork.DestinationRepository.GetWithoutDistanceAsync(idZone);
            var resultPage = PageList<Destino>.Create(result, filter.PageNumber, filter.PageSize);

            return this.response.GetResponse<IEnumerable<DestinationDto>, Destino>(resultPage);
        }

        public async Task UpdateAsync(int idzone)
        {
            await this.unitOfWork.SicadiRepository.UpdateAsync(idzone);
        }
    }
}
