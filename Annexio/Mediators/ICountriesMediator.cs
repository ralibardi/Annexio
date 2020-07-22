using System.Collections.Generic;
using System.Threading.Tasks;
using Annexio.Models;

namespace Annexio.Mediators
{
    public interface ICountriesMediator
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<IEnumerable<Country>> GetCountriesSubSet(int index, int length);
        Task<BasicDetails> GetCountryDetails(string countryName);
        Task<BasicDetails> GetRegionDetails(string regionName);
        Task<BasicDetails> GetSubRegionDetails(string subRegionName);
    }
}