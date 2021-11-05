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
    public class PersonDetailModel : PageModel
    {
        public Person PeopleModel { get; set; }
        private PeopleService _peopleService;
        public Species SpeciesInfo { get; private set; }
        
        public PersonDetailModel(PeopleService peopleService)
        {
            this._peopleService = peopleService;
        }

        public void OnGet(int id)
        {
            this.PeopleModel = this._peopleService.GetPersonById(id);
            this.SpeciesInfo = this._peopleService.GetSpeciesById(PeopleModel.SpeciesId);
        }
    }
}
