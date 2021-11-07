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

    public class CreateCityModel : PageModel
    {
        [BindProperty]
        public CityViewModel Input { get; set; }
        private CityServices _cityService;
        public int Population;
        public List<Person> listOfPeople = new List<Person>();

        public CreateCityModel(CityServices cityServices)
        {
            this._cityService = cityServices;
        }
        public void OnGet()
        {
            Input = new CityViewModel();
            List<Person> listOfPeople = _cityService.GetAllPeople();
        }
        public IActionResult OnPost(string populationSize)
        {
            
            this._cityService.CreateCity(populationSize);
            return RedirectToPage("/CreateCity");

            //Console.WriteLine("**********************************");
            //foreach(var p in listOfPeople)
            //{
            //    Console.WriteLine("This is the persons name " + p.FirstName);
            //}
            //Console.WriteLine("**********************************");
        }
    }
}
