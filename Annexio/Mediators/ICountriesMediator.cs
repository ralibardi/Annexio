using System.Collections.Generic;
using System.Threading.Tasks;
using Annexio.Models;

namespace Annexio.Mediators
{
    public interface ICountriesMediator
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<IEnumerable<Country>> GetCountriesSubSet(int index, int length);
        Task<CountryDetails> GetCountryDetailsByName(string countryName);
        Task<CountryDetails> GetCountryDetailsByCode(string countryCode);
        Task<RegionDetails> GetRegionDetails(string regionName);
        Task<RegionDetails> GetSubRegionDetails(string subRegionName);
    }
}