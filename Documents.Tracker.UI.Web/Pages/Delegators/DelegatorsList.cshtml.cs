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
        public ICollection<EmployeeDelegatorOTO> UserDelegators;
        public DelegatorsListModel(IEmployeeDelegatorService employeeDelegatorService) 
        {
            _employeeDelegatorService = employeeDelegatorService;
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
                EmployeeDelegatorOTO employee = new EmployeeDelegatorOTO();
                if (id > 0)
                {
                    employee = await _employeeDelegatorService.GetEmployeeDelegator(id);
                }
                return Partial("_AddEditDelegator", employee);
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
    
    }
}