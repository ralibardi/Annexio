using System.Collections.Generic;
using System.Web.Mvc;
using Annexio.Models;

namespace Annexio.Controllers
{
    public class CountriesController : Controller
    {
        // GET: Countries
        public ActionResult Index()
        {
            var countries = new List<Country>
            {
                new Country
                {
                    Name = "Venezuela",
                    Region = "America",
                    SubRegion = "Latin America"
                }
            };

            return View(countries);
        }
    }
}