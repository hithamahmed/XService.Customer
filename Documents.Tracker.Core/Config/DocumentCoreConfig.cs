using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DocumentCore.Consumers;
using Documents.Tracker.Data;
using General.App.Consumers.Core.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Documents.Tracker.Core.Config
{
    public static class DocumentCoreConfig
    {
        public static IServiceCollection DocumentCoreSetup(this IServiceCollection services, string connectionstring)
        {


            services.AddScoped<IConsumersCore, ClientsGeneralCore>();
            services.AddScoped<IServiceRequiredDocumentsCore, ServiceRequiredDocumentsCore>();
            services.AddScoped<IServiceIssuedDocumentsCore, ServiceIssuedDocumentsCore>();
            services.AddSingleton(MapperCore.Mapper);

            services.ClientsCoreSetup(connectionstring);

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
    }
}
