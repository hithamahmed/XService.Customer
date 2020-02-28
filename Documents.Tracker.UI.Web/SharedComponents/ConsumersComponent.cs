using Documents.Tracker.Core;
using Documents.Tracker.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Documents.Tracker.UI.Web.SharedComponents
{


    [ViewComponent(Name = "ConsumerInfo")]
    public class ConsumersInfoComponent : ViewComponent
    {
        private readonly IQueryConsumersServices consumersServices;
        public ConsumersProfileOTO Consumer { get; set; }
        public ConsumersInfoComponent(IQueryConsumersServices _consumersServices)
        {
            consumersServices = _consumersServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(string ConusmerId)
        {
            Consumer = await consumersServices.GetSingleConsumerWithAddressByConsumerId(ConusmerId);
            return View<ConsumersProfileOTO>(Consumer);
        }
    }
}
