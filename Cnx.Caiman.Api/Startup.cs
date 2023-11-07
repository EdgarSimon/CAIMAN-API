using Cnx.Caiman.Infrastructure.Extensions;
using Cnx.Caiman.Infrastructure.Handler;
using Cnx.Caiman.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag.AspNetCore;
using System;

namespace Cnx.Caiman.Api
{
    public class Startup
    { 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    policyBuilder => policyBuilder.WithOrigins("*")
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddControllers();

            services.AddDbContext(Configuration)
                .AddDefaultConfigurations(Configuration)
                .AddFilters()
                .AddServices();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSwagger(Configuration);

            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("V1", new OpenApiInfo() { Title = "Caiman Api", Version = "v1" });
            //    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            //    {
            //        Description = "OAuth2.0 Auth Code with PKCE",
            //        Name = "oauth2",
            //        Type = SecuritySchemeType.OAuth2,
            //        Flows = new OpenApiOAuthFlows
            //        {
            //            AuthorizationCode = new OpenApiOAuthFlow
            //            {
            //                AuthorizationUrl = new Uri(this.Configuration.GetSection("AzureAd")["InstanceURL"]),
            //                TokenUrl = new Uri(this.Configuration.GetSection("AzureAd")["InstanceToken"]),
            //                Scopes = new Dictionary<string, string>
            //                { 
            //                    { this.Configuration.GetSection("AzureAd")["ApiScope"], "read the api" }
            //                }
            //            }
            //        }
            //    });

            //    options.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
            //            },
            //            new[] { this.Configuration.GetSection("AzureAd")["ApiScope"] }
            //        }
            //    });

            //    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

            //    options.OperationFilter<OpenApiParameterIgnoreFilter>();
            //});



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                await GlobalExceptionHandler.ExcepctionHandler(context);
            }));

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c =>
                //{
                //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "swaggerAADdemo v1");
                //    c.OAuthClientId(this.Configuration.GetSection("AzureAd")["ClientId"]);
                //    c.OAuthUsePkce();
                //    c.OAuthScopeSeparator(" ");
                //});
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseSwagger();
            //app.UseSwaggerUI(options => {
            //    options.SwaggerEndpoint("swagger/V1/swagger.json", "Caiman Api");
            //    options.RoutePrefix = string.Empty;
            //});
            app.UseOpenApi();
            //app.UseSwaggerUi3(settings =>
            //{
            //    settings.DocumentTitle = "Caiman API";
            //    settings.OAuth2Client = new OAuth2ClientSettings
            //    {
            //        // Use the same client id as your application.
            //        // Alternatively you can register another application in the portal and use that as client id
            //        // Doing that you will have to create a client secret to access that application and get into space of secret management
            //        // This makes it easier to access the application and grab a token on behalf of user
            //        ClientId = Configuration["AzureAd:ClientId"],
            //        AppName = "SubHub-Swagger-UI-Client",
            //    };
            //});
            app.UseSwaggerUI(
                  c =>
                  {
                      c.SwaggerEndpoint("/swagger/v1/swagger.json", "CD Api");
                      c.OAuthClientId(Configuration["AzureAd:ClientId"]);
                      c.OAuthScopes(Configuration["AzureAd:ApiScope"]);
                      c.RoutePrefix = String.Empty;
                  });

            app.UseMiddleware<ParamsMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}