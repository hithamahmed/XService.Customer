using AutoMapper;
using Documents.Tracker.UI.Web.Settings;
using General.Services.Core;
using General.Services.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.UI.Web.Pages
{
    public class CountriesModel : PageModelBase
    {
        private ICountries CountryService { get; set; }
        public IEnumerable<CountryDTO> countries { get; set; }
        public IEnumerable<GovernmentDTO> governments { get; set; }
        public IEnumerable<LocationAreaDTO> locationAreas { get; set; }
        //public IMapper mapper { get; set; }

        public CountriesModel(ICountries _CountryService)
        {
            CountryService = _CountryService;
        }

        #region Countries

        public async Task<IActionResult> OnGet()
        {
            countries = await CountryService.GetAllCountries();
            foreach (var country in countries)
            {
                var Governments = country.Governments = await CountryService.GetAllGovernmentsByCountry(country.RefId).ConfigureAwait(false);
                foreach (var government in Governments)
                {
                    var locationareas = government.LocationAreas = await CountryService.GetAllAreasByGoverment(government.RefId).ConfigureAwait(false);
                }
            }
            return Page();
        }
        public async Task<IActionResult> OnGetAddEditCountryAsync(int id)
        {
            CountryDTO country = new CountryDTO();
            if (id > 0)
            {
                country = await CountryService.GetCountryById(id);
            }
            return Partial("_AddEditCountry", country);
        }
        public IActionResult OnPostSaveCountry(CountryDTO country)
        {
            if (!ModelState.IsValid)
                return RedirectToPage();

            int i = CountryService.AddEditCountry(country).Result;
            return RedirectToPage();
        }
        public IActionResult OnPostDisableCountry(int id)
        {

            int i = CountryService.EnableDisableCountry(id).Result;
            return RedirectToPage();
        }

        #endregion


        #region Governments


        public async Task<IActionResult> OnGetGovernments(int Countryid)
        {
            governments = await CountryService.GetAllGovernmentsByCountry(Countryid);
            return Page();
        }
        public async Task<IActionResult> OnGetAddEditGovernmentAsync(int Countryid,int id)
        {
            GovernmentDTO government = new GovernmentDTO
            {
                CountryId = Countryid
            };
            if (id > 0)
            {
                government = await CountryService.GetGovernmentById(id);
            }
            return Partial("_AddEditGovernments", government);
        }
        public IActionResult OnPostSaveGovernment(GovernmentDTO government)
        {
            if (!ModelState.IsValid)
                return RedirectToPage();

            int i = CountryService.AddEditGovernment(government).Result;
            return RedirectToPage();
        }
        public IActionResult OnPostDisableGovernment(int id)
        {

            int i = CountryService.EnableDisableGovernment(id).Result;
            return RedirectToPage();
        }
        #endregion

        #region Location Areas
        
        public async Task<IActionResult> OnGetlocationAreas(int governmentid)
        {
            locationAreas = await CountryService.GetAllAreasByGoverment(governmentid);
            return Page();
        }
        public async Task<IActionResult> OnGetAddEditlocationAreaAsync(int governmentid, int id)
        {
            LocationAreaDTO locationArea = new LocationAreaDTO
            {
                GovernmentId = governmentid
            };
            if (id > 0)
            {
                locationArea = await CountryService.GetLocationAreaById(id);
            }
            return Partial("_AddEditlocationArea", locationArea);
        }
        public IActionResult OnPostSavelocationArea(LocationAreaDTO locationArea)
        {
            if (!ModelState.IsValid)
                return RedirectToPage();

            int i = CountryService.AddEditLocationArea(locationArea).Result;
            return RedirectToPage();
        }
        public IActionResult OnPostDisableLocationArea(int id)
        {

            int i = CountryService.EnableDisableLocationArea(id).Result;
            return RedirectToPage();
        }
        
        #endregion
    }
}