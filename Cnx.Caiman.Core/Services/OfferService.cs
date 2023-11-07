using AutoMapper;
using Cnx.Caiman.Core.DTOs.Offer;
using Cnx.Caiman.Core.Entities.QueryEntities.Oferta;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Extension;
using ClosedXML.Excel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Services
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;
        public OfferService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper Mapper)
        {
            this.unitOfWork = unitOfWork;
            this.paginationConfiguration = options.Value;
            this.mapper = Mapper;
        }

        public async Task<ApiResponse<bool>> GetOfferAsync(int idzone)
        {
            var result = await this.unitOfWork.OfferRepository.GetOfferAsync(idzone);
            var response = new ApiResponse<bool>(result);
            return response;
        }

        public async Task<ApiResponse<IEnumerable<ListOfferDto>>> ListSearchAsync(FilterGrid filter)
        {


            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;

            object objectMultiple = await this.unitOfWork.OfferRepository
                                    .GetOfferListAsyc(filter.GetProperties(hasPaginationProperties: true, hasIdUserProperties:true));

            var entity = (IEnumerable<OfertaResult>)objectMultiple.GetType().GetProperty("records").GetValue(objectMultiple);
            var totalCount = (int)objectMultiple.GetType().GetProperty("count").GetValue(objectMultiple);

            var responsePage = PageList<OfertaResult>.Create(entity, totalCount, filter.Paging.PageNumber, filter.Paging.PageSize);
            var map = this.mapper.Map<IEnumerable<ListOfferDto>>(entity);

            var response = new ApiResponse<IEnumerable<ListOfferDto>>(map).ToPagination(responsePage);
            return response;
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            var user = await this.unitOfWork.OfferRepository.GetOfferListAsyc(filter.GetProperties(hasIdUserProperties:true));

            var entity = (IEnumerable<OfertaResult>)user.GetType().GetProperty("records").GetValue(user);
            var map = this.mapper.Map<IEnumerable<ListOfferDto>>(entity);

            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<ListOfferDto>(map, filter.Columns, "Reporte oferta");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<ApiResponse<IEnumerable<ListOfferDto>>> ListSearch2Async(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;

            object objectMultiple = await this.unitOfWork.OfferRepository.GetOfferList2Asyc(filter.GetProperties(hasPaginationProperties: true));

            var entity = (IEnumerable<OfertaResult>)objectMultiple.GetType().GetProperty("records").GetValue(objectMultiple);
            var totalCount = (int)objectMultiple.GetType().GetProperty("count").GetValue(objectMultiple);

            var responsePage = PageList<OfertaResult>.Create(entity, totalCount, filter.Paging.PageNumber, filter.Paging.PageSize);
            var map = this.mapper.Map<IEnumerable<ListOfferDto>>(entity);

            var response = new ApiResponse<IEnumerable<ListOfferDto>>(map).ToPagination(responsePage);
            return response;
        }

        public async Task<ApiResponse<string>> Export2Async(FilterGrid filter)
        {
            var user = await this.unitOfWork.OfferRepository.GetOfferList2Asyc(filter.GetProperties());

            var entity = (IEnumerable<OfertaResult>)user.GetType().GetProperty("records").GetValue(user);
            var map = this.mapper.Map<IEnumerable<ListOfferDto>>(entity);

            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<ListOfferDto>(map, filter.Columns, "Reporte oferta");
                return new ApiResponse<string>(base64);
            }
        }

        public async Task<ApiResponse<ValidationDto>> ShowPhotoAsync(int idzone, DateTime date)
        {
            bool showPhoto = false;

            var band = await this.unitOfWork.OfferRepository.ShowPhotoAsync(idzone, date);

            if (band == 1)
                showPhoto = !(await this.unitOfWork.OfferRepository.OrdenVerifyCapacityAsync(idzone, date, 3));

            //validamos la creacion de foto
            var result = await this.unitOfWork.OfferRepository.CreatePhotoAsync(idzone, date, 3);

            ValidationDto resultValidate = new ValidationDto()
            {
                Camera = result.fotos > 0,
                CreatePhoto = result.flag == 1,
                Photo = showPhoto
            };

            var response = new ApiResponse<ValidationDto>(resultValidate);

            return response;
        }

        public async Task<ApiResponse<InfoCapacityDto>> InfoCapacityAsync(OfferDto model)
        {
            model.PageNumber = model.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : model.PageNumber;
            model.PageSize = model.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : model.PageSize;

            var entity = await this.unitOfWork.OfferRepository.InfoCapacityAsync(model.idzone, model.date);

            var details = PageList<InfoCapacidadesDetalleResult>.Create(entity.Value, model.PageNumber, model.PageSize);


            var head = this.mapper.Map<InfoCapacityDto>(entity.Key);
            var map = this.mapper.Map<List<InfoCapacityDetailsDto>>(details);

            head.details = new List<InfoCapacityDetailsDto>();
            head.details = map;

            var response = new ApiResponse<InfoCapacityDto>(head).ToPagination(details);

            return response;
        }

        public async Task UpdateOfferAsync(OfferUpdateDto model)
        {
            if (model.IdOferta == 0)
            {
                var parameters = new {
                    idZona = model.IdZone,
                    idUsuario = model.IdUsuario,
                    dtFecha = model.Fecha.ToString("yyyy-MM-dd")
                };
                var offersMultipleQuery = await this.unitOfWork.OfferRepository.GetOfferListAsyc(parameters);
                var offers = (IEnumerable<OfertaResult>)offersMultipleQuery.GetType().GetProperty("records").GetValue(offersMultipleQuery);
                var offer = offers.FirstOrDefault();
                model.Fecha = offer.dtFecha;
                model.Observaciones = offer.Observaciones;
                model.Oferta = offer.Oferta;
                model.IdOferta = offer.idOferta;
                await this.unitOfWork.OfferRepository.UpdateOfferAsync(model);

            }
            else
            {
                await this.unitOfWork.OfferRepository.UpdateOfferAsync(model);
            }
        }

        public async Task InsertOfferAsync(OfferInsertDto model)
        {
            await this.unitOfWork.OfferRepository.InsertOfferAsync(model, model.Elemento);
        }

        public async Task UpdateOfferTwoAsync(OfferUpdateTwoDto model)
        {
            await this.unitOfWork.OfferRepository.UpdateOfferTwoAsync(model);
        }
    }
}
