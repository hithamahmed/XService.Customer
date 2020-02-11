using Documents.Tracker.Core.DTO.Orders;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices
{
    public interface ICommandOrderService
    {
        Task<OrderOTO> SetOrderStatus(string orderkey, int StatusEnumId);
    }
}
