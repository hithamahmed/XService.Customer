using AutoMapper;
using Documents.Tracker.Core.DTO.TodoTasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Documents.Tracker.Core.DTO.Employees
{
    public class EmployeeDelegatorOTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? BlockedDate { get; set; }

        public EmployeeOTO Employee { get; set; }

    }
}
