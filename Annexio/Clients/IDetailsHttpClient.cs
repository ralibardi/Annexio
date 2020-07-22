using System.Collections.Generic;
using System.Threading.Tasks;
using Annexio.Models;

namespace Annexio.Clients
{
    public interface IDetailsHttpClient
    {
        Task<BasicDetails> GetDetailsFromCountryAsync(string countryName);
        Task<List<BasicDetails>> GetDetailsFromRegionAsync(string regionName);
        Task<List<BasicDetails>> GetDetailsFromSubRegionAsync(string subRegionName);

    }
}