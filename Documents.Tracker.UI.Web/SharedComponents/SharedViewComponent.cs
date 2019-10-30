using Documents.Tracker.UI.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Documents.Tracker.UI.Web.SharedComponents
{

    [ViewComponent(Name = "Paginations")]
    public class PaginationsViewComponent : ViewComponent
    {
        public PaginationsViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(Pager page)
        {
            return View(page);

        }
    }

    [ViewComponent(Name = "HeaderMobile")]
    public class HeaderMobileViewComponent : ViewComponent
    {
        public HeaderMobileViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();

        }
    }
}
