using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Documents.Tracker.Core;
using Documents.Tracker.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Documents.Tracker.UI.Web.Pages.AppConsumers
{
    public class ConsumerAddressModel : PageModel
    {
        private IConsumersCore ClientsCore { get; set; }
        private ICountryCore CountryService { get; set; }

        public ManageAppConsumersDTO ManageAppConsumerDTO { get; set; }
        
        public ConsumerAddressModel(IConsumersCore _clientscore, ICountryCore _CountryService)
        {
            ClientsCore = _clientscore;
            CountryService = _CountryService;
        }
        public async Task<IActionResult> OnGet(int ConsumerRefId)
        {
            try
            {
                ManageAppConsumerDTO = new ManageAppConsumersDTO();
                if (ModelState.IsValid)
                {
                    ManageAppConsumerDTO.Consumer = await ClientsCore.GetSingleConsumer(ConsumerRefId);
                    var ConsumAddresses = await ClientsCore.GetConsumerAddresses(ConsumerRefId);
                    ManageAppConsumerDTO.AppConsumerAddresses = ConsumAddresses;
                }
                   

                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message.ToString());
                return Page();
            }
        }

        public async Task<IActionResult> OnGetAddEditConsumerAddressAsync(int ConsumerRefId,int RefId)
        {
            AppConsumerAddressDTO consumerAddress = new AppConsumerAddressDTO { 
            ConsumerId = ConsumerRefId
            };
            if (RefId > 0)
            {
                consumerAddress = await ClientsCore.GetConsumerAddressById(RefId);
            }
            var allcountries = CountryService.GetCountriesList().Result;
            var countries = allcountries
                .Select(x =>
                new { label = x.Name, value = x.RefId }).ToList();
            consumerAddress.CountriesList = allcountries;

            return Partial("_AddEditConsumerAddress", consumerAddress);
        }

        public async Task<IActionResult> OnGetGovernmentByCountryAsync(int countryId)
        {
            var govenmentsList =  await CountryService.GetGovernmentsByCountry(countryId);
            //var govenments = govenmentsList
            //    .Select(x =>
            //    new { label = x.Name, value = x.RefId }).ToList();

            //var modelJson =  JsonSerializer.Serialize(govenmentsList);

            return new JsonResult(govenmentsList);
        }
        
        public async Task<IActionResult> OnGetLocationByGovernmentAsync(int governmentId)
        {
            var locationsList = await CountryService.GetLocationByGovernment(governmentId);
            //var locations = locationsList
            //   .Select(x =>
            //   new { label = x.Name, value = x.RefId }).ToList();
            return new JsonResult(locationsList);
        }

        public IActionResult OnPostSaveConsumerAddress(AppConsumerAddressDTO conusmerAddress)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("ex", ModelState.ErrorCount.ToString());
                    return Page();
                }
                    

                int i = ClientsCore.AddEditConsumerAddress(conusmerAddress).Result;
                return RedirectToPage("ConsumerAddress", new { ConsumerRefId = conusmerAddress.RefId });
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ex", ex.Message.ToString());
                return Page();
            }

        }

        public IActionResult OnPostSetDefaultConsumerAddress(int consumerRefId,int RefId)
        {
            try
            {
                int i = ClientsCore.SetConsumerAddressAsDefault(RefId).Result;
                return RedirectToPage("ConsumerAddress", new { ConsumerRefId = consumerRefId });
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("ex", ex.Message.ToString());
                return Page();
            }


        }
    }
}