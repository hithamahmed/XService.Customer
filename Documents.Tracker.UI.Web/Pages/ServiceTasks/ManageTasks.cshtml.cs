using Documents.Tracker.Core.CompositeServices;
using Documents.Tracker.Core.DTO.TodoTasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoTasks.Commons;
using TodoTasks.Commons.DTO;

namespace Documents.Tracker.UI.Web.Pages.ServiceTasks
{
    public class ManageTasksModel : PageModel
    {
        //private readonly ITasksCore _tasksCore ;
         private readonly IQueryTodoTasksServices _queryTodoTasksCore;
        private readonly ICommandTodoTasksServices _commandTodoTasks;

        public ICollection<TaskOTO> todoTasks { get; set; }
        public ManageTasksModel(
            IQueryTodoTasksServices queryTodoTasksCore,
            ICommandTodoTasksServices todoTasksCore)
        {
            _queryTodoTasksCore = queryTodoTasksCore;
            _commandTodoTasks = todoTasksCore;
        }

        public async Task<IActionResult> OnGet()
        {
            todoTasks = await _queryTodoTasksCore.GetTodoTasksList();
            return Page();
        }

        public async Task<IActionResult> OnGetTasksByDelegator(int DelegatorId)
        {
            todoTasks = await _queryTodoTasksCore.GetTodoTasksList(DelegatorId);
            return Page();
        }
        //public async Task<IActionResult> OnGetAddEditTaskAsync(int RefId)
        //{
        //    TasksDTO serviceTask = new TasksDTO();
        //    if (RefId > 0)
        //    {
        //        serviceTask = await _tasksCore.GetSingleTask(RefId);
        //    }
        //    return Partial("_AddEditTask", serviceTask);
        //}
        public async Task<IActionResult> OnPostSaveCategory(TaskOTO tasks)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();

                int i = await _commandTodoTasks.AddEditTodoTask(tasks);
                //int i = await _tasksCore.AddTask(tasks);

                return RedirectToPage();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<IActionResult> OnPostSetTaskStatus(int TaskId, int statusid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToPage();
                }
                TaskEnums.TaskStatus taskStatus = (TaskEnums.TaskStatus)statusid;
                var task = await _commandTodoTasks.SetTaskStatus(TaskId, taskStatus);
                return RedirectToPage();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}