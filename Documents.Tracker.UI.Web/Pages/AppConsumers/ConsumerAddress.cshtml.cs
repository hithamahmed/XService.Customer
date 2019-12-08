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
        //private IConsumersProfileCore ClientsCore { get; set; }
        private IQueryConsumersServices consumersServices { get; set; }
        private ICommandConsumerServices commandConsumerServices { get; set; }
        private IQueryGeneralService CountryService { get; set; }

        public ConsumersProfileOTO ManageAppConsumerDTO { get; set; }
        
        public ConsumerAddressModel(
            //IConsumersProfileCore _clientscore, 
            IQueryGeneralService _CountryService,
            IQueryConsumersServices _consumersServices,
            ICommandConsumerServices _commandConsumerServices)
        {
            //ClientsCore = _clientscore;
            CountryService = _CountryService;
            consumersServices = _consumersServices;
            commandConsumerServices = _commandConsumerServices;
        }
        public async Task<IActionResult> OnGet(int ConsumerRefId)
        {
            try
            {
                ManageAppConsumerDTO = new ConsumersProfileOTO();
                if (ModelState.IsValid)
                {
                    ManageAppConsumerDTO = await consumersServices.GetSingleConsumerWithAddressByConsumerId(ConsumerRefId);
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
            ConsumerAddressOTO consumerAddress = new ConsumerAddressOTO { 
            ConsumerId = ConsumerRefId
            };
            if (RefId > 0)
            {
                consumerAddress = await consumersServices.GetSingleConsumerAddressByAddressId(RefId);
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

        public IActionResult OnPostSaveConsumerAddress(ConsumerAddressOTO conusmerAddress)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("ex", ModelState.ErrorCount.ToString());
                    return Page();
                }
                    

                int i = commandConsumerServices.AddOrEditConsumerAddressByConsumer(conusmerAddress).Result;
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
                int i = commandConsumerServices.SetDefaultConsumerAddressByAddressId(RefId).Result;
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