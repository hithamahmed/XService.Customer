using Documents.Tracker.UI.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Documents.Tracker.UI.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public Pager _pager { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet(int? page)
        {
            var pager = new Pager(30, page, 10);

            var itemcounts = (pager.CurrentPage - 1) * pager.PageSize;
            _pager = pager;
            return Page();
        }
    }
}
