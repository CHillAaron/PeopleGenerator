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
    public class CityDetailModel : PageModel
    {
        public Civilization CityModel { get; set; }
        private CityServices _cityServices;
        public CityDetailModel(CityServices cityservices)
        {
            this._cityServices = cityservices;
        }
        public void OnGet(int id)
        {
            this.CityModel = this._cityServices.GetCityById(id);
        }
    }
}
