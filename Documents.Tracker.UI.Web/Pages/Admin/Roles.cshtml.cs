using Application.XIdentity.Core.DTO.Admin;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Documents.Tracker.UI.Web.Pages.Admin
{
    public class RolesModel : PageModel
    {
        public IEnumerable<SysRoleDTO> SysRoles { get; set; }

        public void OnGet()
        {

        }
    }
}