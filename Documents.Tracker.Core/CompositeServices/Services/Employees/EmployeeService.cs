using Documents.Tracker.Core.CompositeServices.Interface.Employees;
using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO.Employees;
using General.Employees.Commons;
using General.Employees.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices.Services.Employees
{
    internal class EmployeeService : MapperCore,IEmployeeService
    {
        private readonly IEmployeeCore _employeeCore;
        public readonly IEmployeeDelegatorService _employeeDelegatorService;
        public EmployeeService(IEmployeeCore employeeCore
            , IEmployeeDelegatorService employeeDelegatorService)
        {
            _employeeCore = employeeCore;
            _employeeDelegatorService = employeeDelegatorService;
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
                   var delgator = await _employeeDelegatorService.GetEmployeeDelegatorByEmployee(emp.Id);
                    emp.IsDelegator = delgator != null && delgator?.EmployeeId == emp.Id;
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
                var delegator = await _employeeDelegatorService.GetEmployeeDelegatorByEmployee(employeeId);
                return delegator.Id > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
