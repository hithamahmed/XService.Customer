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
        private IConsumersCore  ClientsCore { get; set; }
        public IEnumerable<APPConsumerDTO> ConsumerList { get; set; }

        public ConsumersModel(IConsumersCore _clientscore)
        {
            ClientsCore = _clientscore;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (ModelState.IsValid)
                    ConsumerList = await ClientsCore.GetConsumers();

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
            APPConsumerDTO consumer  = new APPConsumerDTO();
            if (RefId > 0)
            {
                consumer = await ClientsCore.GetSingleConsumer(RefId);
            }
            return Partial("_AddEditConsumer", consumer);
        }
        public IActionResult OnPostSaveConsumer(APPConsumerDTO conusmer)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();

                int i = ClientsCore.AddEditConsumer(conusmer).Result;
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
                int i = ClientsCore.EnableDisableConsumer(RefId).Result;
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