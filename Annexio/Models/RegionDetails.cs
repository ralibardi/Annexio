using System.Collections.Generic;

namespace Annexio.Models
{
    public class RegionDetails
    {
        public string Name { get; set; }
        public long Population { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }
        public IEnumerable<string> Countries { get; set; }
        public IEnumerable<string> Regions { get; set; }
        public IEnumerable<string> SubRegions { get; set; }
    }
}