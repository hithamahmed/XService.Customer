using AutoMapper;
using Documents.Tracker.Core.DTO.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TodoTasks.Commons.DTO;

namespace Documents.Tracker.Core.DTO.TodoTasks
{
    public class TaskLocationOTO
    {
        public int Id { get; set; }
        [Required] public int TaskID { get; set; }
        [Required] public int LocationId { get; set; }
        [Required] public int ProductId { get; set; }
        [Required] public int ReferenceId { get; set; }

        public DateTime TaskStatusDate { get; set; }
        [StringLength(250)] 
        public string Notes { get; set; }

        public bool IsClosed { get; set; }
        public int TaskStatusId { get; set; }
        public TaskOTO Tasks { get; set; }
        public TaskStatusDTO TaskStatus { get; set; }
        [IgnoreMap] public ProductOTO Product { get; set; }
        [IgnoreMap] public LocationAreasOTO LocationAreas { get; set; }
        [IgnoreMap] public OrderOTO Order { get; set; }
        [IgnoreMap] public ICollection<OrderProductOTO> OrderItems { get; set; }

    }
}
