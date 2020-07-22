using System.Collections.Generic;

namespace Annexio.Models
{
    public class BasicDetails : Country
    {
        public long Population { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }
        public bool IsCountry { get; set; }
    }

    public class CountryDetails : BasicDetails
    {
        public string Capital { get; set; }
        public IEnumerable<string> Borders { get; set; }
    }
}