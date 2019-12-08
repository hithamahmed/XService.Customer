using Documents.Tracker.Core.DTO;
using General.Services.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface ICommandGeneralService
    {
        Task<int> AddEditProduct(ProductOTO serviceCategory);
        Task<int> EnableDisableProduct(int productUKey);
        Task<int> ChangeProductCategory(int productUKey, int NewCategoryid);
        Task<int> AddEditCategory(CategoriesOTO category);
        Task<int> EnableDisableCategory(int categoryId);
    }
}
