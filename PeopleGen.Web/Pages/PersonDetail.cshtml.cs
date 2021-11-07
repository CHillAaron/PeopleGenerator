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
        private CityServices _cityServices;
        public Species SpeciesInfo { get; private set; }
        public Civilization cityName { get; private set; }
        
        public PersonDetailModel(PeopleService peopleService, CityServices cityServices)
        {
            this._peopleService = peopleService;
            this._cityServices = cityServices;
        }

        public void OnGet(int id)
        {
            this.PeopleModel = this._peopleService.GetPersonById(id);
            this.SpeciesInfo = this._peopleService.GetSpeciesById(PeopleModel.SpeciesId);
            if(this.PeopleModel.CityId != null)
            {
                this.cityName = this._cityServices.GetCityById((int)this.PeopleModel.CityId);
            }
            
        }
    }
}
