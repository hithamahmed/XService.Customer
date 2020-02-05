using Documents.Tracker.Core.DTO.Orders;
using Orders.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices
{
    public interface ICommandOrderService
    {
        Task<OrderOTO> SetOrderStatus(string orderkey, int StatusEnumId);
    }
}
