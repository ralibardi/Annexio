using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Annexio.Clients;
using Annexio.Models;

namespace Annexio.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountriesHttpClient _client;

        public CountriesController(ICountriesHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        // GET: Countries
        public async Task<ViewResult> IndexAsync(int id)
        {
            var countries = await _client.GetCountriesSubsetAsync(id, 10);

            return View(countries ?? new List<Country>());
        }
    }
}