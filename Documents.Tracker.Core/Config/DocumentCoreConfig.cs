
using Application.Notifications.Core.Config;
using Application.XIdentity.Core.Setup;
using Delegators.Core.Setup;
using Documents.Tracker.Core.CompositeServices;
using Documents.Tracker.Core.CompositeServices.Interface.Employees;
using Documents.Tracker.Core.CompositeServices.Services.Documents;
using Documents.Tracker.Core.CompositeServices.Services.Employees;
using Documents.Tracker.Core.CompositeServices.Services.Orders;
using Documents.Tracker.Core.CompositeServices.Services.TodoTasks;
using Documents.Tracker.Core.Repositories;
using Documents.Tracker.Data.Setup;
using General.App.Consumers.Core.Config;
using General.Employees.Core.Setup;
using General.Services.Core.Setup;
using ManageFiles.Core.Setup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Orders.Core.Config;
using System;
using System.Linq;
using System.Reflection;
using Todo.Tasks.Data.Config;
using TodoTasks.Core.Setup;

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
            services.AddOrdersServices(connectionstring);
            services.AddManageFilesServices(connectionstring);
            services.AddTodoTasksCore(connectionstring);
            services.AddDelegatorsCore(connectionstring);
            services.AddEmployeeCore(connectionstring);
 
            services.AddTransient<IServiceRequiredDocumentsCore, ServiceRequiredDocumentsCore>();
            services.AddTransient<IServiceIssuedDocumentsCore, ServiceIssuedDocumentsCore>();
 
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


            //services.AddTransient<TodoTasksCore>();
            //services.AddTransient<IQueryTodoTasksServices>(x => x.GetRequiredService<TodoTasksCore>());
            //services.AddTransient<ICommandTodoTasksServices>(x => x.GetRequiredService<TodoTasksCore>());

            services.AddTransient<IQueryTodoTasksServices, TodoTasksCore>();
            services.AddTransient<ICommandTodoTasksServices, TodoTasksCore>();

            services.AddTransient<IEmployeeDelegatorService, EmployeeDelegatorService>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            //services.AddTransient<IValidationsTodoTasksServices, TodoTasksValidationsCore>();
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
            {
                services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
            }
        }
    }

}
