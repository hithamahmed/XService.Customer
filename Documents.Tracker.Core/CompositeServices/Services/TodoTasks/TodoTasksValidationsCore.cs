using Documents.Tracker.Core.DTO.TodoTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices
{
    internal class TodoTasksValidationsCore : IValidationsTodoTasksServices
    {
        private readonly IQueryTodoTasksServices _queryTodoTasks;
        public TodoTasksValidationsCore(
            IQueryTodoTasksServices queryTodoTasks)
        {
            _queryTodoTasks = queryTodoTasks;
        }
        public async Task<bool> IsTaskServiceExists(TaskLocationOTO taskLocation)
        {
            try
            {
                if (taskLocation != null)
                    throw new Exception($"Invalid ");

                var taskServices = await _queryTodoTasks.GetTodoTaskLocationsListByTaskId(taskLocation.TaskID);
                var rows = (from t in taskServices.ToList()
                            where t.ProductId == taskLocation.ProductId && t.ReferenceId == taskLocation.ReferenceId
                            select t.Id).Count();
                return rows > 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
