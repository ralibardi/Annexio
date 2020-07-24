using System;

namespace Annexio.Builders
{
    public interface IRestCountriesUriBuilder
    {
        RestCountriesUriBuilder WithAllCountries();
        RestCountriesUriBuilder WithCountryName(string countryName);
        RestCountriesUriBuilder WithCountryCode(string countryCode);
        RestCountriesUriBuilder WithRegionName(string regionName);
        RestCountriesUriBuilder WithSubRegionName(string subRegionName);
        RestCountriesUriBuilder FilterByModel(Type type);
        void Reset();
        Uri BuildUri();
    }
}