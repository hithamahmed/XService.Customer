using Delegators.Core.Interface;
using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO.Employees;
using General.Employees.Commons;
using General.Employees.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices.Services.Employees
{
    internal class EmployeeService : MapperCore,IEmployeeService
    {
        private readonly IEmployeeCore _employeeCore;
        //public readonly IEmployeeDelegatorService _employeeDelegatorService;
        private readonly IUserDelegatorCore _userDelegatorCore;
        public EmployeeService(IEmployeeCore employeeCore
            , IUserDelegatorCore userDelegatorCore)
        {
            _employeeCore = employeeCore;
            _userDelegatorCore = userDelegatorCore;
        }
        public async Task<int> AddEditEmployee(EmployeeOTO Employee)
        {
            try
            {
                var employee = Mapper.Map<EmployeeDTO>(Employee); 
                return await _employeeCore.AddEditEmployee(employee);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EmployeeOTO> GetEmployee(int EmployeeId)
        {
            try
            {
                var employee = await _employeeCore.GetSingleEmployee(EmployeeId);
                return Mapper.Map<EmployeeOTO>(employee);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<EmployeeOTO>> GetEmployeesList()
        {
            try
            {
                var employeelist = await _employeeCore.GetEmployees();
                
                var employees = Mapper.Map<ICollection<EmployeeOTO>>(employeelist);
                foreach (var emp in employees)
                {
                   var delgator = await _userDelegatorCore.GetUserDelegatorByEmployeeId(emp.Id);
                    emp.IsDelegator = delgator != null && delgator?.ReferenceId == emp.Id && !delgator.IsBlocked;
                }
                return employees;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> IsDelegatorEmployee(int employeeId)
        {
            try
            {
                var delegator = await _userDelegatorCore.GetUserDelegatorByEmployeeId(employeeId);
                return delegator.ReferenceId > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
