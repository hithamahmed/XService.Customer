using Delegators.Commons.DTO;
using Delegators.Core.Interface;
using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO.Employees;
using General.Employees.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices
{
    internal class EmployeeDelegatorService : MapperCore, IEmployeeDelegatorService
    {
        private readonly IUserDelegatorCore _userDelegatorCore;
        //private readonly IEmployeeService _employeeService;
        private readonly IEmployeeCore _employeeCore;
        public EmployeeDelegatorService(IEmployeeCore employeeCore,
            IUserDelegatorCore userDelegatorCore)
        {
            _employeeCore = employeeCore;
            _userDelegatorCore = userDelegatorCore;
        }

        public async Task<int> AddEmployeeDelegator(EmployeeDelegatorOTO userDelegator)
        {
            try
            {
                var user = Mapper.Map<UserDelegatorDTO>(userDelegator);
                return await _userDelegatorCore.AddUserDelegator(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EmployeeDelegatorOTO> EnableDisableEmployeeDelegator(int UserDelegatorId)
        {
            try
            {
                try
                {
                    var user = await _userDelegatorCore.EnableDisableDelegator(UserDelegatorId);
                    return Mapper.Map<EmployeeDelegatorOTO>(user);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EmployeeDelegatorOTO> GetEmployeeDelegator(int UserDelegatorId)
        {
            try
            {
                var user = await _userDelegatorCore.GetUserDelegator(UserDelegatorId);
                var delegator = Mapper.Map<EmployeeDelegatorOTO>(user);
                var employee = await _employeeCore.GetSingleEmployee(delegator.EmployeeId);
                if (employee != null)
                    delegator.Employee = Mapper.Map<EmployeeOTO>(employee); ;

                return delegator;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EmployeeDelegatorOTO> GetEmployeeDelegatorByEmployee(int EmployeeId)
        {
            try
            {
                var delegator = await _userDelegatorCore.GetUserDelegatorByEmployeeId(EmployeeId);
                var employee = await _employeeCore.GetSingleEmployee(EmployeeId);
                var delegatorEmployee = Mapper.Map<EmployeeDelegatorOTO>(delegator);
                delegatorEmployee.Employee = Mapper.Map<EmployeeOTO>(employee);
                //    new EmployeeDelegatorOTO
                //{
                //    Employee = Mapper.Map<EmployeeOTO>(employee),
                //    StartDate = delegator.StartDate,
                //    EndDate = delegator.EndDate,
                //    EmployeeId = delegator.Id,
                //    BlockedDate = delegator.BlockedDate,
                //    IsBlocked = delegator.IsBlocked
                //};

                return delegatorEmployee;// Mapper.Map<EmployeeDelegatorOTO>(delegator);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<EmployeeDelegatorOTO>> GetEmployeeDelegatorsList()
        {
            try
            {
                var users = await _userDelegatorCore.GetUsersDelegators();
                var delegators = Mapper.Map<ICollection<EmployeeDelegatorOTO>>(users);

                var employeesList = await _employeeCore.GetEmployees();
                var employees  = Mapper.Map<ICollection<EmployeeOTO>>(employeesList);

                var employeeDelegator =
                    (from delg in delegators.ToList()
                     from emp in employees.ToList()
                     where delg.EmployeeId == emp.Id
                     select new EmployeeDelegatorOTO
                     {
                         Id = delg.Id,
                         Employee = emp,
                         StartDate = delg.StartDate,
                         EndDate = delg.EndDate,
                         EmployeeId = emp.Id,
                         BlockedDate = delg.BlockedDate,
                         IsBlocked = delg.IsBlocked
                     });

                //foreach (var item in delegators)
                //{
                //    var employee = await _employeeCore.GetSingleEmployee(item.EmployeeId);
                //    //item.Name = employee == null ? "" :  employee.FirstName;
                //    if (employee != null)
                //        item.Employee = Mapper.Map<EmployeeOTO>(employee);
                //}
                return employeeDelegator.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
