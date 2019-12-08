using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO;
using General.Services.Core;
using General.Services.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    internal class CountryGeneralCore : MapperCore, IGeneralCore
    {
        private ICountries CountriesService { get; set; }
        private IProducts ServicesCategory { get; set; }
        public CountryGeneralCore(ICountries _CountriesService, IProducts _ServicesCategory)
        {
            CountriesService = _CountriesService;
            ServicesCategory = _ServicesCategory;
        }

        public async Task<ICollection<GeneralCountriesDTO>> GetCountriesList()
        {
            try
            {
                var Lists = await CountriesService.GetAllCountries();
                var mapps = Mapper.Map<ICollection<GeneralCountriesDTO>>(Lists);
                return mapps;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<GeneralGovernmentDTO>> GetGovernmentsByCountry(int CountryId)
        {
            try
            {
                var Lists = await CountriesService.GetAllGovernmentsByCountry(CountryId);
                var mapps = Mapper.Map<ICollection<GeneralGovernmentDTO>>(Lists);
                return mapps;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<GeneralLocationAreasDTO>> GetLocationByGovernment(int GovernmentId)
        {
            try
            {
                var Lists = await CountriesService.GetAllAreasByGoverment(GovernmentId);
                var mapps = Mapper.Map<ICollection<GeneralLocationAreasDTO>>(Lists);
                return mapps;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralCountriesDTO> GetSingleCountry(int CountryId)
        {
            try
            {
                var single = await CountriesService.GetCountryById(CountryId);
                var mapps = Mapper.Map<GeneralCountriesDTO>(single);
                return mapps;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralGovernmentDTO> GetSingleGovernment(int GovernmentId)
        {
            try
            {
                var single = await CountriesService.GetGovernmentById(GovernmentId);
                var mapps = Mapper.Map<GeneralGovernmentDTO>(single);
                return mapps;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralLocationAreasDTO> GetSingleLocation(int LocationId)
        {
            try
            {
                var single = await CountriesService.GetLocationAreaById(LocationId);
                var mapps = Mapper.Map<GeneralLocationAreasDTO>(single);
                return mapps;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IReadOnlyCollection<GeneralCategoriesDTO>> GetCategories()
        {
            try
            {
                var _list = await ServicesCategory.GetCategories();
                var mapps = Mapper.Map<IReadOnlyCollection<GeneralCategoriesDTO>>(_list);
                return mapps;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IReadOnlyCollection<GeneralServicesDTO>> GetServicesCategory(int categoryId)
        {
            try
            {
                var _list = await ServicesCategory.GetListProductsByCategory(categoryId);
                var mapps = Mapper.Map<IReadOnlyCollection<GeneralServicesDTO>>(_list);
                return mapps;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
