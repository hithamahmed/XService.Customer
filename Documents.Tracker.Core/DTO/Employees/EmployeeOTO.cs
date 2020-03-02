using System;
using System.Collections.Generic;
using System.Text;

namespace Documents.Tracker.Core.DTO.Employees
{
    public class EmployeeOTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public bool IsBlocked { get; set; }
        public string MobileNumber { get; set; }

    }
}
