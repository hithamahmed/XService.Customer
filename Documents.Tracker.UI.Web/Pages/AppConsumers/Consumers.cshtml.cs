using Documents.Tracker.Core;
using Documents.Tracker.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.UI.Web.Pages.AppConsumers
{
    public class ConsumersModel : PageModel
    {
        private IQueryConsumersServices consumersServices { get; set; }
        private ICommandConsumerServices commandConsumer { get; set; }
        public IEnumerable<ConsumerOTO> ConsumerList { get; set; }

        public ConsumersModel(
            IQueryConsumersServices _consumersServices,
            ICommandConsumerServices _commandConsumer
            )
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

        public async Task<IActionResult> OnGetAddEditConsumerAsync(string RefId)
        {
            ConsumerOTO consumer = new ConsumerOTO();
            if (!string.IsNullOrWhiteSpace(RefId))
            {
                consumer = await consumersServices.GetSingleConsumerByConusmerId(RefId);
            }
            return Partial("_AddEditConsumer", consumer);
        }
        public async Task<IActionResult> OnPostSaveConsumer(ConsumerOTO conusmer)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();

                int i = await commandConsumer.EditConsumerProfile(conusmer);
                return RedirectToPage();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ex", ex.Message.ToString());
                return RedirectToPage();
            }

        }

        public IActionResult OnPostDisableConsumer(int RefId)
        {
            try
            {
                //int i = commandConsumer.SetEnableDisableConsumerByConusmerId(RefId).Result;
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