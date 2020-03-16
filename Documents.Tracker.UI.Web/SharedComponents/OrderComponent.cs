using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Documents.Tracker.Core.CompositeServices;
using TodoTasks.Core.Interface;
using System.Collections.Generic;
using System.Linq;

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
        private readonly IQueryTodoTasksServices _queryTodoTasksServices;
        public PendingOrderItemsComponent(
            IQueryTodoTasksServices queryTodoTasksServices,
            ITaskLocationsCore taskLocationsCore,
            IQueryOrderService queryOrderService)
        {
            _queryTodoTasksServices = queryTodoTasksServices;
            _taskLocationsCore = taskLocationsCore;
            _queryOrderService = queryOrderService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string orderKey)
        {
            var orderItems = await _queryOrderService.GetOrderProducts(orderKey);
            List<PendingOrderProductServices> PendingorderItems = new List<PendingOrderProductServices>();

            foreach (var item in orderItems)
            {
                int _closedIds = 0;
                //var taskLocation = await _taskLocationsCore
                //    .GetSingleTaskLocationByExp(x =>
                //    x.IsClosed &&
                //    x.ProductId == item.ProductId);

                var _taskLocation = await _queryTodoTasksServices
                    .GetTodoTaskLocations(item.ProductId, item.Id);

                if (_taskLocation != null && _taskLocation.Count() > 0)
                    _closedIds = _taskLocation.Where(x => x.IsClosed).Count();

                PendingorderItems.Add(new PendingOrderProductServices
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    Name = item.Product.Name,
                    IsClosed = _closedIds > 0
                });
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
