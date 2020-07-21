using System.Threading.Tasks;
using Annexio.Models;

namespace Annexio.Clients
{
    public interface IDetailsHttpClient
    {
        Task<Details> GetDetailsFromCountryAsync(string countryName);
        Task<Details> GetDetailsFromRegionAsync(string regionName);
        Task<Details> GetDetailsFromSubRegionAsync(string subRegionName);

    }
}