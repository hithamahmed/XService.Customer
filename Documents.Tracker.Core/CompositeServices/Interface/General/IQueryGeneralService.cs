using Documents.Tracker.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IQueryGeneralService
    {
        Task<ICollection<CountriesOTO>> GetCountriesList();
        Task<ICollection<GovernmentOTO>> GetGovernmentsByCountry(int countryId);
        Task<ICollection<LocationAreasOTO>> GetLocationList(int governmentId);
        Task<ICollection<LocationAreasOTO>> GetLocationList();
        Task<LocationAreasOTO> GetSingleLocation(int locationId);
        


        Task<ICollection<CategoriesOTO>> GetAllCategories();
        Task<ICollection<CategoriesOTO>> GetAllSubCategories(int parentId);
        Task<ICollection<CategoriesOTO>> GetAllCategoriesWithSubs();
        Task<ICollection<ProductOTO>> GetListProductsByCategory(int CategoryId);


        Task<CategoriesOTO> GetCategoryById(int categoryId);

        Task<ProductOTO> GetProductById(int productUKey);

    }
}
