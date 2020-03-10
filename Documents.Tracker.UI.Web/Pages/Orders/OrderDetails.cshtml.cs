using Documents.Tracker.Core.CompositeServices;
using Documents.Tracker.Core.DTO.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Documents.Tracker.UI.Web.Pages.Orders
{
    public class OrderDetailsModel : PageModel
    {
        private readonly IQueryOrderService _ordersCore;
        private readonly ICommandOrderService _commandOrder;
        public OrderOTO OrderDetails { get; set; }

        public OrderDetailsModel(
            IQueryOrderService ordersCore,
            ICommandOrderService commandOrder
            )
        {
            _ordersCore = ordersCore;
            _commandOrder = commandOrder;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            try
            {
                Guid guid = Guid.NewGuid();
                if (!Guid.TryParse(id, out guid))
                    return RedirectToPage("Orders");

                OrderDetails = await _ordersCore.GetSingleOrder(guid.ToString());
                if(OrderDetails!=null)
                    return Page();

                return RedirectToPage("Orders");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> OnPostSetOrderStatus(string orderkey, int statusid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToPage(new { id = orderkey });
                }

                OrderDetails = await _commandOrder.SetOrderStatus(orderkey, statusid);
                return RedirectToPage(new { id = orderkey });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}