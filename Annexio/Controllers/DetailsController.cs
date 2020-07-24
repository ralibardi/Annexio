using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Annexio.Mediators;

namespace Annexio.Controllers
{
    public class DetailsController : Controller
    {
        private readonly ICountriesMediator _mediator;

        public DetailsController(ICountriesMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: Country CountryDetailsByName
        public async Task<ViewResult> CountryDetailsByName(string countryName)
        {
            var country = await _mediator.GetCountryDetailsByName(countryName);

            return View(country);
        }

        // GET: Country CountryDetailsByName
        public async Task<ViewResult> CountryDetailsByCode(string countryCode)
        {
            var country = await _mediator.GetCountryDetailsByCode(countryCode);

            return View(country);
        }

        // GET: Country CountryDetailsByName
        public async Task<ViewResult> RegionDetails(string regionName)
        {
            var region = await _mediator.GetRegionDetails(regionName);
            region.Name = regionName;

            return View(region);
        }

        // GET: Country CountryDetailsByName
        public async Task<ViewResult> SubRegionDetails(string subRegionName)
        {
            var subRegion = await _mediator.GetSubRegionDetails(subRegionName);
            subRegion.Name = subRegionName;

            return View(subRegion);
        }
    }
}