using System;
using System.Linq;
using System.Text;

namespace Annexio.Builders
{
    public class RestCountriesUriBuilder : IRestCountriesUriBuilder
    {
        private StringBuilder _url;

        public RestCountriesUriBuilder()
        {
            this.Reset();
        }

        public RestCountriesUriBuilder WithAllCountries()
        {
            _url.Append("all");
            return this;
        }

        public RestCountriesUriBuilder WithCountryName(string countryName)
        {
            var args = new []
            {
                "name",
                countryName
            };

            _url.Append(string.Join("/", args));
            return this;
        }

        public RestCountriesUriBuilder WithCountryCode(string countryCode)
        {
            var args = new[]
            {
                "alpha",
                countryCode
            };

            _url.Append(string.Join("/", args));
            return this;
        }

        public RestCountriesUriBuilder WithRegionName(string regionName)
        {
            var args = new[]
            {
                "region",
                regionName
            };

            _url.Append(string.Join("/", args));
            return this;
        }

        public RestCountriesUriBuilder WithSubRegionName(string subRegionName)
        {
            var args = new[]
            {
                "subregion",
                subRegionName
            };

            _url.Append(string.Join("/", args));
            return this;
        }

        public RestCountriesUriBuilder FilterByModel(Type type)
        {
            var properties = type.GetProperties().Select(p => p.Name.ToLower());

            _url.Append("?fields=");
            _url.Append(string.Join(";", properties));

            return this;
        }

        public void Reset()
        {
            _url = new StringBuilder(Resources.ApiUrl);
        }

        public Uri BuildUri()
        {
            return new Uri(_url.ToString());
        }
    }
}