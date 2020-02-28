using Delegators.Core.Interface;
using Documents.Tracker.Core.CompositeServices;
using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO.TodoTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoTasks.Commons;
using TodoTasks.Commons.DTO;
using TodoTasks.Core.Interface;

namespace Documents.Tracker.Core.CompositeServices.Services.TodoTasks
{
    internal class TodoTasksCore : MapperCore, IQueryTodoTasksServices,ICommandTodoTasksServices
    {
        private readonly ITasksCore _tasksCore;
        private readonly ITaskLocationsCore _taskLocationsCore;
        private readonly IUserDelegatorCore _userDelegatorCore;
        private readonly IProductsCore _productsCore;
        private readonly IQueryGeneralService _generalService;
        //private readonly IValidationsTodoTasksServices _validationsTodoTasks;
        private readonly IQueryOrderService _queryOrderService;
     
        public TodoTasksCore(
            IQueryOrderService queryOrderService,
            //IValidationsTodoTasksServices validationsTodoTasks,
            IQueryGeneralService generalService,
            IProductsCore productsCore,
            ITaskLocationsCore taskLocationsCore,
            ITasksCore tasksCore,
            IUserDelegatorCore userDelegatorCore)
        {
            _generalService = generalService;
            _taskLocationsCore = taskLocationsCore;
            _tasksCore = tasksCore;
            _userDelegatorCore = userDelegatorCore;
            _productsCore = productsCore;
            //_validationsTodoTasks = validationsTodoTasks;
            _queryOrderService = queryOrderService;
        }
        private async Task<bool> IsTaskServiceExists(TaskLocationOTO taskLocation)
        {
            try
            {
                if (taskLocation == null)
                    return true;

                var taskServices = await GetTodoTaskLocationsListByTaskId(taskLocation.TaskID);
                var rows = (from t in taskServices.ToList()
                            where t.ProductId == taskLocation.ProductId
                            && t.ReferenceId == taskLocation.ReferenceId
                            select t.Id).Count();
                return rows > 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> AddEditTodoTask(TasksDTO tasksDTO)
        {
            try
            {
                return await _tasksCore.AddTask(tasksDTO);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AddEditTodoTaskLocation(TaskLocationOTO taskLocationOTO)
        {
            try
            {
                try
                {
                    var checkExists = await IsTaskServiceExists(taskLocationOTO);
                    if (checkExists)
                    {
                        return 0;
                    }

                    var taskLocation = Mapper.Map<TaskLocationServiceDTO>(taskLocationOTO);
                    
                    return await _taskLocationsCore.AddEditTaskLocation(taskLocation);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TasksDTO> GetSingleTodoTask(int taskId)
        {
            try
            {
                var includes = new List<Expression<Func<TasksDTO, object>>>();
                includes.Add(x => x.TaskStatus);
                includes.Add(x => x.TaskType);

                return await _tasksCore.GetSingleTask(x=>x.Id == taskId, includes);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TaskLocationOTO> GetSingleTodoTaskLocation(int taskLocationId)
        {
            try
            {
                var taskLocation = await _taskLocationsCore.GetSingleTaskLocation(taskLocationId);
                
                var taskLocationOTO =  Mapper.Map<TaskLocationOTO>(taskLocation);

                taskLocationOTO.Product = await _productsCore.GetProductDetailsByProductId(taskLocation.ProductId);

                taskLocationOTO.LocationAreas = await _generalService.GetSingleLocation(taskLocation.LocationId);
                
                return taskLocationOTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<TaskLocationOTO>> GetTodoTaskLocationsListByTaskId(int taskId)
        {
            try
            {
                var TaskLocations =  await _taskLocationsCore.GetTaskLocationsByTaskID(taskId);
                var taskLocationLists = Mapper.Map<ICollection<TaskLocationOTO>>(TaskLocations);
                foreach (var item in taskLocationLists)
                {
                    item.LocationAreas = await _generalService.GetSingleLocation(item.LocationId);
                    var order = await _queryOrderService.GetOrderbyOrderDetailId(item.ReferenceId);
                    item.Order = order;

                    var serviceproduct = await _productsCore.GetProductDetailsByProductId(item.ProductId);
                    item.Product = serviceproduct;
                    
                }
                return taskLocationLists;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<TaskOTO>> GetTodoTasksList()
        {
            try
            {
                var tasks = await _tasksCore.GetTasks();
                var tasksList = Mapper.Map<ICollection<TaskOTO>>(tasks);
                foreach (var item in tasksList)
                {
                    var userid = 0;
                    if (int.TryParse(item.AssignedUserID, out userid))
                        item.UserDelegator = await _userDelegatorCore.GetUsersDelegatorById(userid);
                    else
                        item.UserDelegator = await _userDelegatorCore.GetUsersDelegatorById(item.AssignedUserID);
                }
                return tasksList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<TaskTypeDTO>> GetTodoTaskTypes()
        {
            try
            {
                return await _tasksCore.GetTaskTypes();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ICollection<TaskStatusDTO>> GetTodoTastStatus()
        {
            try
            {
                return await _tasksCore.GetTaskStatuses();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TaskLocationOTO> SetTaskServiceStatus(int TaskServiceId, TaskEnums.TaskStatus taskStatus)
        {
            try
            {
                var taskService = await _taskLocationsCore.SetTaskServiceStatus(TaskServiceId, taskStatus);
                return Mapper.Map<TaskLocationOTO>(taskService);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
