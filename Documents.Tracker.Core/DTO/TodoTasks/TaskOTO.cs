using Delegators.Commons.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TodoTasks.Commons;
using TodoTasks.Commons.DTO;
using AutoMapper;
using Documents.Tracker.Core.DTO.Employees;

namespace Documents.Tracker.Core.DTO.TodoTasks
{
    public class TaskOTO
    {
        public TaskOTO()
        {
            TaskStatus = new TaskStatusDTO();
            TaskType = new TaskTypeDTO();
        }
        public int Id { get; set; }
        
        [StringLength(50)]
        public string Title { get; set; }


        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        
        [StringLength(250)]
        public string Notes { get; set; }

        [MaxLength(250)]
        public string RejectReason { get; set; }

        public DateTime StartedAt { get; set; }
        public DateTime? ClosedAt { get; set; }

        public string AssignedUserID { get; set; }
        public int StatusId { get; set; }
        public int TaskTypeId { get; set; }
        public TaskStatusDTO TaskStatus { get; set; }
        public TaskTypeDTO TaskType { get; set; }
        //[IgnoreMap] public UserDelegatorDTO UserDelegator { get; set; }
        [IgnoreMap] public EmployeeDelegatorOTO UserDelegator { get; set; }
        public bool IsClosed { get; set; }
        public bool IsRejected { get; set; }
        //public bool GetIsClosed()
        //{
        //    return TaskStatus.Id > (int)TaskEnums.TaskStatus.Shipped ;
        //}
        //public bool GetIsRejected()
        //{
        //    return TaskStatus.Id == (int)TaskEnums.TaskStatus.Rejected;
        //}
    }
}
