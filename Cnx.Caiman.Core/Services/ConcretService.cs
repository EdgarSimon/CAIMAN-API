using AutoMapper;
using Cnx.Caiman.Core.DTOs.Concret;
using Cnx.Caiman.Core.DTOs.Offer;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.Entities.QueryEntities.Oferta;
using Cnx.Caiman.Core.Entities.QueryEntities.OrdenCapacity;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Cemex.Core.Entities.Filters;
using Cemex.Core.Exceptions;
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
    public class ConcretService : IConcretService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;
        private readonly IApiResponseFactory response;
        public ConcretService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper Mapper, IApiResponseFactory response)
        {
            this.unitOfWork = unitOfWork;
            this.paginationConfiguration = options.Value;
            this.mapper = Mapper;
            this.response = response;
        }

        public async Task<ApiResponse<IEnumerable<DemandDto>>> GetConcretAsync(FilterGrid filter)
        {
            filter.Paging.PageNumber = filter.Paging.PageNumber == 0 ? this.paginationConfiguration.DefaultPageNumber : filter.Paging.PageNumber;
            filter.Paging.PageSize = filter.Paging.PageSize == 0 ? this.paginationConfiguration.DefaultPageSize : filter.Paging.PageSize;

            var concret = (IEnumerable<Demanda>)await this.unitOfWork.ConcretRepository.GetAsync(filter.GetProperties(hasIdUserProperties: true));

            var demand = PageList<Demanda>.Create(concret, filter.Paging.PageNumber, filter.Paging.PageSize);

            var map = this.mapper.Map<List<DemandDto>>(demand);

            var apiresponse = new ApiResponse<IEnumerable<DemandDto>>(map).ToPagination(demand);

            return apiresponse;

            //var cedisPage = PageList<Demanda>.Create(concret, filter.Paging.PageNumber, 1001);
            //return this.response.GetResponse<IEnumerable<DemandDto>, Demanda>(concret);
        }

        public async Task<ApiResponse<string>> ExportAsync(FilterGrid filter)
        {
            var concret = (IEnumerable<Demanda>)await this.unitOfWork.ConcretRepository.GetAsync(filter.GetProperties(hasIdUserProperties: true));

            var map = this.mapper.Map<IEnumerable<DemandDto>>(concret);

            using (var workbook = new XLWorkbook())
            {
                string base64 = workbook.GetExcelFromEnumerableModel<DemandDto>(map, filter.Columns, "Reporte concreto");
                return new ApiResponse<string>(base64);
            }
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

            var apiresponse = new ApiResponse<InfoCapacityDto>(head).ToPagination(details);

            return apiresponse;
        }

        public async Task<ApiResponse<ValidationDto>> ShowPhotoAsync(int idzone, DateTime date)
        {
            bool showPhoto = false;
            List<string> MesageCapacity = new List<string>();

            var band = await this.unitOfWork.ConcretRepository.ShowPhotoAsync(idzone, date);

            if (band == 1)
            {
                var capacity = await this.unitOfWork.ConcretRepository.OrdenVerifyCapacityAsync(idzone, date, 4);
                if (capacity.Count() == 0)
                {
                    showPhoto = true;
                }
                else
                {
                    capacity.ForEach(delegate (CapacidadDeOrden item)
                    {
                        if (item.Capacidad == 1 && !item.bFoto)
                            MesageCapacity.Add("Es necesario configurar inventario para crear fotos.");
                        if (item.Capacidad == 2 && !item.bFoto)
                            MesageCapacity.Add("Es necesario configurar Oferta de transporte para crear fotos.");
                        if (item.Capacidad == 3 && !item.bFoto)
                            MesageCapacity.Add("Es necesario configurar Oferta para crear fotos.");
                    });

                    showPhoto = false;
                }

            }

            //validamos la creacion de foto
            var result = await this.unitOfWork.OfferRepository.CreatePhotoAsync(idzone, date, 4);

            ValidationDto resultValidate = new ValidationDto()
            {
                Camera = result.fotos > 0,
                CreatePhoto = result.flag == 1,
                Photo = showPhoto,
                PhotoMensaje = MesageCapacity
            };

            var apiresponse = new ApiResponse<ValidationDto>(resultValidate);

            return apiresponse;
        }

        public async Task UpdateAsync(DemandUpdateDto model)
        {
            if (model.idDemanda == 0)
            {
                var parameters = new
                {
                    idZona = model.IdZone,
                    idUsuario = model.IdUsuario,
                    dtFecha = model.Fecha.ToString("yyyy-MM-dd")
                };
                var demandas = await this.unitOfWork.ConcretRepository.GetAsync(parameters);

                var demand = demandas.FirstOrDefault();
                model.Fecha = demand.DtFecha;
                model.vcObservaciones = demand.Vc255Observaciones;
                model.iPrioridad1 = demand.IPrioridad1;
                model.iPrioridad2 = demand.IPrioridad2;
                model.iPrioridad3 = demand.IPrioridad3;
                model.idDemanda = demand.IdDemanda;
                model.Demanda = (float)demand.NDemandaTotal;
                await this.unitOfWork.ConcretRepository.UpdateAsync(model);

            }
            else
            {
                await this.unitOfWork.ConcretRepository.UpdateAsync(model);
            }
        }

        public async Task InsertPhotoAsync(OfferInsertDto model)
        {
            await this.unitOfWork.OfferRepository.InsertOfferAsync(model, 3);
        }

        public async Task UpdateSicadiAsync(SicadiDemandDto model)
        {

            var resultSicadi = await this.unitOfWork.ConcretRepository.GetSicadiAsync(model);

            if (resultSicadi != null)
            {

                var origins = resultSicadi.FirstOrDefault().Key;
                var products = resultSicadi.FirstOrDefault().Value;

                await this.unitOfWork.ConcretRepository.UpdateSicadiAsync(origins, products, model.fecha);
            }
            else
            {
                throw new BusinessException("No se tienen correctamente configurados los orígenes o productos.");
            }
        }
    }
}