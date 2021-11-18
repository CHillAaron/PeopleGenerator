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
    public class SpeciesDetailsModel : PageModel
    {
        public SpecificSpecies SpecificSpeciesModel { get; set; }
        private APIService _apiService;

        public SpeciesDetailsModel(APIService apiService)
        {
            _apiService = apiService;
        }
        public void OnGet(string race)
        {
            SpecificSpeciesModel = _apiService.GetSpecies(race);
        }
    }
}
