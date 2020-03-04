using Documents.Tracker.Core.DTO.Employees;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices
{
    public interface IEmployeeService
    {
        Task<ICollection<EmployeeOTO>> GetEmployeesList();
        Task<EmployeeOTO> GetEmployee(int EmployeeId);
        Task<int> AddEditEmployee(EmployeeOTO Employee);
        public Task<bool> IsDelegatorEmployee(int employeeId);
    }
}
