using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Documents.Tracker.Core.CompositeServices;
using Documents.Tracker.Core.DTO.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Documents.Tracker.UI.Web.Pages.Delegators
{
    public class DelegatorsListModel : PageModel
    {
        private readonly IEmployeeDelegatorService _employeeDelegatorService;
        private readonly IEmployeeService _employeeService;
        public ICollection<EmployeeDelegatorOTO> UserDelegators { get; set; }
        public ICollection<EmployeeOTO> Employees { get; set; }
        public DelegatorsListModel(IEmployeeService employeeService,
            IEmployeeDelegatorService employeeDelegatorService) 
        {
            _employeeDelegatorService = employeeDelegatorService;
            _employeeService = employeeService;
        }
        public async Task<IActionResult> OnGet()
        {
            UserDelegators = await _employeeDelegatorService.GetEmployeeDelegatorsList();
            return Page();
        }

        public async Task<IActionResult> OnGetAddEditDelegator(int id)
        {
            try
            {
                EmployeeDelegatorOTO delegator = new EmployeeDelegatorOTO();
                if (id > 0)
                {
                    delegator = await _employeeDelegatorService.GetEmployeeDelegator(id);
                }
                Employees = await _employeeService.GetEmployeesList();
                return Partial("_AddEditDelegator", delegator);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> OnPostSaveDelegator(EmployeeDelegatorOTO employee)
        {
            if (!ModelState.IsValid)
                return RedirectToPage();

            var results = await _employeeDelegatorService.AddEmployeeDelegator(employee);
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostChangeBlock(int delegatorId)
        {
            if (!ModelState.IsValid)
                return RedirectToPage();

            var results = await _employeeDelegatorService.EnableDisableEmployeeDelegator(delegatorId);

            return RedirectToPage();
        }
    }
}