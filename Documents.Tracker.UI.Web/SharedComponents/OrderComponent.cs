using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Documents.Tracker.Core.CompositeServices;
using TodoTasks.Core.Interface;
using System.Collections.Generic;

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
        private readonly ITaskLocationsCore _taskLocationsCore;
        public PendingOrderItemsComponent(ITaskLocationsCore taskLocationsCore,
            IQueryOrderService queryOrderService)
        {
            _taskLocationsCore = taskLocationsCore;
            _queryOrderService = queryOrderService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int orderid)
        {
            var orderItems = await _queryOrderService.GetOrderProducts(orderid);
            List<PendingOrderProductServices> PendingorderItems = new List<PendingOrderProductServices>();

            foreach (var item in orderItems)
            {
                var taskLocation = await _taskLocationsCore
                    .GetSingleTaskLocationByExp(x =>
                    x.IsClosed &&
                    x.ProductId == item.ProductId);

                PendingorderItems.Add(new PendingOrderProductServices
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    Name = item.Product.Name,
                    IsClosed = taskLocation != null && taskLocation.Id > 0 ? true : false });
            }
            return View(PendingorderItems);
        }
        public class PendingOrderProductServices{
            public int Id { get; set; }
            public int ProductId { get; set; }
            public string Name { get; set; }
            public bool IsClosed { get; set; }
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
    [ViewComponent(Name = "OrderHeader")]
    public class OrderHeaderComponent : ViewComponent
    {
        private readonly IQueryOrderService _queryOrderService;
        public OrderHeaderComponent(IQueryOrderService queryOrderService)
        {
            _queryOrderService = queryOrderService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string OrderKey)
        {
            var order = await _queryOrderService.GetSingleOrder(OrderKey);
            return View(order);
        }
    }
    [ViewComponent(Name = "OrderPayment")]
    public class OrderPaymentComponent : ViewComponent
    {
        private readonly IQueryOrderService _queryOrderService;
        public OrderPaymentComponent(IQueryOrderService queryOrderService)
        {
            _queryOrderService = queryOrderService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string OrderKey)
        {
            var order = await _queryOrderService.GetSingleOrderPayment(OrderKey);
            return View(order);
        }
    }
} 
