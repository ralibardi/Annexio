using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Annexio.Mediators;
using Annexio.Models;
using PagedList;

namespace Annexio.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountriesMediator _mediator;
        private IEnumerable<Country> _countries;
        private const int MaximumPageSize = 25;

        public CountriesController(ICountriesMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ViewResult> Index(int? pageIndex)
        {
            _countries = await _mediator.GetAllCountries();

            if (pageIndex == null || pageIndex == 0)
            {
                pageIndex = 1;
            }

            return View(_countries.ToPagedList((int) pageIndex, MaximumPageSize));
        }

        public PartialViewResult CountriesTable(IPagedList<Country> pagedCountries)
        {
            return PartialView(pagedCountries);
        }
    }
}