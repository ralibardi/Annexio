using System.Collections.Generic;

namespace Annexio.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public string Capital { get; set; }
        public long Population { get; set; }
    }
}