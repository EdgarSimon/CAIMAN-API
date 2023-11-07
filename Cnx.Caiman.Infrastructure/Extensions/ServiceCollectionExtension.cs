using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Cnx.Caiman.Core.Interfaces;
using Cnx.Caiman.Core.Interfaces.Providers;
using Cnx.Caiman.Core.Interfaces.Services;
using Cnx.Caiman.Core.Services;
using Cnx.Caiman.Infrastructure.Filters;
using Cnx.Caiman.Infrastructure.Middleware;
using Cnx.Caiman.Infrastructure.Providers;
using Cemex.Core.Data;
using Cemex.Core.Entities;
using Cemex.Core.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Http;
using System.Linq;
using NSwag;
using System.Collections.Generic;
using NSwag.Generation.Processors.Security;

namespace Cnx.Caiman.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IDbConnection>(z => new SqlConnection(Configuration.GetConnectionString("CAIMANDB")));
            services.AddTransient<IDbContext, DbContext>();

            return services;
        }

        public static IServiceCollection AddDefaultConfigurations(this IServiceCollection services,  IConfiguration Configuration)
        {
            services.Configure<PaginationConfiguration>(Configuration.GetSection("Pagination"));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ParamsMiddleware>();
            //providers
            services.AddTransient<IRemoteConnection, RemoteConnection>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICediService, CediService>();
            services.AddTransient<IGeneralShipperService, GeneralShipperService>();
            services.AddTransient<IGeneralOriginService, GeneralOriginService>();
            services.AddTransient<IZoneService, ZoneService>();
            services.AddTransient<IShipperService, ShipperService>();
            services.AddTransient<IOriginService, OriginService>();
            services.AddTransient<ICostOverrunService, CostOverrunService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IDestinationService, DestinationService>();
            services.AddTransient<IRelProductionService, RelProductionService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProcFileService, ProcFileService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ISubZoneService, SubZoneService>();
            services.AddTransient<IApiResponseFactory, ApiResponseFactory>();
            services.AddTransient<IAgreementService, AgreementService>();
            services.AddTransient<IDistanceService, DistanceService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IManualPlanService, ManualPlanService>();
            services.AddTransient<IOfferService, OfferService>();
            services.AddTransient<IConcretService, ConcretService>();
            services.AddTransient<ISicadiService, SicadiService>();
            services.AddTransient<IAssigPlanService, AssigPlanService>();
            services.AddTransient<IProductTypeService, ProductTypeService>();
            services.AddTransient<IElementAssigPlanService, ElementAssigPlanService>();
            services.AddTransient<IPrevValidationsService, PrevValidationsService>();
            services.AddTransient<ICatalogService, CatalogService>();
            services.AddTransient<ITransportOfferService, TransportOfferService>();
            services.AddTransient<IAssignmentTripService, AssignmentTripService>();
            services.AddTransient<IScriptService, ScriptService>();
            services.AddTransient<IProductInterfaceExceptionService, ProductInterfaceExceptionService>();
            services.AddTransient<IProductInterfaceService, ProductInterfaceService>();
            services.AddSingleton<IUserCacheService, UserCacheService>();
            services.AddTransient<ILogErrorService, LogErrorService>();
            return services;
        }
        public static IServiceCollection AddFilters(this IServiceCollection services)
        {
            services.AddMvc(options => {
            }).AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            services.AddControllers(options => {
                options.Filters.Add<GlobalExceptionFilter>();
            })
            .AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            return services;
        }

        public static IServiceCollection AddAuthorization(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration);

            // Creating policies that wraps the authorization requirements
            services.AddAuthorization();

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddOpenApiDocument(document =>
            {
                document.AddSecurity("bearer", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.OAuth2,
                    Description = "Azure AAD Authentication",
                    Flow = OpenApiOAuth2Flow.Implicit,
                    Flows = new NSwag.OpenApiOAuthFlows()
                    {
                        Implicit = new NSwag.OpenApiOAuthFlow()
                        {
                            Scopes = new Dictionary<string, string>
                        {
                            { $"{Configuration["AzureAd:ApiScope"]}", "Access Application" },
                        },
                            AuthorizationUrl = $"{Configuration["AzureAd:Instance"]}{Configuration["AzureAd:TenantId"]}/oauth2/v2.0/authorize",
                            TokenUrl = $"{Configuration["AzureAd:Instance"]}{Configuration["AzureAd:TenantId"]}/oauth2/v2.0/token",
                        },

                    },

                });

                // To add bearer token in request to APIs with Authorize attribute
                document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("bearer"));
            });

            return services;
        }
    }
}