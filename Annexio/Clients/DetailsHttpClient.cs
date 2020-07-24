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

        public async Task<CountryDetails> GetDetailsFromCountryNameAsync(string countryName)
        {
            _uriBuilder.Reset();
            var uriBuilder = _uriBuilder.WithCountryName(countryName).FilterByModel(typeof(CountryDetails));

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(uriBuilder.BuildUri());
                result.EnsureSuccessStatusCode();
                var responseBody = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<CountryDetails>>(responseBody).FirstOrDefault();
            }
        }

        public async Task<CountryDetails> GetDetailsFromCountryCodeAsync(string countryCode)
        {
            _uriBuilder.Reset();
            var uriBuilder = _uriBuilder.WithCountryCode(countryCode).FilterByModel(typeof(CountryDetails));

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(uriBuilder.BuildUri());
                result.EnsureSuccessStatusCode();
                var responseBody = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<CountryDetails>(responseBody);
            }
        }

        public async Task<List<CountryDetails>> GetDetailsFromRegionAsync(string regionName)
        {
            _uriBuilder.Reset();
            var uriBuilder = _uriBuilder.WithRegionName(regionName).FilterByModel(typeof(CountryDetails));

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(uriBuilder.BuildUri());
                result.EnsureSuccessStatusCode();
                var responseBody = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<CountryDetails>>(responseBody);
            }
        }

        public async Task<List<CountryDetails>> GetDetailsFromSubRegionAsync(string subRegionName)
        {
            _uriBuilder.Reset();
            var uriBuilder = _uriBuilder.WithSubRegionName(subRegionName).FilterByModel(typeof(CountryDetails));

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(uriBuilder.BuildUri());
                result.EnsureSuccessStatusCode();
                var responseBody = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<CountryDetails>>(responseBody);
            }
        }
    }
}