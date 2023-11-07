using AutoMapper;
using Cnx.Caiman.Core.DTOs;
using Cnx.Caiman.Core.DTOs.Destination;
using Cnx.Caiman.Core.DTOs.Origin;
using Cnx.Caiman.Core.DTOs.Agreement;
using Cnx.Caiman.Core.Entities;
using Cnx.Caiman.Core.DTOs.Distance;
using Cnx.Caiman.Core.DTOs.Product;
using Cnx.Caiman.Core.DTOs.CostOverrun;
using Cnx.Caiman.Core.DTOs.ManualPlan;
using Cnx.Caiman.Core.Entities.QueryEntities.PlanManualInfo_Nvo;
using Cnx.Caiman.Core.DTOs.User;
using Cnx.Caiman.Core.Entities.QueryEntities.Destino;
using Cnx.Caiman.Core.Entities.QueryEntities.Oferta;
using Cnx.Caiman.Core.DTOs.Offer;
using Cnx.Caiman.Core.DTOs.Concret;
using Cnx.Caiman.Core.DTOs.AssigPlan;
using Cnx.Caiman.Core.DTOs.ProductType;
using Cnx.Caiman.Core.Entities.QueryEntities.Catalog;
using Cnx.Caiman.Core.DTOs.Catalog;
using Cnx.Caiman.Core.Entities.QueryEntities.Origen;
using Cnx.Caiman.Core.DTOs.Hour;
using Cnx.Caiman.Core.Entities.QueryEntities.TariffDestinationProduct;
using Cnx.Caiman.Core.DTOs.AssignmentTrip;
using Cnx.Caiman.Core.Entities.QueryEntities.AsignacionViajes;
using Cnx.Caiman.Core.DTOs.FeasibilityAgreement;
using Cnx.Caiman.Core.DTOs.Scripts;
using Cnx.Caiman.Core.DTOs.ProductInterface;
using Cnx.Caiman.Core.DTOs.PrevValidation;
using Cnx.Caiman.Core.Entities.QueryEntities.ValidacionesPrevias;

namespace Cnx.Caiman.Infrastructure.Mappings
{
    public class AutoMapperProfile
    {
         public class AutomapperProfile: Profile
        {
            public AutomapperProfile()
            {
                #region
                CreateMap<Pagina, PageDto>().ReverseMap();
                #endregion

                #region Concreto
                CreateMap<Demanda, DemandDto>().ReverseMap();
                CreateMap<RelUso, RelUseConcretDto>().ReverseMap();
                CreateMap<Destino, DestinationConcretDto>().ReverseMap();
                CreateMap<Producto, ProductConcretDto>().ReverseMap();
                CreateMap<Origen,OriginDistanceDto>()
                    .ForMember(dest=> dest.NDistancia, opt=> opt.MapFrom(src => src.Enlace.NDistancia))
                    .ForMember(dest => dest.NTarifa, opt => opt.MapFrom(src => src.Enlace.NTarifa))
                    .ForMember(dest => dest.NDistanciaHoras, opt => opt.MapFrom(src => src.Enlace.NDistanciaHoras))
                    .ReverseMap();

                #endregion
                #region Caiman
                CreateMap<Usuario, UserDto>().ReverseMap();
                CreateMap<Cedi, CediDto>().ReverseMap();
                CreateMap<RelUsuarioPermiso, RelUserPermissionsDto>().ReverseMap();

                CreateMap<Transportista, ShipperDto>().ReverseMap();
                CreateMap<TransportistaGeneral, GeneralShipperDto>()
                .ForMember(dest => dest.TransportistaLotes, opt=> opt.MapFrom(src=> src.TransportistaLotes))
                .ReverseMap();

                CreateMap<LogInterfaz, LogInterfazDto>().ReverseMap();

                CreateMap<OrigenGeneral, GeneralOriginDto>()
                .ForMember(dest => dest._Medicion, opt=> opt.MapFrom(src=> src._Medicion))
                .ReverseMap();


                CreateMap<Medicion, MeasurementDto>().ReverseMap();
                CreateMap<Zona, ZoneDto>()
                .ForMember(dest => dest.Medicion, opt=> opt.MapFrom(src=> src.Medicion))
                .ReverseMap();
                
                CreateMap<SubZona, SubZoneDto>().ReverseMap();
                
                CreateMap<ScriptsParams, ScriptsParamsDto>().ReverseMap();
                CreateMap<Script, ScriptDto>()
                .ForMember(dest => dest.Params, opt=> opt.MapFrom(src=> src.Params))
                .ReverseMap();

                CreateMap<ProductoInterfazExcepcion, ProductInterfaceExceptionDto>().ReverseMap();
                CreateMap<ProductoInterfaz, ProductInterfaceDto>().ReverseMap();
                #endregion
                #region Administracion/Entidades
                // origenes
                CreateMap<OrigenUbicacion, OriginLocationDto>().ReverseMap();
                CreateMap<DestinoUbicacion, DestinationLocationDto>().ReverseMap();

                CreateMap<Origen, OriginDto>()
                .ForMember(dest => dest.Cedi, opt=> opt.MapFrom(src=> src.Cedi))
                .ForMember(dest => dest.OrigenUbicacion, opt=> opt.MapFrom(src=> src.OrigenUbicacion))
                .ReverseMap();

                 CreateMap<OrigenQuery, OriginQueryDto>().ReverseMap();

                // destinos
                CreateMap<Destino, DestinationDto>()
                .ForMember(dest => dest.Cedi, opt => opt.MapFrom(src => src.Cedi))
                .ForMember(dest => dest.DestinationLocation, opt => opt.MapFrom(src => src.DestinoUbicacion))
                .ForMember(dest => dest.SubZona, opt => opt.MapFrom(src => src.SubZona))
                .ReverseMap();

                CreateMap<DestinoQuery, DestinationDto>()
                .ForMember(dest => dest.Cedi, opt => opt.MapFrom(src => src.Cedi))
                .ForMember(dest => dest.DestinationLocation, opt => opt.MapFrom(src => src.DestinoUbicacion))
                .ForMember(dest => dest.SubZona, opt => opt.MapFrom(src => src.SubZona))
                .ReverseMap();

                CreateMap<RelUso, RelUsoDto>()
                .ForMember(dest => dest.Destino, opt => opt.MapFrom(src => src.Destino))
                .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src.Producto))
                .ReverseMap();

                CreateMap<RelDestinoInventario, RelDestinoInventarioDto>().ReverseMap();


                CreateMap<Destino, DestinationWithoutDistanceDto>();
                // productos
                CreateMap<RelProduccion, RelProductionDto>()
                .ForMember(dest => dest.Producto, opt=> opt.MapFrom(src=> src.Producto))
                .ForMember(dest => dest.Origen, opt=> opt.MapFrom(src=> src.Origen))
                .ReverseMap();
                CreateMap<TipoProducto, TypeProductDto>().ReverseMap();
                CreateMap<Producto, ProductDto>()
                .ForMember(dest => dest.TipoProducto, opt=> opt.MapFrom(src=> src.TipoProducto))
                .ReverseMap();
                // distancias
                CreateMap<Distancia, DistanceDto>().ReverseMap();
                #endregion
                
                
                CreateMap<TipoSobreconsumo, TypesCostOverrunDto>().ReverseMap();
                CreateMap<TariffDestinationProductDto, TarifaConsultarDestinoProducto>().ReverseMap();

                #region Agreement
                CreateMap<RelTraduccionRestriccion, RelTranslationRestrictionDto>().ReverseMap();
                CreateMap<Convenio, AgreementsDto>().ReverseMap();
                CreateMap<Restriccion, AgreementDto>().ReverseMap();
                CreateMap<Restriccion2, RestrictionDto>().ReverseMap();
                
                CreateMap<RestriccionTipo, RestrictionTypeDto>().ReverseMap();
                CreateMap<Perfil, Cnx.Caiman.Core.DTOs.Agreement.ProfileAgreementDTO>().ReverseMap();
                CreateMap<ConvenioFrecuencia, FrequencyAgreementDto>().ReverseMap();
                CreateMap<EsqPivPron, EsqPivPronDto>().ReverseMap();
                CreateMap<Destino, DestinationDto>().ReverseMap();
                CreateMap<Horario, HourDto>().ReverseMap();
                #endregion

                #region ManualPlan
                CreateMap<PlanManual, ManualPlanDto>().ReverseMap();
                CreateMap<PlanManualResult, ManualPlanInfoDto>().ReverseMap();
                CreateMap<ViajeManualResult, ManualPlanTripDto>().ReverseMap();
                CreateMap<ViajeManualSap, ManualTripSapDto>().ReverseMap();
                #endregion

                #region Offer
                CreateMap<OfertaResult, ListOfferDto>().ReverseMap();
                CreateMap<InfoCapacidadesResult, InfoCapacityDto>().ReverseMap();
                CreateMap<InfoCapacidadesDetalleResult, InfoCapacityDetailsDto>().ReverseMap();
                CreateMap<DestinoQuery, DestinationWithoutDistanceDto>().ReverseMap();
                CreateMap<OfertaTransporteResult, TransportOfferDto>().ReverseMap();

                #endregion

                #region usuario
                CreateMap<UsuarioZona, UserZoneDto>().ReverseMap();
                CreateMap<UsuarioPerfil, UserProfileDto>().ReverseMap();
                CreateMap<Pagina, UserPermitDto>().ReverseMap();
                CreateMap<RelUsuarioPermisoAdmin, UserDailyPlanPermisionDto>().ReverseMap();
                #endregion

                #region AssigPlan
                CreateMap<PlanAsignacion, AssigPlanDto>().ReverseMap();
                CreateMap<ViajeSap, ManualTripSapDto>().ReverseMap();
                CreateMap<ValidacionesPreviasListar, ValidacionesPreviasListDto>().ReverseMap();
                CreateMap<ViajeSapFile, ManualTripSapDto>().ReverseMap();

                #endregion

                #region product type
                CreateMap<TipoProducto, ProductTypeDto>().ReverseMap();
                #endregion

                #region catalog
                CreateMap<CatalogQuerys, CatalogDto>().ReverseMap();
                #endregion

                #region AssigTrip
                CreateMap<ViajeListarCostosResult, TripListCostsDto>().ReverseMap();
                CreateMap<ViajeListarResult, TripListDto>().ReverseMap();
                CreateMap<ViajeListarEdicionResult, ListEditTripDto>().ReverseMap();
                CreateMap<RestriccionListarIncumplidoResult, RestrictionListUnfulfilledDto>().ReverseMap();
                #endregion
            }
        }
    }
}