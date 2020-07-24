using Annexio.Builders;
using Annexio.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Annexio.Tests.Builders
{
    public class RestCountriesUriBuilderTests
    {
        private static RestCountriesUriBuilder GetUriBuilder()
        {
            return new RestCountriesUriBuilder();
        }

        [Test]
        public void RestCountriesUriBuilder_BuildUri_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.BuildUri();

            result.ToString().Should().Be("https://restcountries.eu/rest/v2/", "This is the URL currently in use");
        }

        [Test]
        public void RestCountriesUriBuilder_WithAllCountries_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.WithAllCountries().BuildUri();

            result.ToString().Should().Be("https://restcountries.eu/rest/v2/all", "This is the URL currently in use");
        }

        [Test]
        public void RestCountriesUriBuilder_WithAllCountriesAndFilterByCountry_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.WithAllCountries().FilterByModel(typeof(Country)).BuildUri();

            result.ToString().Should().Be("https://restcountries.eu/rest/v2/all?fields=name;region;subregion", "This is the URL currently in use");
        }

        [Test]
        public void RestCountriesUriBuilder_WithAllCountriesAndFilterByDetails_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.WithAllCountries().FilterByModel(typeof(RegionDetails)).BuildUri();

            result
                .ToString()
                .Should()
                .Be("https://restcountries.eu/rest/v2/all?fields=name;population;languages;currencies;countries;regions;subregions", "This is the URL currently in use");
        }

        [Test]
        public void RestCountriesUriBuilder_WithCountryName_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.WithCountryName("TestCountry").BuildUri();

            result.ToString().Should().Be("https://restcountries.eu/rest/v2/name/TestCountry", "This is the URL currently in use");
        }

        [Test]
        public void RestCountriesUriBuilder_WithCountryNameAndFilterByCountry_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.WithCountryName("TestCountry").FilterByModel(typeof(Country)).BuildUri();

            result.ToString().Should().Be("https://restcountries.eu/rest/v2/name/TestCountry?fields=name;region;subregion", "This is the URL currently in use");
        }

        [Test]
        public void RestCountriesUriBuilder_WithCountryNameAndFilterByDetails_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.WithCountryName("TestCountry").FilterByModel(typeof(RegionDetails)).BuildUri();

            result
                .ToString()
                .Should()
                .Be("https://restcountries.eu/rest/v2/name/TestCountry?fields=name;population;languages;currencies;countries;regions;subregions", "This is the URL currently in use");
        }

        [Test]
        public void RestCountriesUriBuilder_WithCountryCode_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.WithCountryCode("TC").BuildUri();

            result.ToString().Should().Be("https://restcountries.eu/rest/v2/alpha/TC", "This is the URL currently in use");
        }

        [Test]
        public void RestCountriesUriBuilder_WithCountryCodeAndFilterByCountry_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.WithCountryCode("TC").FilterByModel(typeof(Country)).BuildUri();

            result.ToString().Should().Be("https://restcountries.eu/rest/v2/alpha/TC?fields=name;region;subregion", "This is the URL currently in use");
        }

        [Test]
        public void RestCountriesUriBuilder_WithCountryCodeAndFilterByDetails_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.WithCountryCode("TC").FilterByModel(typeof(RegionDetails)).BuildUri();

            result
                .ToString()
                .Should()
                .Be("https://restcountries.eu/rest/v2/alpha/TC?fields=name;population;languages;currencies;countries;regions;subregions", "This is the URL currently in use");
        }

        [Test]
        public void RestCountriesUriBuilder_WithRegionName_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.WithRegionName("TestRegion").BuildUri();

            result.ToString().Should().Be("https://restcountries.eu/rest/v2/region/TestRegion", "This is the URL currently in use");
        }

        [Test]
        public void RestCountriesUriBuilder_WithRegionNameAndFilterByCountry_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.WithRegionName("TestRegion").FilterByModel(typeof(Country)).BuildUri();

            result.ToString().Should().Be("https://restcountries.eu/rest/v2/region/TestRegion?fields=name;region;subregion", "This is the URL currently in use");
        }

        [Test]
        public void RestCountriesUriBuilder_WithRegionNameAndFilterByDetails_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.WithRegionName("TestRegion").FilterByModel(typeof(RegionDetails)).BuildUri();

            result
                .ToString()
                .Should()
                .Be("https://restcountries.eu/rest/v2/region/TestRegion?fields=name;population;languages;currencies;countries;regions;subregions", "This is the URL currently in use");
        }

        [Test]
        public void RestCountriesUriBuilder_WithSubRegionName_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.WithSubRegionName("TestSubRegion").BuildUri();

            result.ToString().Should().Be("https://restcountries.eu/rest/v2/subregion/TestSubRegion", "This is the URL currently in use");
        }

        [Test]
        public void RestCountriesUriBuilder_WithSubRegionNameAndFilterByCountry_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.WithSubRegionName("TestSubRegion").FilterByModel(typeof(Country)).BuildUri();

            result.ToString().Should().Be("https://restcountries.eu/rest/v2/subregion/TestSubRegion?fields=name;region;subregion", "This is the URL currently in use");
        }

        [Test]
        public void RestCountriesUriBuilder_WithSubRegionNameAndFilterByDetails_ValidUri()
        {
            var builder = GetUriBuilder();

            var result = builder.WithSubRegionName("TestSubRegion").FilterByModel(typeof(RegionDetails)).BuildUri();

            result
                .ToString()
                .Should()
                .Be("https://restcountries.eu/rest/v2/subregion/TestSubRegion?fields=name;population;languages;currencies;countries;regions;subregions", "This is the URL currently in use");
        }
    }
}