using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Documents.Tracker.Core.CompositeServices;
using Documents.Tracker.Core.DTO.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Orders.Core.Interface;

namespace Documents.Tracker.UI.Web.Pages.Orders
{
    public class OrdersModel : PageModel
    {
        private readonly IQueryOrderService _ordersCore;
        public ICollection<OrderOTO> orders { get; set; }
        public OrdersModel(
            IQueryOrderService ordersCore
            )
        {
            _ordersCore = ordersCore;
        }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                orders = await _ordersCore.GetAllOrders();
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}