using System.Collections.Generic;
using System.Threading.Tasks;
using Annexio.Models;

namespace Annexio.Clients
{
    public interface ICountriesHttpClient
    {
        Task<List<Country>> GetAllCountriesAsync();

        Task<IEnumerable<Country>> GetCountriesSubsetAsync(int index, int length);
    }
}