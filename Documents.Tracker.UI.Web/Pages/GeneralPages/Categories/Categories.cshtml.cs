using Documents.Tracker.Core;
using Documents.Tracker.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Tracker.UI.Web.Pages.GeneralPages.Categories
{
    public class CategoriesModel : PageModel
    {
        private readonly IQueryGeneralService generalService;
        private readonly ICommandGeneralService commandGeneralService;
        public ICollection<CategoriesOTO> Categories { get; set; }

        public CategoriesModel(
            IQueryGeneralService _generalService,
            ICommandGeneralService _commandGeneralService)
        {
            generalService = _generalService;
            commandGeneralService = _commandGeneralService;
        }

        #region Cateories

        public async Task<IActionResult> OnGet()
        {
            ICollection<CategoriesOTO> categoriesList = new List<CategoriesOTO>();
            Categories = await generalService.GetAllCategoriesWithSubs();
            return Page();
        }

        public async Task<IActionResult> OnGetAddEditCategoryAsync(int RefId)
        {
            CategoriesOTO category = new CategoriesOTO();
            if (RefId > 0)
            {
                category = await generalService.GetCategoryById(RefId);
            }
            category.SubCategories = generalService.GetAllCategories()
                .Result.Where(x => x.RefId != RefId).ToList();
            return Partial("_AddEditCategory", category);
        }
        public IActionResult OnPostSaveCategory(CategoriesOTO category)
        {
            if (!ModelState.IsValid)
                return RedirectToPage();

            if (category.ParentCategoryId == 0)
                category.ParentCategoryId = null;

            int i = commandGeneralService.AddEditCategory(category).Result;
            return RedirectToPage();
        }
        public IActionResult OnPostDisableCategory(int RefId)
        {
            int i = commandGeneralService.EnableDisableCategory(RefId).Result;
            return RedirectToPage();
        }
        public JsonResult OnGetCategory(string categoryname)
        {
            var allCategories = generalService.GetAllCategories().Result;
            var categories = allCategories.Where(x => categoryname.Contains(x.Name))
                .Select(x =>
                new { label = x.Name, value = x.RefId }).ToList();
            return new JsonResult(categories);
        }
        #endregion




    }
}