using Documents.Tracker.Core.DTO.TodoTasks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoTasks.Commons.DTO;

namespace Documents.Tracker.Core.CompositeServices
{
    public interface  IQueryTodoTasksServices
    {
        Task<ICollection<TaskOTO>> GetTodoTasksList();
        Task<ICollection<TaskOTO>> GetTodoTasksList(int delegatorId);
        Task<TaskOTO> GetSingleTodoTask(int taskId);
        Task<ICollection<TaskTypeDTO>> GetTodoTaskTypes();
        Task<ICollection<TaskStatusDTO>> GetTodoTastStatus();
        Task<ICollection<TaskLocationOTO>> GetTodoTaskLocationsListByTaskId(int taskId);
        Task<TaskLocationOTO> GetSingleTodoTaskLocation(int taskLocationId);
        Task<ICollection<TaskLocationOTO>> GetTodoTaskLocations(int productId, int orderItemId);

    }
}
