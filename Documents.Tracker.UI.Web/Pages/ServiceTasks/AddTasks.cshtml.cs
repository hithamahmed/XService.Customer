using Delegators.Commons.DTO;
using Delegators.Core.Interface;
using Documents.Tracker.Core;
using Documents.Tracker.Core.CompositeServices;
using Documents.Tracker.Core.DTO;
using Documents.Tracker.Core.DTO.Orders;
using Documents.Tracker.Core.DTO.TodoTasks;
using Documents.Tracker.UI.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoTasks.Commons;
using TodoTasks.Commons.DTO;

namespace Documents.Tracker.UI.Web.Pages.ServiceTasks
{
    public class AddTasksModel : PageModel
    {
        private readonly IQueryTodoTasksServices _queryTodoTasks;
        private readonly ICommandTodoTasksServices _commandTodoTasks;

        private readonly IUserDelegatorCore _userDelegatorCore;
        private readonly IQueryGeneralService _generalService;
        private readonly IQueryOrderService _orderservice;

        [BindProperty]
        public TasksDTO ServiceTask { get; set; }
        [BindProperty]
        public TaskLocationOTO TaskLocationServices { get; set; }
        //[BindProperty]
        //public TaskLocationViewModel TaskServiceModel { get; set; }

        [BindProperty]
        public ICollection<TaskLocationOTO> OrderServicesList { get; set; }

        public ICollection<LocationAreasOTO> Locations { get; set; }
        public ICollection<UserDelegatorDTO> UserDelegatorsDTO { get; set; }
        public ICollection<TaskTypeDTO> taskTypes { get; set; }


        public AddTasksModel(
            ICommandTodoTasksServices commandTodoTasks,
            IQueryOrderService orderservice,
            IQueryGeneralService generalService,
            IUserDelegatorCore userDelegatorCore,
            IQueryTodoTasksServices queryTodoTasks)
        {
            _orderservice = orderservice;
            _generalService = generalService;
            _userDelegatorCore = userDelegatorCore;
            _queryTodoTasks = queryTodoTasks;
            _commandTodoTasks = commandTodoTasks;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            ServiceTask = new TasksDTO();
            TaskLocationServices = new TaskLocationOTO();
            //TaskServiceModel = new TaskLocationViewModel();

            if (id.HasValue && id.Value > 0)
            {
                ServiceTask = await _queryTodoTasks.GetSingleTodoTask(id.Value);
                TaskLocationServices.TaskID = ServiceTask.Id;
            }
            UserDelegatorsDTO = await _userDelegatorCore.GetUsersDelegators();
            Locations = await _generalService.GetLocationList(1);
            taskTypes = await _queryTodoTasks.GetTodoTaskTypes();

            return Page();
        }
        public async Task<IActionResult> OnPostSaveTask()
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();

                if (ServiceTask.Id == 0)
                    ServiceTask.StatusId = 1;

                int i = await _commandTodoTasks.AddEditTodoTask(ServiceTask);

                return RedirectToPage(new { id = i });
            }
            catch (Exception)
            {

                throw;
            }

        }


        //public async Task<IActionResult> OnGetAddEditTaskLocationAsync(int taskid, int id)
        //{
        //    TaskLocation = new TaskLocationViewModel();
        //    TaskLocation.TaskLocationService.TaskID = taskid;

        //    if (id > 0)
        //    {
        //        TaskLocation.TaskLocationService = await _queryTodoTasks.GetSingleTodoTaskLocation(id);
        //    }
        //    TaskLocation.LocationAreas = await _generalService.GetLocationList(1);
        //    TaskLocation.OrderProducts = await _orderservice.GetOrdersByStatus((int)TaskEnums.TaskStatus.Submited);
        //    //TaskLocation.TaskStatuses = await _tasksCore.GetTodoTastStatus();

        //    return Partial("_AddEditTaskLocation", TaskLocation);
        //}

        public async Task<IActionResult> OnPostSaveTaskLocation()
        {
            try
            {

                if (!ModelState.IsValid)
                    return RedirectToPage(new { id = TaskLocationServices.TaskID });

                var da = OrderServicesList.ToList();

                int i = await _commandTodoTasks.AddEditTodoTaskLocation(TaskLocationServices);

                return RedirectToPage(new { id = TaskLocationServices.TaskID });
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult OnGetOrderItems(int id)
        {
            try
            {
                return ViewComponent("PendingOrderProductServices", new { orderid = id });
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public async Task<IActionResult> OnPostSetTaskServiceStatus(int TaskServiceId, int statusid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToPage();
                }
                TaskEnums.TaskStatus taskStatus = (TaskEnums.TaskStatus)statusid;
                var taskService = await _commandTodoTasks.SetTaskServiceStatus(TaskServiceId, taskStatus);
                return RedirectToPage(new { id = taskService .TaskID});
            }
            catch (Exception)
            {

                throw;
            }

        }
        public JsonResult OnGetOrderProducts(int orderid)
        {
            try
            {
                if (orderid == 0)
                    return new JsonResult("");

                OrderOTO orderDetails = new OrderOTO();
                IEnumerable<ProductOTO> products = new List<ProductOTO>();

                orderDetails = _orderservice.GetSingleOrder(orderid).Result;
                if (orderDetails != null)
                {
                    if (orderDetails.OrderItems != null)
                    {
                        if (orderDetails.OrderItems.Count() > 0)
                        {
                            products = orderDetails.OrderItems.Select(x => x.Product);
                            var productInfo = products.Select(x => new { id = x.RefId, name = x.Name }).ToList();
                            return new JsonResult(productInfo);
                        }
                    }
                }
                //var locationAreas = builderService.GetAreasByLocationId(Locationid).Result;
                return new JsonResult("");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}