using Documents.Tracker.Core.DTO.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices
{
    public interface IQueryOrderService
    {
        Task<ICollection<OrderOTO>> GetAllOrders();
        Task<OrderOTO> GetSingleOrder(string OrderKey);
        Task<OrderOTO> GetSingleOrder(int OrderId);
        Task<OrderOTO> GetOrderbyOrderDetailId(int OrderDetailId);
        Task<ICollection<OrderItemOTO>> GetOrdersByStatus(int orderstatusId);
        Task<ICollection<OrderItemOTO>> GetOrderItems(int OrderId);

    }
}
