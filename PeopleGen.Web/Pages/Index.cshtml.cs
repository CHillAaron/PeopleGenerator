using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PeopleGen.Core;
using PeopleGen.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleGen.Web.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CityViewModel Input { get; set; }
        public int PageSize { get;  set; }

        private readonly ILogger<IndexModel> _logger;
        private CityServices _cityServices;
        public List<Civilization> Cities = new List<Civilization>();
        public int Population;

        public PagingData PagingData { get;  set; }

        public List<Person> listOfPeople = new List<Person>();

        public IndexModel(ILogger<IndexModel> logger, CityServices cityServices)
        {
            _logger = logger;
            this._cityServices = cityServices;
            

        }

        public void OnGet(int PageNum = 1)
        {
            Cities = this._cityServices.GetAllCities();
            listOfPeople = this._cityServices.GetAllPeople();
            //StringBuilder QParam = new StringBuilder();
            //if (PageNum != 0)
            //{
            //    QParam.Append($"/Index?PageNum=-");

            //}
            //if (listOfPeople.Count > 0)
            //{
            //    PagingData = new PagingData
            //    {
            //        CurrentPage = PageNum,
            //        RecordsPerPage = PageSize,
            //        TotalRecords = listOfPeople.Count,
            //        UrlParams = QParam.ToString(),
            //        LinksPerPage = 7
            //    };
            //    listOfPeople = listOfPeople.Skip((PageNum - 1) * PageSize)
            //   .Take(PageSize).ToList();
        //}
        
        }
        public IActionResult OnPost(string populationSize)
        {

            this._cityServices.CreateCity(populationSize);
            return RedirectToPage("/index");


        }
    }
}
