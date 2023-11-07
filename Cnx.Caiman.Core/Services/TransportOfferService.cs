using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Cnx.Caiman.Core.DTOs.Offer;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.Oferta;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Extension;
using ClosedXML.Excel;
using Microsoft.Extensions.Options;

namespace Cnx.Caiman.Core.Services
{
    public class TransportOfferService: ITransportOfferService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;
        public TransportOfferService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper Mapper)
        {
            this.unitOfWork = unitOfWork;
            this.paginationConfiguration = options.Value;
            this.mapper = Mapper;
        }


        public async Task<int> UpdateAsync(TransportOfferInsertDto data, int idTransportOffer)
        {
        
            if(idTransportOffer == 0)
            {
                var parameters = new {
                    idZona = data.IdZone,
                    idUsuario = data.IdUsuario,
                    dtFecha = data.Fecha
                };
                var offersTransport = await this.unitOfWork.TransportOfferRepository.GetAsync(parameters);
                var offer = offersTransport.FirstOrDefault();

                string pattern = @"[0-9]{1,}\.[0-9]{1,}|[0-9]{1,}";
                Match m = Regex.Match(offer.Oferta, pattern, RegexOptions.IgnoreCase);

                data.Fecha = offer.DtFecha;
                data.VcObservaciones = offer.Observaciones;
                data.Oferta = float.Parse(m.Value);
                await this.unitOfWork.TransportOfferRepository.UpdateAsync(data, offer.IdOfertaTransporte);
                    
                return 1;
            }
            else
            {
                return await this.unitOfWork.TransportOfferRepository.UpdateAsync(data, idTransportOffer);
            }
        }

        public async Task<ApiResponse<IEnumerable<TransportOfferDto>>> GetAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;
            var offersTransport = await this.unitOfWork.TransportOfferRepository.GetAsync(filter.GetProperties(hasIdUserProperties: true));
            var offersTransportPage = PageList<OfertaTransporteResult>.Create(offersTransport, filter.Paging.PageNumber, filter.Paging.PageSize);
            var offersTransportDto = this.mapper.Map<IEnumerable<TransportOfferDto>>(offersTransportPage);
            return new ApiResponse<IEnumerable<TransportOfferDto>>(offersTransportDto).ToPagination((object)offersTransportPage);
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            IEnumerable<OfertaTransporteResult> offersTransport = await this.unitOfWork.TransportOfferRepository.GetAsync(filter.GetProperties(hasIdUserProperties: true));
            using(var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<OfertaTransporteResult>(offersTransport, filter.Columns, "Reporte Oferta Transportista");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<ApiResponse<ValidationDto>> ShowPhotoAsync(int idzone, DateTime date)
        {
            bool showPhoto = false;

            var band = await this.unitOfWork.TransportOfferRepository.ShowPhotoAsync(idzone, date);

            if (band == 1)
                showPhoto = !(await this.unitOfWork.OfferRepository.OrdenVerifyCapacityAsync(idzone, date, 2));

            //validamos la creacion de foto
            var result = await this.unitOfWork.OfferRepository.CreatePhotoAsync(idzone, date, 2);

            ValidationDto resultValidate = new ValidationDto()
            {
                Camera = result.fotos > 0,
                CreatePhoto = result.flag == 1,
                Photo = showPhoto
            };

            var response = new ApiResponse<ValidationDto>(resultValidate);

            return response;
        }
    }
}
