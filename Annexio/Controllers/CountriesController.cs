using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Annexio.Mediators;
using Annexio.Models;

namespace Annexio.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountriesMediator _mediator;

        public CountriesController(ICountriesMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: Countries
        public async Task<ViewResult> IndexAsync(int id)
        {
            var countries = await _mediator.GetCountriesSubSet(id, 10);

            return View(countries ?? new List<Country>());
        }
    }
}