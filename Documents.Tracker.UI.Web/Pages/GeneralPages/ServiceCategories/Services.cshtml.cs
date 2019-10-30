using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Documents.Tracker.UI.Web.DTO;
using General.Services.Core;
using General.Services.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Documents.Tracker.UI.Web.Pages.GeneralPages.ServiceCategories
{
    public class ServicesModel : PageModel
    {
        private IServicesCategory servicesCategory { get; set; }
        
        public IMapper mapper { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }

        public ServicesModel(IServicesCategory _servicesCategory, IMapper _mapper)
        {
            servicesCategory = _servicesCategory;
            mapper = _mapper;
        }

        #region Cateories

        public async Task<IActionResult> OnGet()
        {
            Categories = await servicesCategory.GetCategories();
            foreach (var category in Categories)
            {
                category.ServiceCategories = await servicesCategory.GetListServicesByCategory(category.RefId).ConfigureAwait(false);

            }
            return Page();
        }
        public async Task<IActionResult> OnGetAddEditCategoryAsync(int RefId)
        {
            CategoryDTO category = new CategoryDTO();
            if (RefId > 0)
            {
                category = await servicesCategory.GetCategoryById(RefId);
            }
            return Partial("_AddEditCategory", category);
        }
        public IActionResult OnPostSaveCategory(CategoryDTO category)
        {
            if (!ModelState.IsValid)
                return RedirectToPage();

            int i = servicesCategory.AddEditCategory(category).Result;
            return RedirectToPage();
        }
        public IActionResult OnPostDisableCategory(int RefId)
        {

            int i = servicesCategory.EnableDisableCategory(RefId).Result;
            return RedirectToPage();
        }
        public JsonResult OnGetCategory(string categoryname)
        {
            var allCategories =   servicesCategory.GetCategories().Result;
            var categories = allCategories.Where(x => categoryname.Contains(x.Name))
                .Select(x=> 
                new { label = x.Name, value = x.RefId }).ToList();
            return new JsonResult(categories);
        }
        #endregion

        #region Services
        public async Task<IActionResult> OnGetAddEditServiceAsync(int categoryid, int RefId)
        {
            try
            {
                ServiceCategoryDTO serviceCategory = new ServiceCategoryDTO
                {
                    ServiceCategoryId = categoryid
                };

                if (RefId > 0)
                {
                    serviceCategory = await servicesCategory.GetServiceCategoryById(RefId);
                }
                return Partial("_AddEditService", serviceCategory);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }
        public IActionResult OnPostSaveService(ServiceCategoryDTO service)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();

                int i = servicesCategory.AddEditService(service).Result;
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message );
                return RedirectToPage();
            }
        }
        public IActionResult OnPostDisableService(int RefId)
        {
            try
            {
                int i = servicesCategory.EnableDisableService(RefId).Result;
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }
        public IActionResult OnPostChangeServiceCategory(int RefId, int NewServiceCategoryId)
        {
            try
            {
                int i = servicesCategory.ChangeServiceCategory(RefId, NewServiceCategoryId).Result;
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
                ChangeCategoryDTO serviceCategory = new ChangeCategoryDTO
                {
                    ServiceCategoryId = categoryid
                };

                var allCategories = servicesCategory.GetCategories().Result;
                var categories = allCategories
                    .Select(x =>
                    new { label = x.Name, value = x.RefId }).ToList();
                
                if (RefId > 0)
                {
                    var CurrentserviceCategory = await servicesCategory.GetServiceCategoryById(RefId);
                    serviceCategory = new ChangeCategoryDTO
                    {
                        RefId = CurrentserviceCategory.RefId,
                        Name = CurrentserviceCategory.Name,
                        ServiceCategoryId = categoryid,
                        NewServiceCategoryId = categoryid,
                    };
                    serviceCategory.CategoriesSelectList = 
                        new SelectList(categories, "value", "label", serviceCategory.ServiceCategoryId.ToString());
                }
                else
                    serviceCategory.CategoriesSelectList = 
                        new SelectList(categories, "value", "label");

                return Partial("_ChangeServiceCategory", serviceCategory);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }

        #endregion

        #region Required Documents

        #endregion
    }
}