using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Documents.Tracker.Core;
using Documents.Tracker.Core.DTO;
using Documents.Tracker.UI.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Documents.Tracker.UI.Web.Pages.ServiceDocuments
{
    //[AutoValidateAntiforgeryToken]
    public class ServicesModel : PageModel
    {
        private readonly IQueryGeneralService generalService;
        private readonly ICommandGeneralService commandGeneralService;
        public ICollection<ProductOTO> productServices { get; set; }

        public ServicesModel(
            IQueryGeneralService _generalService,
            ICommandGeneralService _commandGeneralService)
        {
            generalService = _generalService;
            commandGeneralService = _commandGeneralService;
        }

        #region Services

        public async Task<IActionResult> OnGet()
        {
            productServices = await generalService.GetListOfProductsWithCategory();
            return Page();
        }

        public async Task<IActionResult> OnGetAddEditServiceAsync(int RefId)
        {
            try
            {
                ProductOTO product = new ProductOTO();

                if (RefId > 0)
                {
                    product = await generalService.GetProductById(RefId);
                }

                var Categories = await generalService.GetAllCategories();
                product.Categories = Categories.Where(x=>x.ParentCategoryId != null).ToList();

                return Partial("_AddEditService", product);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }
        
        public IActionResult OnPostSaveService(ProductOTO service)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();

                int i = commandGeneralService.AddEditProduct(service).Result;
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }
        public IActionResult OnPostDisableService(int RefId)
        {
            try
            {
                int i = commandGeneralService.EnableDisableProduct(RefId).Result;
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }
        public IActionResult OnPostChangeServiceCategory(ChangeCategoryDTO changeCategory)
        {
            try
            {
                int i = commandGeneralService.ChangeProductCategory(changeCategory.RefId, changeCategory.NewServiceCategoryId).Result;
                return RedirectToPage();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }
        public async Task<IActionResult> OnGetChangeCategoryAsync(int categoryid, int RefId)
        {
            try
            {
                ChangeCategoryDTO category = new ChangeCategoryDTO
                {
                    ServiceCategoryId = categoryid
                };

                var allCategories = generalService.GetAllCategories().Result;
                var categories = allCategories
                    .Where(x => x.ParentCategoryId != null)
                    .Select(x => new { label = x.Name, value = x.RefId } ).ToList();

                if (RefId > 0)
                {
                    var product = await generalService.GetProductById(RefId);
                    category = new ChangeCategoryDTO
                    {
                        RefId = product.RefId,
                        Name = product.Name,
                        ServiceCategoryId = categoryid,
                        NewServiceCategoryId = categoryid
                    };
                    category.CategoriesSelectList =
                        new SelectList(categories, "value", "label", category.ServiceCategoryId.ToString());
                }
                else
                    category.CategoriesSelectList =
                        new SelectList(categories, "value", "label");

                return Partial("_ChangeServiceCategory", category);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }

        #endregion
    }
}