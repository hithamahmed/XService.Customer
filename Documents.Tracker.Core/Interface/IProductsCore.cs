using Documents.Tracker.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IProductsCore
    {
        Task<ProductOTO> GetProductDetailsByProductId(int id);
        Task<ICollection<ProductOTO>> GetProductsWithCategories();

    }
}
