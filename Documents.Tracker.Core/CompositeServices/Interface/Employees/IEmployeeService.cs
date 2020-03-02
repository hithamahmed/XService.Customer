using Documents.Tracker.Core.DTO.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices.Interface.Employees
{
    public interface IEmployeeService
    {
        Task<ICollection<EmployeeOTO>> GetEmployeesList();
        Task<EmployeeOTO> GetEmployee(int EmployeeId);
        Task<int> AddEditEmployee(EmployeeOTO Employee);
    }
}
