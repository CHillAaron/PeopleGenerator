using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PeopleGen.Core;
using System.Text.Json;
using PeopleGen.Dal.Interfaces;

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
            string APIURL = $"https://www.dnd5eapi.co/api/races/{race}";
            var res = await _httpClient.GetAsync(APIURL);
            return await res.Content.ReadAsStringAsync();
        }
    }
}
