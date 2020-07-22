using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Annexio.Clients;
using Annexio.Models;

namespace Annexio.Mediators
{
    public partial class CountriesMediator : ICountriesMediator
    {
        private readonly ICountriesHttpClient _countriesHttpClient;

        public CountriesMediator(ICountriesHttpClient countriesHttpClient, IDetailsHttpClient detailsHttpClient)
        {
            _countriesHttpClient = countriesHttpClient ?? throw new ArgumentNullException(nameof(countriesHttpClient));
            _detailsHttpClient = detailsHttpClient ?? throw new ArgumentNullException(nameof(detailsHttpClient));
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            var countries = await _countriesHttpClient.GetAllCountriesAsync();

            return countries;
        }

        public async Task<IEnumerable<Country>> GetCountriesSubSet(int index, int length)
        {
            var countries = await _countriesHttpClient.GetCountriesSubsetAsync(index, length);

            return countries;
        }
    }

    public partial class CountriesMediator : ICountriesMediator
    {
        private readonly IDetailsHttpClient _detailsHttpClient;
        public async Task<BasicDetails> GetCountryDetails(string countryName)
        {
            var country = await _detailsHttpClient.GetDetailsFromCountryAsync(countryName);
            country.IsCountry = true;

            return country;
        }

        public async Task<BasicDetails> GetRegionDetails(string regionName)
        {
            var detailsList = await _detailsHttpClient.GetDetailsFromRegionAsync(regionName);

            var region = new BasicDetails
            {
                Name = regionName,
                Population = detailsList.Select(r => r.Population).Sum(),
                Languages = detailsList.SelectMany(r => r.Languages).Distinct(),
                Currencies = detailsList.SelectMany(r => r.Currencies).Distinct(),
                //Region = detailsList.SelectMany(r => r.Region).Distinct()
            };

            return region;
        }

        public async Task<BasicDetails> GetSubRegionDetails(string subRegionName)
        {
            throw new System.NotImplementedException();
        }
    }
}