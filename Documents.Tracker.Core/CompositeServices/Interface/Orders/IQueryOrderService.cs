using Documents.Tracker.Core.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices
{
    public interface IQueryOrderService
    {
        Task<ICollection<OrderOTO>> GetAllOrders();
        Task<OrderOTO> GetOrderDetailsByOrderId(string id);
    }
}
