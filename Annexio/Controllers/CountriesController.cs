using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Annexio.Models;
using Newtonsoft.Json;

namespace Annexio.Controllers
{
    public class CountriesController : Controller
    {
        // GET: Countries
        public async Task<ViewResult> IndexAsync()
        {
            var countries = await GetCountries();

            return View(countries ?? new List<Country>());
        }

        private static async Task<List<Country>> GetCountries()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(new Uri("https://restcountries.eu/rest/v2/all"));
                result.EnsureSuccessStatusCode();
                var responseBody = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Country>>(responseBody);
            }
        }
    }
}