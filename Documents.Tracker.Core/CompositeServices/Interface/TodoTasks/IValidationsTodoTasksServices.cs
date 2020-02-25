using Documents.Tracker.Core.DTO.TodoTasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices
{
    public interface IValidationsTodoTasksServices
    {
        Task<bool> IsTaskServiceExists(TaskLocationOTO taskLocation);
    }
}
