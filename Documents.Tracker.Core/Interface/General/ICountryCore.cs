using Documents.Tracker.Core.DTO;
using General.Services.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface ICountryCore 
    {
        public Task<ICollection<GeneralCountriesDTO>> GetCountriesList();
        public Task<ICollection<GeneralGovernmentDTO>> GetGovernmentsByCountry(int CountryId);
        public Task<ICollection<GeneralLocationAreasDTO>> GetLocationByGovernment(int GovernmentId);

        public Task<GeneralCountriesDTO> GetSingleCountry(int CountryId);
        public Task<GeneralGovernmentDTO> GetSingleGovernment(int GovernmentId);
        public Task<GeneralLocationAreasDTO> GetSingleLocation(int LocationId);
    }
}
