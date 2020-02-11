using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delegators.Commons.DTO;
using Delegators.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoTasks.Commons.DTO;
using TodoTasks.Core.Interface;

namespace Documents.Tracker.UI.Web.Pages.ServiceTasks
{
    public class AddTasksModel : PageModel
    {
        private readonly ITasksCore _tasksCore;
        private readonly IUserDelegatorCore _userDelegatorCore ;

        [BindProperty]
        public TasksDTO ServiceTask { get; set; }
  
        public ICollection<UserDelegatorDTO> UserDelegatorsDTO { get; set; }
 
        public ICollection<TaskTypesDTO> taskTypes { get; set; }


        public AddTasksModel(
            IUserDelegatorCore userDelegatorCore,
            ITasksCore tasksCore)
        {
            _userDelegatorCore = userDelegatorCore;
            _tasksCore = tasksCore;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            //ServiceTask = new TasksDTO();
            if (id.HasValue && id.Value > 0)
            {
                ServiceTask = await _tasksCore.GetSingleTask(id.Value);
            }
            UserDelegatorsDTO = await _userDelegatorCore.GetUsersDelegators();
            taskTypes = await _tasksCore.GetTaskTypes();

            return Page();
        }
        public async Task<IActionResult> OnPostSaveTask()
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();

                if(ServiceTask.Id == 0)
                    ServiceTask.StatusId = 1;

                int i = await _tasksCore.AddTask(ServiceTask);

                return RedirectToPage( new { id = i }) ;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}