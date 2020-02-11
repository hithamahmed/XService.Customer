using Documents.Tracker.Core.DTO.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices
{
    public interface IQueryOrderService
    {
        Task<ICollection<OrderOTO>> GetAllOrders();
        Task<OrderOTO> GetOrderDetailsByOrderId(string id);
    }
}
