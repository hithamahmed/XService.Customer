using Documents.Tracker.Core.Config.Mapper;
//using Documents.Tracker.Core.DocumentCore.Consumers;
//using Documents.Tracker.Core.FrontCore;
using Documents.Tracker.Data;
using General.App.Consumers.Core.Config;
using General.Services.Core.Setup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Documents.Tracker.Core.Config
{
    public static class DocumentCoreConfig
    {
        public static IServiceCollection DocumentCoreSetup(this IServiceCollection services, string connectionstring)
        {
            //services.AddScoped<IGeneralCore, CountryGeneralCore>();
            //services.AddScoped<IConsumersProfileCore, ClientsGeneralCore>();
            services.AddScoped<IServiceRequiredDocumentsCore, ServiceRequiredDocumentsCore>();
            services.AddScoped<IServiceIssuedDocumentsCore, ServiceIssuedDocumentsCore>();
            //services.AddScoped<IConsumersServicesCore,ConsumerServicesCore>();
            //services.AddScoped<IConsumerFrontServices, ConsumersFrontServices>();

            services.AddScoped<IQueryGeneralService, GeneralServices>();
            services.AddScoped<ICommandGeneralService, GeneralServices>();

            services.AddScoped<IQueryConsumersServices, ConsumersServices>();
            services.AddScoped<ICommandConsumerServices, ConsumersServices>();

            services.AddScoped<IQueryProductDocuments, ProductsServices> ();
            services.AddScoped<ICommandProductDocuments, ProductsServices> ();
            //services.AddSingleton(MapperCore.Mapper);

            services.ClientsCoreSetup(connectionstring);
            services.GeneralContextSetup(connectionstring);

            return services.AddDbContext<DocumentContext>(options =>
            {
                options.UseSqlServer(connectionstring,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.
                     MigrationsAssembly("Documents.Tracker.Data");
                    //Configuring Connection Resiliency:
                    sqlOptions.
                    EnableRetryOnFailure(maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);

                });

                //Changing default behavior when client evaluation occurs to throw.
                //Default in EFCore would be to log warning when client evaluation is done.
                //options.ConfigureWarnings(warnings => warnings.Throw(
                //    RelationalEventId.QueryClientEvaluationWarning));
            });
        }
        public static void RegisterAllTypes<T>(this IServiceCollection services, Assembly[] assemblies,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var typesFromAssemblies = assemblies
                .SelectMany(a => a.DefinedTypes
                .Where(x => x.GetInterfaces()
                .Contains(typeof(T))));
            foreach (var type in typesFromAssemblies)
                services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
        }
    }
    
}
