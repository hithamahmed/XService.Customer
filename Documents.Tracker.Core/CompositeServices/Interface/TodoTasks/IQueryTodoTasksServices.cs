using Documents.Tracker.Core.DTO.TodoTasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoTasks.Commons.DTO;

namespace Documents.Tracker.Core.CompositeServices
{
    public interface  IQueryTodoTasksServices
    {
        Task<ICollection<TaskOTO>> GetTodoTasksList();
        Task<TasksDTO> GetSingleTodoTask(int taskId);
        Task<ICollection<TaskTypeDTO>> GetTodoTaskTypes();
        Task<ICollection<TaskStatusDTO>> GetTodoTastStatus();
        Task<ICollection<TaskLocationOTO>> GetTodoTaskLocationsListByTaskId(int taskId);
        Task<TaskLocationOTO> GetSingleTodoTaskLocation(int taskLocationId);

    }
}
