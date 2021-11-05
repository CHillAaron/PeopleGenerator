using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PeopleGen.Core;
using PeopleGen.Dal;

namespace PeopleGen.Web.Pages
{
    public class PeopleModel : PageModel
    {
        [BindProperty]
        public PersonViewModel Input { get; set; }
        private PeopleService _peopleService;
        public List<Person> AllPeople;
        public List<Species> AllSpecies;
        public IEnumerable<SelectListItem> Races { get; set; }
        public int SelectedValue1 { get; set; }
            
       
        public PeopleModel(PeopleService peopleService)
        {
            this._peopleService = peopleService;
        }
        public void OnGet()
        {
            Input = new PersonViewModel();
            this.AllPeople = this._peopleService.GetAllPeople();
            this.AllSpecies = this._peopleService.GetAllSpecies();
            Races = new SelectList(this.AllSpecies, nameof(Species.SpeciesId), nameof(Species.SpeciesName));
        }
        public IActionResult OnPost(int numToCreate)
        {
            
            this._peopleService.CreateAmount(numToCreate);
            return RedirectToPage("/People");
        }
        public void OnDelete()
        {

        }
        public void OnPut()
        {

        }
    }
}
