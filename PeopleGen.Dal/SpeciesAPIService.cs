using PeopleGen.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PeopleGen.Dal
{

    public class SpeciesAPIService : ISpeciesAPI
    {
        private HttpClient _httpClient;
        public SpeciesAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> get(string race)
        {
            string APIURL = $"races/{race}";
            var res = await _httpClient.GetAsync(APIURL);
            return await res.Content.ReadAsStringAsync();
        }
    }
}
