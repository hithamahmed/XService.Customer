using ApplicationCore.Entities;
using General.Services.Core.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Documents.Tracking.Data.Entities
{
    public class ServiceTasks : EntityBase
    {
        [ForeignKey("LocationAreaId")]
        public LocationArea LocationArea { get; set; }
        public int LocationAreaId {get;set;}

        public DateTime Duedate { get; set; }

        [ForeignKey("TaskStatusId")]
        public TaskStatus TaskStatus { get; set; }
        public int TaskStatusId { get; set; }

        [MaxLength(250)]
        public string DecliendReason { get; set; }

    }
}
