using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PeopleGen.Core;
using System.Text.Json;
using PeopleGen.Dal.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PeopleGen.Dal
{
    public class APIService : ISpeciesAPI
    {
        private HttpClient _httpClient;
        public APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public SpecificSpecies GetSpecies(string race)
        {
            string APIURL = $"https://www.dnd5eapi.co/api/races/{race}";
            var res =  _httpClient.GetAsync(APIURL).Result;
            var json =  res.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SpecificSpecies>(json);
        }
        //with Async
        public  List<SpecificSpecies> GetALLSpecies()
        {
            string APIURL = $"https://www.dnd5eapi.co/api/races";
            var res =  _httpClient.GetAsync(APIURL).Result;
            var json = res.Content.ReadAsStringAsync().Result;
            var species = JObject.Parse(json)["results"].ToObject<List<SpecificSpecies>>();
            //var des = JsonConvert.DeserializeObject(json, typeof(APISpecies));
            return species;
            //return JsonConvert.DeserializeObject<List<SpecificSpecies>>(json);
        }
    }
}
