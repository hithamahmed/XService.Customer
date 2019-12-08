using Documents.Tracker.Core.DTO;
using General.Services.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IQueryGeneralService 
    {
        Task<ICollection<CountriesOTO>> GetCountriesList();
        Task<ICollection<GovernmentOTO>> GetGovernmentsByCountry(int countryId);
        Task<ICollection<LocationAreasOTO>> GetLocationByGovernment(int governmentId);


        Task<ICollection<CategoriesOTO>> GetAllCategories();
        Task<ICollection<CategoriesOTO>> GetAllSubCategories(int parentId);
        Task<ICollection<CategoriesOTO>> GetAllCategoriesWithSubs();
        Task<ICollection<ProductOTO>> GetListProductsByCategory(int CategoryId);
        Task<CategoriesOTO> GetCategoryById(int categoryId);

        Task<ProductOTO> GetProductById(int productUKey);
        Task<ICollection<ProductOTO>> GetListOfProductsWithCategory();

    }
}
