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
        private SpeciesAPIService _speciesService;
        List<APISpecies> listOfApiSpecies = new List<APISpecies>();

        public AllSpeciesModel(SpeciesAPIService speciesService)
        {
            _speciesService = speciesService;
        }
        public void OnGet()
        {

            //apiSpeciesModel = _speciesService.GetApiSpecies("dragonborn");
        }
        //public async Task<IActionResult> OnGet(string race)
        //{
        //    List<APISpecies> listOfApiSpecies = new List<APISpecies>();
        //    listOfApiSpecies = await _speciesService.GetApiSpecies(race);
        //    return RedirectToPage("AllSpecies");
        //}
    }
}
