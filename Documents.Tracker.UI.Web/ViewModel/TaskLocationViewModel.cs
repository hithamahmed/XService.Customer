using Documents.Tracker.Core.DTO;
using Documents.Tracker.Core.DTO.Orders;
using Documents.Tracker.Core.DTO.TodoTasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TodoTasks.Commons.DTO;

namespace Documents.Tracker.UI.Web.ViewModel
{
    public class TaskLocationViewModel
    {
        public TaskLocationViewModel()
        {
            //TaskLocationService = new HashSet<TaskLocationOTO>();
            //LocationAreas = new HashSet<LocationAreasOTO>();
            //OrderProducts = new HashSet<OrderItemOTO>();
            //TaskStatuses = new HashSet<TaskStatusDTO>();
        }
        //[Required] public ICollection<TaskLocationOTO> TaskLocationService { get; set; }

        public int ProductId { get; set; }
        public int ReferenceId { get; set; }

        //public IEnumerable<LocationAreasOTO> LocationAreas { get; set; }
        //public IEnumerable<OrderItemOTO> OrderProducts { get; set; }
        //public IEnumerable<TaskStatusDTO> TaskStatuses { get; set; }
    }
}
