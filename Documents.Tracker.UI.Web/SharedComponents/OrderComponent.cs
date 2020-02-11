using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
}
