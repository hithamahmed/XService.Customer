using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO;
using General.Services.Core;
using General.Services.Core.DTO;
using General.Services.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    internal class GeneralServices : MapperCore, IQueryGeneralService, ICommandGeneralService
    {
        private readonly ICountries generalCore;
        private readonly IProducts servicesCategory;
        public GeneralServices(ICountries _generalCore,
            IProducts _servicesCategory)
        {
            generalCore = _generalCore;
            servicesCategory = _servicesCategory;
        }

        public async Task<int> AddEditCategory(CategoriesOTO category)
        {
            try
            {
                var x = Mapper.Map<CategoryDTO>(category);
                return await servicesCategory.AddEditCategory(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AddEditProduct(ProductOTO serviceCategory)
        {
            try
            {
                var x = Mapper.Map<ProductDTO>(serviceCategory);
                return await servicesCategory.AddEditProduct(x);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> ChangeProductCategory(int productUKey, int NewCategoryid)
        {
            try
            {
                return await servicesCategory.ChangeProductCategory(productUKey, NewCategoryid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> EnableDisableCategory(int categoryId)
        {
            try
            {
                return await servicesCategory.EnableDisableCategory(categoryId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> EnableDisableProduct(int productUKey)
        {
            try
            {
                return await servicesCategory.EnableDisableProduct(productUKey);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<CategoriesOTO>> GetAllCategoriesWithSubs()
        {
            try
            {
                var x = servicesCategory.GetCategories().Result.Where(c => c.ParentCategoryId == null);
                foreach (var sub in x.ToList())
                {
                    sub.SubCategories = await servicesCategory.GetSubCategories(sub.RefId);
                }
                return Mapper.Map<ICollection<CategoriesOTO>>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<CategoriesOTO>> GetAllCategories()
        {
            try
            {
                var x = await servicesCategory.GetCategories();
                return Mapper.Map<ICollection<CategoriesOTO>>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<CategoriesOTO>> GetAllSubCategories(int parentId)
        {
            try
            {
                var x = await servicesCategory.GetSubCategories(parentId);
                return Mapper.Map<ICollection<CategoriesOTO>>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CategoriesOTO> GetCategoryById(int categoryId)
        {
            try
            {
                var x = await servicesCategory.GetCategoryById(categoryId);
                return Mapper.Map<CategoriesOTO>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<CountriesOTO>> GetCountriesList()
        {
            try
            {
                var x = await generalCore.GetAllCountries();
                return Mapper.Map<ICollection<CountriesOTO>>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<GovernmentOTO>> GetGovernmentsByCountry(int countryId)
        {
            try
            {
                var x = await generalCore.GetGovernmentsList(countryId);
                return Mapper.Map<ICollection<GovernmentOTO>>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<ICollection<ProductOTO>> GetListProductsByCategory(int CategoryId)
        {
            try
            {
                var x = await servicesCategory.GetListProductsByCategory(CategoryId);
                return Mapper.Map<ICollection<ProductOTO>>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<LocationAreasOTO>> GetLocationList(int governmentId)
        {
            try
            {
                var x = await generalCore.GetLocationAreasList(governmentId);
                return Mapper.Map<ICollection<LocationAreasOTO>>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductOTO> GetProductById(int productUKey)
        {
            try
            {
                var x = await servicesCategory.GetProductById(productUKey);
                return Mapper.Map<ProductOTO>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<LocationAreasOTO>> GetLocationList()
        {
            try
            {
                var x = await generalCore.GetLocationAreasList();
                return Mapper.Map<ICollection<LocationAreasOTO>>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<LocationAreasOTO> GetSingleLocation(int locationId)
        {
            try
            {
                var x = await generalCore.GetLocationAreaById(locationId);
                return Mapper.Map<LocationAreasOTO>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public async Task<ProductDTO> GetProductCategoryById(int productUKey)
        //{
        //    try
        //    {
        //        return await servicesCategory.GetProductByUKey(productUKey);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
