using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMapper;
using Documents.Tracker.Core;
using Documents.Tracker.Core.DTO;
using General.Services.Core;
using General.Staff.Core;
using General.Staff.Core.DTO;

namespace Documents.Tracker.UI.Web.Pages.Staffs
{
    public class EmployeesModel : PageModel
    {
        private IEmployees employeeRepos { get; set; }
        //public IMapper mapper { get; set; }
        public IEnumerable<EmployeeDTO> EmployeesList { get; set; }

        public EmployeesModel(IEmployees _employeeRepos)
        {
            employeeRepos = _employeeRepos;
 
            //mapper = _mapper;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if(ModelState.IsValid)
                    EmployeesList = await employeeRepos.GetAllEmployees();
                
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message.ToString());
                return Page();
                //throw new Exception(ex.Message.ToString());
            }
        
        }

        public async Task<IActionResult> OnGetAddEditEmployeeAsync(int RefId)
        {
            EmployeeDTO employee = new EmployeeDTO();
            if (RefId > 0)
            {
                employee = await employeeRepos.GetEmployeeById(RefId);
            }
            return Partial("_AddEditEmployee", employee);
        }
        public IActionResult OnPostSaveEmployee(EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
                return RedirectToPage();

            int i = employeeRepos.AddEditEmployee(employee).Result;
            return RedirectToPage();
        }
        public IActionResult OnPostDisableEmployee(int RefId)
        {

            int i = employeeRepos.EnableDisableEmployee(RefId).Result;
            return RedirectToPage();
        }

    }
}