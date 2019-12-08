using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Documents.Tracker.Core;
using Documents.Tracker.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Documents.Tracker.UI.Web.Pages.AppConsumers
{
    public class ConsumersModel : PageModel
    {
        private IQueryConsumersServices consumersServices { get; set; }
        private ICommandConsumerServices commandConsumer { get; set; }
        public IEnumerable<ConsumerOTO> ConsumerList { get; set; }

        public ConsumersModel(
            IQueryConsumersServices _consumersServices,
            ICommandConsumerServices _commandConsumer)
        {
            consumersServices = _consumersServices;
            commandConsumer = _commandConsumer;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (ModelState.IsValid)
                    ConsumerList = await consumersServices.GetAllConsumers();

                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message.ToString());
                return Page();
            }

        }

        public async Task<IActionResult> OnGetAddEditConsumerAsync(int RefId)
        {
            ConsumerOTO consumer  = new ConsumerOTO();
            if (RefId > 0)
            {
                consumer = await consumersServices.GetSingleConsumerByConusmerId(RefId);
            }
            return Partial("_AddEditConsumer", consumer);
        }
        public IActionResult OnPostSaveConsumer(ConsumerOTO conusmer)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();

                int i = commandConsumer.AddOrEditConsumerByConsumer(conusmer).Result;
                return RedirectToPage();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ex", ex.Message.ToString());
                return Page();
            }
         
        }

        public IActionResult OnPostDisableConsumer(int RefId)
        {
            try
            {
                int i = commandConsumer.SetEnableDisableConsumerByConusmerId(RefId).Result;
                return RedirectToPage();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ex", ex.Message.ToString());
                return Page();
            }
            
          
        }
    }
}