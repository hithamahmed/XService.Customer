using Documents.Tracker.Core;
using Documents.Tracker.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Documents.Tracker.UI.Web.SharedComponents
{
    public class ConsumersComponent : ViewComponent { }

    [ViewComponent(Name = "ConsumerInfo")]
    public class ConsumersInfoComponent : ViewComponent
    {
        private readonly IQueryConsumersServices consumersServices;
        public ConsumerOTO Consumer { get; set; }
        public ConsumersInfoComponent(IQueryConsumersServices _consumersServices)
        {
            consumersServices = _consumersServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(string ConusmerId)
        {
            Consumer = await consumersServices.GetSingleConsumerByConusmerId(ConusmerId);
            return View<ConsumerOTO>(Consumer);
        }
    }
}
