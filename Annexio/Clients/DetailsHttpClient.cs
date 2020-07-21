using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Annexio.Builders;
using Annexio.Models;
using Newtonsoft.Json;

namespace Annexio.Clients
{
    public class DetailsHttpClient : IDetailsHttpClient
    {
        private readonly IRestCountriesUriBuilder _uriBuilder;

        public DetailsHttpClient(IRestCountriesUriBuilder uriBuilder)
        {
            _uriBuilder = uriBuilder ?? throw new ArgumentNullException(nameof(uriBuilder));
        }

        public async Task<Details> GetDetailsFromCountryAsync(string countryName)
        {
            _uriBuilder.Reset();
            var uriBuilder = _uriBuilder.WithCountryName(countryName).FilterByModel(typeof(Details));

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(uriBuilder.BuildUri());
                result.EnsureSuccessStatusCode();
                var responseBody = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Details>>(responseBody).FirstOrDefault();
            }
        }

        public async Task<Details> GetDetailsFromRegionAsync(string regionName)
        {
            _uriBuilder.Reset();
            var uriBuilder = _uriBuilder.WithRegionName(regionName).FilterByModel(typeof(Details));

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(uriBuilder.BuildUri());
                result.EnsureSuccessStatusCode();
                var responseBody = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Details>>(responseBody).FirstOrDefault();
            }
        }

        public async Task<Details> GetDetailsFromSubRegionAsync(string subRegionName)
        {
            _uriBuilder.Reset();
            var uriBuilder = _uriBuilder.WithSubRegionName(subRegionName).FilterByModel(typeof(Details));

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(uriBuilder.BuildUri());
                result.EnsureSuccessStatusCode();
                var responseBody = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Details>>(responseBody).FirstOrDefault();
            }
        }
    }
}