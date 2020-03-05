using Application.Infrastructure.MSSQL.Config;
using ApplicationLocalizations.Config;
using Documents.Tracker.Core.Config;
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


            string defConn = Configuration.GetConnectionString("DefaultConnection");

            services.ApplicationInfraSetup(defConn);
            services.AppLocalizationSetup(defConn);
            services.DocumentCoreSetup(defConn);
            //services.RegisterAllTypes<IInvoicingService>(new[] { typeof(Startup).Assembly });
            //services.StaffCoreSetup(defConn);
            //services.OrderContextSetup(defConn);

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
            services.AddResponseCompression();
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
            
            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24 * 30;
                    ctx.Context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                   
                }
            });
            //app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();

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
