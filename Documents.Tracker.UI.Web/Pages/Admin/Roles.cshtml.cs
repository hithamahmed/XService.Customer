using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.XIdentity.Core.DTO.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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