using Documents.Tracker.Core.DTO.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices
{
    public interface IQueryOrderService
    {
        Task<ICollection<OrderOTO>> GetAllOrders();
        Task<ICollection<OrderOTO>> GetOrders(string Consumerid);
        Task<OrderOTO> GetSingleOrder(string OrderKey);
        Task<OrderOTO> GetSingleOrder(int OrderId);
        Task<OrderOTO> GetOrderbyOrderDetailId(int OrderDetailId);
        Task<ICollection<OrderProductOTO>> GetOrdersByStatus(int orderstatusId);
        Task<ICollection<OrderProductOTO>> GetOrderProducts(int OrderId);
        Task<ICollection<OrderProductOTO>> GetOrderProducts(string OrderKey);
        
        Task<OrderPaymentOTO> GetSingleOrderPayment(string OrderKey);
    }
}
