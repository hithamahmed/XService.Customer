using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Documents.Tracker.Data.Setup
{
    public  static class DocumentSetup
    {
        public static IServiceCollection AddDocumentContext(this IServiceCollection services, string connectionstring)
        {

            services.AddDbContext<DocumentContext>(options =>
            {
                options.UseSqlServer(connectionstring,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.
                     MigrationsAssembly(typeof(DocumentContext).Assembly.FullName);//"General.Services.Core"
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

            return services;
        }

    }
}
