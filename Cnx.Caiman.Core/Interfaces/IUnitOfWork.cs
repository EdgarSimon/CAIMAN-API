using System;
using Cnx.Caiman.Core.Interfaces.Repositories;

namespace Cnx.Caiman.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository UserRepository 
        { 
            get; 
        }

        ICediRepository CediRepository 
        { 
            get; 
        }

        IZoneRepository ZoneRepository 
        { 
            get; 
        }

        IOriginRepository OriginRepository 
        { 
            get; 
        }
        IShipperRepository ShipperRepository 
        { 
            get; 
        }
        IGeneralShipperRepository GeneralShipperRepository 
        { 
            get; 
        }

        IGeneralOriginRepository GeneralOriginRepository 
        { 
            get; 
        }

        ISubZoneRepository SubZoneRepository
        {
            get;
        }

        IDestinationRepository DestinationRepository
        {
            get;
        }
        
        IAgreementRepository AgreementRepository
        {
            get;
        }

        IDistanceRepository DistanceRepository
        {
            get;
        }
        IRelProductionRepository RelProductionRepository
        {
            get;
        }
        IProductRepository ProductRepository
        {
            get;
        }
        ICostOverrunRepository CostOverrunRepository
        {
            get;
        }
        ICustomerRepository CustomerRepository
        {
            get;
        }
        IManualPlanRepository PlanManualRepository
        {
            get;
        }
        IOfferRepository OfferRepository
        {
            get;
        }
        IConcretRepository ConcretRepository
        {
            get;
        }
        ISicadiRepository SicadiRepository
        {
            get;
        }
        IProcFileRepository ProcExcelRepository
        {
            get;
        }
        IAssigPlanRepository AssigPlanRepository
        {
            get;
        }
        IProductTypeRepository ProductTypeRepository
        {
            get;
        }
        IElementAssigPlanRepository ElementAssigPlanRepository
        {
            get;
        }
        IPrevValidationsRepository PrevValidationsRepository
        {
            get;
        }
        ICatalogRepository CatalogRepository
        {
            get;
        }

        ITransportOfferRepository TransportOfferRepository
        {
            get;
        }
        IAssignmentTripRepository AssignmentTripRepository
        {
            get;
        }

        IScriptRepository ScriptRepository
        {
            get;
        }
        IProductInterfaceExceptionRepository ProductInterfaceExceptionRepository
        {
            get;
        }
        IProductInterfaceRepository ProductInterfaceRepository
        {
            get;
        }

        ILogErrorRepository LogErrorRepository
        {
            get;
        }
    }
}