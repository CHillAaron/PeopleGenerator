using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public PagingData PagingData { get; private set; }
        public int PageSize { get; private set; }

        private CityServices _cityServices;
        public List<Civilization> Cities = new List<Civilization>();

        private List<Person>Population = new List<Person>();

        public CityDetailModel(CityServices cityservices)
        {
            this._cityServices = cityservices;
        }
        public void OnGet(int id, int PageNum = 1)
        {
            this.CityModel = this._cityServices.GetCityById(id);
            Cities = this._cityServices.GetAllCities();
            //Page Pagnitation
            StringBuilder QParam = new StringBuilder();
            if (PageNum != 0)
            {
                QParam.Append($"/Index?PageNum=-");

            }
            if (Population.Count > 0)
            {
                PagingData = new PagingData
                {
                    CurrentPage = PageNum,
                    RecordsPerPage = PageSize,
                    TotalRecords = Population.Count(),
                    UrlParams = QParam.ToString(),
                    LinksPerPage = 7
                };
                Population = Population.Skip((PageNum - 1) * PageSize)
               .Take(PageSize).ToList();

            }
        }
    }
}
