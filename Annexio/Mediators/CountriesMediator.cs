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

            return country;
        }

        public async Task<RegionDetails> GetRegionDetails(string regionName)
        {
            var detailsList = await _detailsHttpClient.GetDetailsFromRegionAsync(regionName);

            var region = new RegionDetails
            {
                Name = regionName,
                Population = detailsList.Select(r => r.Population).Sum(),
                Languages = detailsList.SelectMany(r => r.Languages).Distinct(),
                Currencies = detailsList.SelectMany(r => r.Currencies).Distinct(),
                SubRegions = detailsList.Select(r => r.Subregion).Distinct(),
                Countries = detailsList.Select(r => r.Name).Distinct(),
                Regions = new List<string>()
            };

            return region;
        }

        public async Task<RegionDetails> GetSubRegionDetails(string subRegionName)
        {
            var detailsList = await _detailsHttpClient.GetDetailsFromRegionAsync(subRegionName);

            var region = new RegionDetails
            {
                Name = subRegionName,
                Population = detailsList.Select(r => r.Population).Sum(),
                Languages = detailsList.SelectMany(r => r.Languages).Distinct(),
                Currencies = detailsList.SelectMany(r => r.Currencies).Distinct(),
                Regions = detailsList.Select(r => r.Region).Distinct(),
                Countries = detailsList.Select(r => r.Name).Distinct(),
                SubRegions = new List<string>()
            };

            return region;
        }
    }
}