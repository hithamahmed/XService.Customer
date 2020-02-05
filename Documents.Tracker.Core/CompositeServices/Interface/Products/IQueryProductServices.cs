using Documents.Tracker.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IQueryProductServices
    {
        Task<ProductOTO> GetServiceDetailsByServiceId(int serviceid);
        Task<ICollection<ProductOTO>> GetListOfProductsWithCategory();
    }
}
