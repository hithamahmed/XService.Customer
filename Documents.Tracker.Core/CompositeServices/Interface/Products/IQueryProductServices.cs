using Documents.Tracker.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IQueryProductServices
    {
        Task<ProductOTO> GetProduct(int productId);
        Task<ICollection<ProductOTO>> GetListOfProductsWithCategory();
    }
}
