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
        private SpeciesAPIService _speciesAPI;
        public string SpeciesAPI { get; private set; }

        public void OnGet()
        {
            
        }
    }
}
