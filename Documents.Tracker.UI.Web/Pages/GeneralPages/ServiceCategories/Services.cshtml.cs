using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Documents.Tracker.Core;
using Documents.Tracker.Core.DTO;
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
        //private IServicesCategory servicesCategory { get; set; }
        private readonly IQueryGeneralService generalService;
        private readonly ICommandGeneralService commandGeneralService;
        //public IMapper mapper { get; set; }
        public ICollection<CategoriesOTO> Categories { get; set; }

        public ServicesModel(
            IQueryGeneralService _generalService, 
            ICommandGeneralService _commandGeneralService)
        {
            generalService = _generalService;
            commandGeneralService = _commandGeneralService;
            //mapper = _mapper;
        }

        #region Cateories

        public async Task<IActionResult> OnGet()
        {
            ICollection<CategoriesOTO> categoriesList = new List<CategoriesOTO>();
            Categories = await generalService.GetAllCategoriesWithSubs();
            //IQueryable<CategoriesOTO> _QueryCats = Categories.AsQueryable();
            //foreach (var parentcat in categoriesList)
            //{
            //    parentcat.SubCategories = GetSubs(parentcat.RefId, _QueryCats);
            //    Categories.Add(parentcat);
            //}
            //foreach (var category in Categories)
            //{
            //    if (!category.ParentCategoryId.HasValue)
            //        category.Products = await generalService.GetListProductsByCategory(category.RefId).ConfigureAwait(false);
            //    else
            //    {
            //        foreach (var subcategory in category.SubCategories)
            //        {
            //            category.Products = await generalService.GetListProductsByCategory(category.ParentCategoryId.Value).ConfigureAwait(false);
            //        }
            //    }
            //}
            return Page();
        }
        private ICollection<CategoriesOTO> GetSubs(int parentCode, IQueryable<CategoriesOTO> _newList)
        {

            IQueryable<CategoriesOTO> childItems = generalService.GetAllSubCategories(parentCode).Result.AsQueryable();
            if (childItems.ToList().Count > 0)
            {
                childItems.ToList().ForEach(x => x.SubCategories = GetSubs(x.RefId, _newList));
            }
            return childItems.ToList();
        }

        public async Task<IActionResult> OnGetAddEditCategoryAsync(int RefId)
        {
            CategoriesOTO category = new CategoriesOTO();
            if (RefId > 0)
            {
                category = await generalService.GetCategoryById(RefId);
            }
            category.SubCategories = generalService.GetAllCategories()
                .Result.Where(x=> x.RefId != RefId ).ToList();
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
            var allCategories =   generalService.GetAllCategories().Result;
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
                ProductOTO product = new ProductOTO
                {
                    CategoryId = categoryid
                };

                if (RefId > 0)
                {
                    product = await generalService.GetProductById(RefId);
                }
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
                ModelState.AddModelError("ex", ex.Message );
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
        public IActionResult OnPostChangeServiceCategory(int RefId, int NewProductCategoryId)
        {
            try
            {
                int i = commandGeneralService.ChangeProductCategory(RefId, NewProductCategoryId).Result;
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
                    .Select(x =>
                    new { label = x.Name, value = x.RefId }).ToList();
                
                if (RefId > 0)
                {
                    var product = await generalService.GetProductById(RefId);
                    category = new ChangeCategoryDTO
                    {
                        RefId = product.RefId,
                        Name = product.Name,
                        ServiceCategoryId = categoryid,
                        NewServiceCategoryId = categoryid,
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