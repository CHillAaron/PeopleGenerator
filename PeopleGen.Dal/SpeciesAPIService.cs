using PeopleGen.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PeopleGen.Core;
using System.Text.Json;

namespace PeopleGen.Dal
{

    public class SpeciesAPIService : ISpeciesAPI
    {
        private HttpClient _httpClient;
        public SpeciesAPIService(HttpClient httpClient, IHttpClientFactory clientFactory)
        {
            _httpClient = httpClient;
            _httpClient = clientFactory.CreateClient("SpeciesAPICall");
        }

        //public async Task<List<APISpecies>> get(string race)
        //{
        //    string APIURL = $"races/{race}";
        //    var res = await _httpClient.GetAsync(APIURL);
        //    return await res.Content.ReadAsStringAsync();
        //}
        public async Task<List<APISpecies>> get(string race)
        {
            string APIURL = $"races/{race}";
            var result = new List<APISpecies>();
            var response = await _httpClient.GetAsync(APIURL);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<APISpecies>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
