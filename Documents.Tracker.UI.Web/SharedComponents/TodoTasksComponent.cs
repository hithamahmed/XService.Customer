using Documents.Tracker.Core.CompositeServices;
using Documents.Tracker.Core.DTO.TodoTasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.UI.Web.SharedComponents
{

    [ViewComponent(Name = "TaskServicesByTaskIdView")]
    public class TodoTasksComponent : ViewComponent
    {
        public ICollection<TaskLocationOTO> TaskLocationServices { get; set; }
        private readonly IQueryTodoTasksServices _queryTodoTasksCore;
        public TodoTasksComponent(IQueryTodoTasksServices queryTodoTasksCore)
        {
            _queryTodoTasksCore = queryTodoTasksCore;
        }
        public async Task<IViewComponentResult> InvokeAsync(int taskId)
        {
            TaskLocationServices = await _queryTodoTasksCore.GetTodoTaskLocationsListByTaskId(taskId);
            return View<ICollection<TaskLocationOTO>>( TaskLocationServices);
        }
    }
    [ViewComponent(Name = "SetTaskStatus")]
    public class SetTaskStatusComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int taskId)
        {
            return View<int>(taskId);
        }
    }

    [ViewComponent(Name = "SetTaskServiceStatus")]
    public class SetTaskServiceStatusComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int taskServiceId)
        {
            return View<int>(taskServiceId);
        }
    }
}
