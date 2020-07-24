using System.Collections.Generic;
using System.Threading.Tasks;
using Annexio.Models;

namespace Annexio.Clients
{
    public interface IDetailsHttpClient
    {
        Task<CountryDetails> GetDetailsFromCountryNameAsync(string countryName);
        Task<CountryDetails> GetDetailsFromCountryCodeAsync(string countryCode);
        Task<List<CountryDetails>> GetDetailsFromRegionAsync(string regionName);
        Task<List<CountryDetails>> GetDetailsFromSubRegionAsync(string subRegionName);

    }
}