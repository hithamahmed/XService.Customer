using System;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO
{
    public class ServiceTaskOTO : CoreBaseOTO
    {

        public int LocationAreaId { get; set; }

        public DateTime Duedate { get; set; }

        public int TaskStatusId { get; set; }

        [MaxLength(250)]
        public string DecliendReason { get; set; }
    }
}