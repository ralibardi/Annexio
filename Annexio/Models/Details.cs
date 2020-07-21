using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Annexio.Models
{
    public class Details
    {
        public string Id { get; set; }
        public string Capital { get; set; }
        public long Population { get; set; }
        public Collection<Language> Languages { get; set; }
        public Collection<Currency> Currencies { get; set; }
        public Collection<string> Borders { get; set; }
    }

    public class Currency
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
    }

    public class Language
    {
        public string Name { get; set; }
        public string NativeName { get; set; }
        [JsonProperty("iso639_1")]
        public string Iso6391 { get; set; }
        [JsonProperty("iso639_2")]
        public string Iso6392 { get; set; }
    }
}