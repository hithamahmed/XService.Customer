using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoTasks.Commons.DTO;
using TodoTasks.Core.Interface;

namespace Documents.Tracker.UI.Web.Pages.ServiceTasks
{
    public class ManageTasksModel : PageModel
    {
        private readonly ITasksCore _tasksCore ;
        public ICollection<TasksDTO> todoTasks { get; set; }
        public ManageTasksModel(ITasksCore tasksCore)
        {
            _tasksCore = tasksCore;
        }

        public async Task<IActionResult> OnGet()
        {
            todoTasks = await _tasksCore.GetTasks();
            return Page();
        }

        public IActionResult OnGetAddEditTask(int RefId)
        {
            TasksDTO serviceTask = new TasksDTO();
            if (RefId > 0)
            {
            }
            return Partial("_AddEditTask", serviceTask);
        }
        public async Task<IActionResult> OnPostSaveCategory(TasksDTO tasks)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();


                int i = await _tasksCore.AddTask(tasks);

                return RedirectToPage();
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}