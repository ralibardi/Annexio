using System.Collections.Generic;
using Newtonsoft.Json;

namespace Annexio.Models
{
    public class BasicDetails : Country
    {
        public string Capital { get; set; }
        public long Population { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }
        public IEnumerable<string> Borders { get; set; }
    }
}