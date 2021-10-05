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
    public class PeopleModel : PageModel
    {
        [BindProperty]
        public PersonViewModel input { get; set; }
        private PeopleService _peopleService;
        public List<Person> AllPeople;
        public PeopleModel(PeopleService peopleService)
        {
            this._peopleService = peopleService;
        }
        public void OnGet()
        {
            this.AllPeople = this._peopleService.GetAllPeople();
        }
        public void OnPost()
        {

        }
    }
}
