//using Documents.Tracker.Core.DocumentCore.Consumers;
//using Documents.Tracker.Core.FrontCore;
using Application.Notifications.Core.Config;
using Application.XIdentity.Core.Setup;
using Documents.Tracker.Core.CompositeServices;
using Documents.Tracker.Core.CompositeServices.Services.Documents;
using Documents.Tracker.Core.CompositeServices.Services.Orders;
using Documents.Tracker.Core.Repositories;
using Documents.Tracker.Data.Setup;
using General.App.Consumers.Core;
using General.App.Consumers.Core.Config;
using General.App.Consumers.Core.Repositories;
using General.Services.Core.Setup;
using ManageFiles.Core.Setup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Orders.Core.Config;
using System;
using System.Linq;
using System.Reflection;

namespace Documents.Tracker.Core.Config
{
    public static class DocumentCoreConfig
    {
        public static IServiceCollection DocumentCoreSetup(this IServiceCollection services, string connectionstring)
        {
            services.ConsumerCoreSetup();
            services.AddNotificationsServices();
            services.AddIdentityServices(connectionstring);
            services.AddGeneralServices(connectionstring);
            services.AddDocumentContext(connectionstring);
            //services.AddTransient<IConsumers, ConsumerServices>();
            services.AddOrdersServices(connectionstring);
            services.AddManageFilesServices(connectionstring);

            //services.AddScoped<IGeneralCore, CountryGeneralCore>();
            //services.AddScoped<IConsumersProfileCore, ClientsGeneralCore>();
            services.AddTransient<IServiceRequiredDocumentsCore, ServiceRequiredDocumentsCore>();
            services.AddTransient<IServiceIssuedDocumentsCore, ServiceIssuedDocumentsCore>();
            //services.AddScoped<IConsumersServicesCore,ConsumerServicesCore>();
            //services.AddScoped<IConsumerFrontServices, ConsumersFrontServices>();

            services.AddTransient<IQueryGeneralService, GeneralServices>();
            services.AddTransient<ICommandGeneralService, GeneralServices>();

            services.AddTransient<IQueryConsumersServices, ConsumersServices>();
            services.AddTransient<ICommandConsumerServices, ConsumersServices>();

            services.AddTransient<IQueryProductDocuments, ProductsServices>();
            services.AddTransient<ICommandProductDocuments, ProductsServices>();
            services.AddTransient<IQueryProductServices, ProductsServices>();

            services.AddTransient<IProductsCore, ProductsCore>();
            services.AddTransient<IDocumentFilesService, DocumentsFileServices>();

            services.AddTransient<IQueryOrderService, OrdersServices>();
            services.AddTransient<ICommandOrderService, OrdersServices>();

            //services.AddDbContext<DocumentContext>(options =>
            //{
            //    options.UseSqlServer(connectionstring,
            //    sqlServerOptionsAction: sqlOptions =>
            //    {
            //        sqlOptions.
            //         MigrationsAssembly("Documents.Tracker.Data");
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

            return services;
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
