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
        public string Name { get; set; }
        //public bool Blocked { get; set; }
        //public ICollection<TaskOTO> Tasks { get; set; }

    }
}
