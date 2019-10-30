using Application.Infrastructure.MSSQL.Config;
using ApplicationLocalizations.Config;
using Documents.Tracker.Core.Config;
using General.Services.Core.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Globalization;


namespace Documents.Tracker.UI.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });
            
           
            //services.AddDbContext<GeneralContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            //    sqlServerOptionsAction: sqlOptions =>
            //    {
            //        sqlOptions.
            //         MigrationsAssembly("Application.Infrastructure.MSSQL");

            //        //Configuring Connection Resiliency:
            //        sqlOptions.
            //        EnableRetryOnFailure(maxRetryCount: 5,
            //        maxRetryDelay: TimeSpan.FromSeconds(30),
            //        errorNumbersToAdd: null);

            //    });

            //    //Changing default behavior when client evaluation occurs to throw.
            //    //Default in EFCore would be to log warning when client evaluation is done.
            //    //options.ConfigureWarnings(warnings => warnings.Throw(
            //    //    RelationalEventId.QueryClientEvaluationWarning));
            //});
            string defConn = Configuration.GetConnectionString("DefaultConnection");
            //ApplicationConfig.AppCoreContextSetup(services, defConn);
            //GeneralConfigContexts.GeneralContextSetup(services, defConn);
            //DocumentContextConfig.DocumentConfigContext(services, defConn);
            //ConfigLocalization.AppCoreContextSetup(services, defConn);

            //IMapper mapper = MapperSetup.IMapperSetup();
            //services.AddSingleton(mapper);

            //IMapper Docmapper = Documents.Tracker.Core.Config.Mapper.MapperSetup.IMapperSetup();
            //services.AddSingleton(Docmapper);


            //services.AddScoped<ICountries, CountryServices>();
            //services.AddScoped<IServicesCategory, ServiceCategoryServices>();

            //services.AddScoped<IServiceRequiredDocumentsCore, ServiceRequiredDocumentsCore>();
            //services.AddScoped<IServiceIssuedDocumentsCore, ServiceIssuedDocumentsCore>();
            services.ApplicationInfraSetup(defConn);
            services.AppLocalizationSetup(defConn);
            services.DocumentCoreSetup(defConn);
            services.GeneralContextSetup(defConn);

            //var mapperconfig = new MapperConfiguration(confg =>
            //confg.AddMaps(
            //    new[] { "Documents.Tracker.Core", "General.Services.Core" }
            //    ));
            //IMapper Docmapper = mapperconfig.CreateMapper();
            //services.AddSingleton(Docmapper);
            

            services.AddLocalization();
            services.Configure<RequestLocalizationOptions>(
                       options =>
                       {
                           var supportedCultures = new List<CultureInfo>
                               {new CultureInfo("en-US"),new CultureInfo("ar-KW") };

                           options.DefaultRequestCulture = new RequestCulture(culture: "ar-KW", uiCulture: "ar-KW");
                           options.SupportedCultures = supportedCultures;
                           options.SupportedUICultures = supportedCultures;

                               // You can change which providers are configured to determine the culture for requests, or even add a custom
                               // provider with your own logic. The providers will be asked in order to provide a culture for each request,
                               // and the first to provide a non-null result that is in the configured supported cultures list will be used.
                               // By default, the following built-in providers are configured:
                               // - QueryStringRequestCultureProvider, sets culture via "culture" and "ui-culture" query string values, useful for testing
                               // - CookieRequestCultureProvider, sets culture via "ASPNET_CULTURE" cookie
                               // - AcceptLanguageHeaderRequestCultureProvider, sets culture via the "Accept-Language" request header
                               //options.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
                           });

            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24;
                    ctx.Context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            });
            app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
