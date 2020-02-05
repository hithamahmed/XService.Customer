using Documents.Tracker.Core.CompositeServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Tracker.UI.Web.SharedComponents
{
     
    [ViewComponent(Name = "SetOrderStatus")]
    public class OrderComponent : ViewComponent
    {
        private readonly ICommandOrderService _ordersCore;
        //public IEnumerable<Orders.Core.OrderStatus.OrderStatusEnums> OrderStatus ;
        public string OrderKey { get; set; }
        public OrderComponent(ICommandOrderService ordersCore)
        {
            _ordersCore = ordersCore;
        }
        //public async Task<IViewComponentResult> InvokeSetStatusAsync(string OrderKey, int status)
        //{
        //    await _ordersCore.SetOrderStatus(OrderKey, status);
        //    return View();
        //}
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            OrderKey = id;
            //return await Task.FromResult((IViewComponentResult)View("OrderStatus", OrderKey));

            return View<string>(OrderKey);
        }
    }
}
