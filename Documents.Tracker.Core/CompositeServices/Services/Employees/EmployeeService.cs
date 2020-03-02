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
        public EmployeeService(IEmployeeCore employeeCore)
        {
            _employeeCore = employeeCore;
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
                return Mapper.Map<ICollection<EmployeeOTO>>(employeelist);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
