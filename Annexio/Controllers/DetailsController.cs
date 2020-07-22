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

        // GET: Country BasicDetails
        public async Task<ViewResult> CountryDetails(string countryName)
        {
            var country = await _mediator.GetCountryDetails(countryName);
            country.Name = countryName;

            return View(country);
        }

        // GET: Country BasicDetails
        public async Task<ViewResult> BasicDetails(string regionName)
        {
            var region = await _mediator.GetRegionDetails(regionName);
            region.Name = regionName;

            return View(region);
        }

        // GET: Country BasicDetails
        public async Task<ViewResult> BasicDetails(string subRegionName)
        {
            var subRegion = await _mediator.GetSubRegionDetails(subRegionName);
            subRegion.Name = subRegionName;

            return View(subRegion);
        }
    }
}