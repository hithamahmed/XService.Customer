using Documents.Tracker.Core.DTO.TodoTasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoTasks.Commons;
using TodoTasks.Commons.DTO;

namespace Documents.Tracker.Core.CompositeServices
{
    public interface ICommandTodoTasksServices
    {
        Task<int> AddEditTodoTask(TaskOTO tasksDTO);
        Task<int> AddEditTodoTaskLocation(TaskLocationOTO taskLocationOTO);
        Task<TaskLocationOTO> GetSingleTodoTaskLocation(int taskLocationId);
        Task<TaskLocationOTO> SetTaskServiceStatus(int TaskServiceId, TodoTasks.Commons.TaskEnums.TaskStatus taskStatus);
        Task<TaskOTO> SetTaskStatus(int TaskId, TodoTasks.Commons.TaskEnums.TaskStatus taskStatus);
    }
}
