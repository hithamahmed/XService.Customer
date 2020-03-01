﻿using Documents.Tracker.Core.DTO.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices
{
    public interface IEmployeeDelegatorService
    {
        Task<ICollection<EmployeeDelegatorOTO>> GetEmployeeDelegatorsList();
        Task<EmployeeDelegatorOTO> GetEmployeeDelegator(int UserDelegatorId);
        Task<int> AddEmployeeDelegator(EmployeeDelegatorOTO userDelegator);
    }
}
