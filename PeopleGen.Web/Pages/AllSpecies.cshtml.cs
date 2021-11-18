using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleGen.Core;
using PeopleGen.Dal;

namespace PeopleGen.Web.Pages
{
    public class AllSpeciesModel : PageModel
    {
        public APISpecies apiSpeciesModel { get; set; }
        private APIService _apiService;
        public List<SpecificSpecies> listOfApiSpecies = new List<SpecificSpecies>();
        public List<SpecificSpecies> allSpecies { get; set; }

        public AllSpeciesModel(APIService apiService)
        {
            _apiService = apiService;
        }
        public async Task OnGet()
        {
            //listOfApiSpecies = await _speciesService.GetALLSpecies();

            listOfApiSpecies = _apiService.GetALLSpecies();
            var allSpecies = listOfApiSpecies.Select(x => _apiService.GetSpecies(x.Name));
        }
    }
}
