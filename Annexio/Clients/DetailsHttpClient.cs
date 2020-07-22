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

        public async Task<BasicDetails> GetDetailsFromCountryAsync(string countryName)
        {
            _uriBuilder.Reset();
            var uriBuilder = _uriBuilder.WithCountryName(countryName).FilterByModel(typeof(BasicDetails));

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(uriBuilder.BuildUri());
                result.EnsureSuccessStatusCode();
                var responseBody = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<BasicDetails>>(responseBody).FirstOrDefault();
            }
        }

        public async Task<List<BasicDetails>> GetDetailsFromRegionAsync(string regionName)
        {
            _uriBuilder.Reset();
            var uriBuilder = _uriBuilder.WithRegionName(regionName).FilterByModel(typeof(BasicDetails));

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(uriBuilder.BuildUri());
                result.EnsureSuccessStatusCode();
                var responseBody = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<BasicDetails>>(responseBody);
            }
        }

        public async Task<List<BasicDetails>> GetDetailsFromSubRegionAsync(string subRegionName)
        {
            _uriBuilder.Reset();
            var uriBuilder = _uriBuilder.WithSubRegionName(subRegionName).FilterByModel(typeof(BasicDetails));

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(uriBuilder.BuildUri());
                result.EnsureSuccessStatusCode();
                var responseBody = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<BasicDetails>>(responseBody);
            }
        }
    }
}