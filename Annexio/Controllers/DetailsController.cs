using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Annexio.Clients;

namespace Annexio.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IDetailsHttpClient _client;

        public DetailsController(IDetailsHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        // GET: Country Details
        public async Task<ViewResult> CountryDetails(string countryName)
        {
            var country = await _client.GetDetailsFromCountryAsync(countryName);
            country.Id = countryName;

            return View(country);
        }

        // GET: Country Details
        public async Task<ViewResult> RegionDetails(string regionName)
        {
            var region = await _client.GetDetailsFromRegionAsync(regionName);
            region.Id = regionName;

            return View(region);
        }

        // GET: Country Details
        public async Task<ViewResult> SubRegionDetails(string subRegionName)
        {
            var subRegion = await _client.GetDetailsFromSubRegionAsync(subRegionName);
            subRegion.Id = subRegionName;

            return View(subRegion);
        }
    }
}