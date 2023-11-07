using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Repositories;
using Cnx.Caiman.Core.Interfaces.Services;
using Cnx.Caiman.Infrastructure.Repositories;
using Cemex.Core.Interfaces;

namespace Cnx.Caiman.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository userRepository;
        private ICediRepository cediRepository;
        private IZoneRepository zoneRepository;
        private IOriginRepository originRepository;
        private ISubZoneRepository subzoneRepository;
        private IShipperRepository shipperRepository;
        private IGeneralShipperRepository generalShipperRepository;
        private IGeneralOriginRepository generalOriginRepository;
        private IDestinationRepository destinationRepository;
        private IAgreementRepository agreementRepository;
        private IDistanceRepository distanceRepository;
        private IRelProductionRepository relProductionRepository;
        private IProductRepository productRepository;
        private ICostOverrunRepository costOverrunRepository;
        private ICustomerRepository customerRepository;
        private IManualPlanRepository planManualRepository;
        private IOfferRepository offerRepository;
        private IConcretRepository concretRepository;
        private ISicadiRepository sicadiRepository;
        private IProcFileRepository procExcelRepository;
        private IAssigPlanRepository assigPlanRepository;
        private IProductTypeRepository productTypeRepository;
        private IElementAssigPlanRepository elementAssigPlanRepository;
        private IPrevValidationsRepository prevValidationsRepository;
        private ICatalogRepository catalogRepository;
        private ITransportOfferRepository transportOfferRepository;
        private IAssignmentTripRepository assignmentTripRepository;
        private IScriptRepository scriptRepository;
        private IProductInterfaceExceptionRepository productInterfaceExceptionRepository;
        private IProductInterfaceRepository productInterfaceRepository;
        private ILogErrorRepository logErrorRepository;

        private readonly IDbContext context; 

        public UnitOfWork(IDbContext context)
        {
            this.context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if(this.userRepository == null)
                {
                    this.userRepository = new UserRepository(this.context);
                }
                return this.userRepository;
            }
        }

        public ICediRepository CediRepository
        {
            get
            {
                if (this.cediRepository == null)
                {
                    this.cediRepository = new CediRepository(this.context);
                }
                return this.cediRepository;
            }
        }

        public IZoneRepository ZoneRepository
        {
            get
            {
                if (this.zoneRepository == null)
                {
                    this.zoneRepository = new ZoneRepository(this.context);
                }
                return this.zoneRepository;
            }
        }

        public IShipperRepository ShipperRepository

        {
            get
            {
                if(this.shipperRepository == null)
                {
                    this.shipperRepository = new ShipperRepository(this.context);
                }
                return this.shipperRepository;
            }
        }
        public IOriginRepository OriginRepository
        {
            get
            {
                if (this.originRepository == null)
                {
                    this.originRepository = new OriginRepository(this.context);
                }
                return this.originRepository;
            }
        }
        public IGeneralShipperRepository GeneralShipperRepository
        {
            get
            {
                if (this.generalShipperRepository == null)
                {
                    this.generalShipperRepository = new GeneralShipperRepository(this.context);
                }
                return this.generalShipperRepository;
            }
        }

        public IGeneralOriginRepository GeneralOriginRepository
        {
            get
            {
                if (this.generalOriginRepository == null)
                {
                    this.generalOriginRepository = new GeneralOriginRepository(this.context);
                }
                return this.generalOriginRepository;
            }
        }

        public ISubZoneRepository SubZoneRepository
        {
            get
            {
                if (this.subzoneRepository == null)
                {
                    this.subzoneRepository = new SubZoneRepository(this.context);
                }
                return this.subzoneRepository;
            }
        }

        public IDestinationRepository DestinationRepository
        {
            get
            {
                if (this.destinationRepository == null)
                {
                    this.destinationRepository = new DestinationRepository(this.context);
                }
                return this.destinationRepository;
            }
        }
        
        public IAgreementRepository AgreementRepository
        {
            get
            {
                if (this.agreementRepository == null)
                {
                    this.agreementRepository = new AgreementRepository(this.context);
                }
                return this.agreementRepository;
            }
        }

        public IDistanceRepository DistanceRepository
        {
            get
            {
                if (this.distanceRepository == null)
                {
                    this.distanceRepository = new DistanceRepository(this.context);
                }
                return this.distanceRepository;
            }
        }

        public IRelProductionRepository RelProductionRepository
        {
            get
            {
                if (this.relProductionRepository == null)
                {
                    this.relProductionRepository = new RelProductionRepository(this.context);
                }
                return this.relProductionRepository;
            }
        }


        public IProductRepository ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new ProductRepository(this.context);
                }
                return this.productRepository;
            }
        }

        public ICostOverrunRepository CostOverrunRepository
        {
            get
            {
                if (this.costOverrunRepository == null)
                {
                    this.costOverrunRepository = new CostOverrunRepository(this.context);
                }
                return this.costOverrunRepository;
            }
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (this.customerRepository == null)
                {
                    this.customerRepository = new CustomerRepository(this.context);
                }
                return this.customerRepository;
            }
        }

        public IManualPlanRepository PlanManualRepository
        {
            get
            {
                if (this.planManualRepository == null)
                {
                    this.planManualRepository = new ManualPlanRepository(this.context);
                }
                return this.planManualRepository;
            }
        }

        public IOfferRepository OfferRepository
        {
            get
            {
                if (this.offerRepository == null)
                {
                    this.offerRepository = new OfferRepository(this.context);
                }
                return this.offerRepository;
            }
        }

        public IConcretRepository ConcretRepository
        {
            get
            {
                if (this.concretRepository == null)
                {
                    this.concretRepository = new ConcretRepository(this.context);
                }
                return this.concretRepository;
            }
        }
        public ISicadiRepository SicadiRepository
        {
            get
            {
                if (this.sicadiRepository == null)
                {
                    this.sicadiRepository = new SicadiRepository(this.context);
                }
                return this.sicadiRepository;
            }
        }

        public IProcFileRepository ProcExcelRepository
        {
            get
            {
                if (this.procExcelRepository == null)
                {
                    this.procExcelRepository = new ProcFileRepository(this.context);
                }
                return this.procExcelRepository;
            }
        }
        
        public IAssigPlanRepository AssigPlanRepository
        {
            get
            {
                if (this.assigPlanRepository == null)
                {
                    this.assigPlanRepository = new AssigPlanRepository(this.context);
                }
                return this.assigPlanRepository;
            }
        }

        public IProductTypeRepository ProductTypeRepository
        {
            get
            {
                if (this.productTypeRepository == null)
                {
                    this.productTypeRepository = new ProductTypeRepository(this.context);
                }
                return this.productTypeRepository;
            }
        }

        public IElementAssigPlanRepository ElementAssigPlanRepository
        {
            get
            {
                if (this.elementAssigPlanRepository == null)
                {
                    this.elementAssigPlanRepository = new ElementAssigPlanRepository(this.context);
                }
                return this.elementAssigPlanRepository;
            }
        }

        public IPrevValidationsRepository PrevValidationsRepository
        {
            get
            {
                if (this.prevValidationsRepository == null)
                {
                    this.prevValidationsRepository = new PrevValidationsRepository(this.context);
                }
                return this.prevValidationsRepository;
            }
        }
        public ICatalogRepository CatalogRepository
        {
            get
            {
                if (this.catalogRepository == null)
                {
                    this.catalogRepository = new CatalogRepository(this.context);
                }
                return this.catalogRepository;
            }
        }

        public ITransportOfferRepository TransportOfferRepository
        {
            get
            {
                if (this.transportOfferRepository == null)
                {
                    this.transportOfferRepository = new TransportOfferRepository(this.context);
                }
                return this.transportOfferRepository;
            }
        }
        public IAssignmentTripRepository AssignmentTripRepository
        {
            get
            {
                if (this.assignmentTripRepository == null)
                {
                    this.assignmentTripRepository = new AssignmentTripRepository(this.context);
                }
                return this.assignmentTripRepository;
            }
        }

        public IScriptRepository ScriptRepository
        {
            get
            {
                if (this.scriptRepository == null)
                {
                    this.scriptRepository = new ScriptRepository(this.context);
                }
                return this.scriptRepository;
            }
        }

        public IProductInterfaceExceptionRepository ProductInterfaceExceptionRepository
        {
            get
            {
                if (this.productInterfaceExceptionRepository == null)
                {
                    this.productInterfaceExceptionRepository = new ProductInterfaceExceptionRepository(this.context);
                }
                return this.productInterfaceExceptionRepository;
            }
        }

        public IProductInterfaceRepository ProductInterfaceRepository
        {
            get
            {
                if (this.productInterfaceRepository == null)
                {
                    this.productInterfaceRepository = new ProductInterfaceRepository(this.context);
                }
                return this.productInterfaceRepository;
            }
        }

        public ILogErrorRepository LogErrorRepository
        {
            get
            {
                if (this.logErrorRepository == null)
                {
                    this.logErrorRepository = new LogErrorRepository(this.context);
                }
                return this.logErrorRepository;
            }
        }

        public void Dispose()
        {
            if(this.context != null)
            {
                this.context.Dispose();
            }
        }
    }
}