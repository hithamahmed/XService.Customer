using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Documents.Tracker.Core.CompositeServices;
namespace Documents.Tracker.UI.Web.SharedComponents
{

    [ViewComponent(Name = "SetOrderStatus")]
    public class OrderComponent : ViewComponent
    {
        public string OrderKey { get; set; }
        public OrderComponent()
        {
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            OrderKey = id;
            return View<string>(OrderKey);
        }
    }

    [ViewComponent(Name = "PendingOrderProductServices")]
    public class PendingOrderItemsComponent : ViewComponent
    {
        private readonly IQueryOrderService _queryOrderService;
        public PendingOrderItemsComponent(IQueryOrderService queryOrderService)
        {
            _queryOrderService = queryOrderService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int orderid)
        {
            var orderItems = await  _queryOrderService.GetOrderProducts(orderid);
            return View(orderItems);
        }
    }
    [ViewComponent(Name = "OrderProducts")]
    public class OrderProductsComponent : ViewComponent
    {
        private readonly IQueryOrderService _queryOrderService;
        public OrderProductsComponent(IQueryOrderService queryOrderService)
        {
            _queryOrderService = queryOrderService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string OrderKey)
        {
            var orderItems = await _queryOrderService.GetOrderProducts(OrderKey);
            return View( orderItems);
        }
    }
} 
