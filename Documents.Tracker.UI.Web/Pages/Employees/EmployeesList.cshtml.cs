using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Documents.Tracker.Core.CompositeServices.Interface.Employees;
using Documents.Tracker.Core.DTO.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Documents.Tracker.UI.Web.Pages.Employees
{
    public class EmployeesListModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        public ICollection<EmployeeOTO> Emplyees { get; set; }

        public EmployeesListModel(IEmployeeService employeeService) {
            _employeeService = employeeService;
        }
        public async Task<IActionResult> OnGet()
        {
            Emplyees = await _employeeService.GetEmployeesList();
            return Page();
        }

        public async Task<IActionResult> OnGetAddEditEmployee(int Id)
        {
            try
            {
                EmployeeOTO employee = new EmployeeOTO();
                if (Id > 0)
                {
                    employee = await _employeeService.GetEmployee(Id);
                }
                return Partial("_AddEditEmployee", employee);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> OnPostSaveEmployee(EmployeeOTO employee)
        {
            if (!ModelState.IsValid)
                return RedirectToPage();

            var results = await _employeeService.AddEditEmployee(employee);
            return RedirectToPage();
        }
    }
}