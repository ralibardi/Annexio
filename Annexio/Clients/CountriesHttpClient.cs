using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Annexio.Builders;
using Annexio.Models;
using Newtonsoft.Json;

namespace Annexio.Clients
{
    public class CountriesHttpClient : ICountriesHttpClient
    {
        private readonly IRestCountriesUriBuilder _uriBuilder;

        public CountriesHttpClient(IRestCountriesUriBuilder uriBuilder)
        {
            _uriBuilder = uriBuilder ?? throw new ArgumentNullException(nameof(uriBuilder));
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            _uriBuilder.Reset();
            var uriBuilder = _uriBuilder.WithAllCountries().FilterByModel(typeof(Country));

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(uriBuilder.BuildUri());
                result.EnsureSuccessStatusCode();
                var responseBody = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Country>>(responseBody);
            }
        }

        public async Task<IEnumerable<Country>> GetCountriesSubsetAsync(int index, int length)
        {
            var allCountries = await GetAllCountriesAsync();

            return allCountries.GetRange(index, length);
        }
    }

}