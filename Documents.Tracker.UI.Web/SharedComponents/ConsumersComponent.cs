using Documents.Tracker.Core;
using Documents.Tracker.Core.DTO;
using Documents.Tracker.Core.DTO.Consumers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

    [ViewComponent(Name = "ConsumerDocuments")]
    public class ConsumerDocumentsComponent : ViewComponent
    {
        private readonly IQueryConsumersServices consumersServices;
        public ICollection<ConsumerProductDocumentFileOTO> consumerProductDocumentFiles  { get; set; }
        public ConsumerDocumentsComponent(IQueryConsumersServices _consumersServices)
        {
            consumersServices = _consumersServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(string ConusmerId,int ProductId)
        {
            consumerProductDocumentFiles = await consumersServices.GetConsumerProductAttachmentFiles(ConusmerId, ProductId);
            return View(consumerProductDocumentFiles);
        }
    }
}
