using Delegators.Commons.DTO;
using Delegators.Core.Interface;
using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices
{
    internal class EmployeeDelegatorService : MapperCore, IEmployeeDelegatorService
    {
        private readonly IUserDelegatorCore _userDelegatorCore;
        public EmployeeDelegatorService(IUserDelegatorCore userDelegatorCore)
        {
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

        public async Task<EmployeeDelegatorOTO> GetEmployeeDelegator(int UserDelegatorId)
        {
            try
            {
                var user = await _userDelegatorCore.GetUsersDelegator(UserDelegatorId);
                return Mapper.Map<EmployeeDelegatorOTO>(user);
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
                return Mapper.Map<ICollection<EmployeeDelegatorOTO>>(users);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
