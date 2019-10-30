using ApplicationCore.Entities;
using General.Services.Core.Entity;
using System;
using System.ComponentModel.DataAnnotations;
namespace Documents.Tracking.Data.Entities
{
    public class ServiceTasks : EntityBase
    {
        public LocationArea LocationAreaId { get; set; }
        public DateTime Duedate { get; set; }
        public TaskStatus TaskStatusId { get; set; }
        [MaxLength(250)]
        public string DecliendReason { get; set; }

    }
}
