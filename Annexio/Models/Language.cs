using Newtonsoft.Json;

namespace Annexio.Models
{
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