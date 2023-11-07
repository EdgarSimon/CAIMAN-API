using AutoMapper;
using Cnx.Caiman.Core.DTOs.ElementAssigPlan;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Services;
using Cemex.Core.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnx.Caiman.Core.Services
{
    public class ElementAssigPlanService: IElementAssigPlanService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaginationConfiguration paginationConfiguration;
        private readonly IMapper mapper;

        public ElementAssigPlanService(IUnitOfWork unitOfWork, IOptions<PaginationConfiguration> options, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.paginationConfiguration = options.Value;
            this.mapper = mapper;
        }


        public async Task<ApiResponse<List<ElementPlanStockDto>>> ListStockAsync(int idzone, int pivote, int idphoto)
        {
            var ObjectsStock = await this.unitOfWork.ElementAssigPlanRepository.ListAsync(0, idzone, pivote, idphoto);
            
            var ListPhoto = ObjectsStock.Select(k => new ElementPlanStockDto
            {
                IdDestino = k.IdDestino,
                Entradas = k.Entradas,
                IdProducto = k.IdProducto,
                nCapacidadMaxima = k.nCapacidadMaxima,
                nInventarioActual = k.nInventarioActual,
                nInventarioFinal = k.nInventarioFinal,
                nSalidasPromedio = k.nSalidasPromedio,
                vc50nombreDestino = k.vc50nombreDestino,
                vc50nombreProducto = k.vc50nombreProducto
            }).ToList();

            var response = new ApiResponse<List<ElementPlanStockDto>>(ListPhoto);

            return response;
        }

        public async Task<ApiResponse<List<ElementPlanOfferDto>>> ListOfferAsync(int idzone, int pivote, int idphoto)
        {
            var ObjectsOffer = await this.unitOfWork.ElementAssigPlanRepository.ListAsync(1, idzone, pivote, idphoto);
            var ListOffer = ObjectsOffer.Select(k => new ElementPlanOfferDto
            {
                IdFotoOfertaIndex = k.IdFotoOfertaIndex,
                vc50nombreProducto = k.vc50nombreProducto,
                Asignado = k.Asignado,
                Disponible = k.Disponible,
                Oferta = k.Oferta,
                vc50nombreOrigen = k.vc50nombreOrigen

            }).ToList();


            var response = new ApiResponse<List<ElementPlanOfferDto>>(ListOffer);

            return response;
        }

        public async Task<ApiResponse<List<ElementPlanTransportDto>>> ListTransportAsync(int idzone, int pivote, int idphoto)
        {
            var ObjectsOffer = await this.unitOfWork.ElementAssigPlanRepository.ListAsync(2, idzone, pivote, idphoto);
            var ListOffer = ObjectsOffer.Select(k => new ElementPlanTransportDto
            {
                IdTransportista = k.IdTransportista,
                vc50nombreTransportista = k.vc50nombreTransportista,
                OfertaTotal = k.OfertaTotal,
                AsignadoTotal = k.AsignadoTotal,
                DisponibleTotal = k.DisponibleTotal

            }).ToList();


            var response = new ApiResponse<List<ElementPlanTransportDto>>(ListOffer);

            return response;
        }

        public async Task<ApiResponse<List<ElementPlanDemandDto>>> ListDemandAsync(int idzone, int pivote, int idphoto)
        {
            var ObjectsOffer = await this.unitOfWork.ElementAssigPlanRepository.ListAsync(3, idzone, pivote, idphoto);
            var ListOffer = ObjectsOffer.Select(k => new ElementPlanDemandDto
            {
                IdFotoDemanda = k.IdFotoDemanda,
                vc50nombreDestino = k.vc50nombreDestino,
                vc50nombreProducto = k.vc50nombreProducto,
                Demanda = k.Demanda,
                Asignado = k.Asignado,
                Disponible = k.Disponible

            }).ToList();

            var response = new ApiResponse<List<ElementPlanDemandDto>>(ListOffer);

            return response;
        }

        public async Task<ApiResponse<List<KeyValuePair<int, string>>>> ListPhotoAsync(int element, int idzone, int idplanassig)
        {
            var entityKeyValue = await this.unitOfWork.ElementAssigPlanRepository.ListPhotoAsync(element, idzone, idplanassig);

            var response = new ApiResponse<List<KeyValuePair<int, string>>>(entityKeyValue);

            return response;
        }

        public async Task<ApiResponse<KeyValuePair<int, int>>> SearchPhotoAsync(int element, int idzone, int idplanassig)
        {
            var entityKeyValue = await this.unitOfWork.ElementAssigPlanRepository.SearchPhotoAsync(element, idzone, idplanassig);

            var response = new ApiResponse<KeyValuePair<int, int>>(entityKeyValue);

            return response;
        }

        public async Task<ApiResponse<List<KeyValuePair<int, string>>>> DayPhotoListAsync(int element, int idzone, DateTime date)
        {
            var entityKeyValue = await this.unitOfWork.ElementAssigPlanRepository.DayPhotoListAsync(element, idzone, date);

            var response = new ApiResponse<List<KeyValuePair<int, string>>>(entityKeyValue);

            return response;
        }

        public async Task UpdateAsync(ElementPlanUpdateDto model)
        {
            await this.unitOfWork.ElementAssigPlanRepository.UpdateAsync(model);
        }
    }
}
