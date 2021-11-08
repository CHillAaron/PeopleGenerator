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
    public class BusinessDetailModel : PageModel
    {
        public Business BusinessModel { get; set; }
        private BusinessService _businessService;
        public BusinessDetailModel(BusinessService businessService)
        {
            this._businessService = businessService;
        }
        public void OnGet(int id)
        {
            this.BusinessModel = this._businessService.GetBusinessById(id);
        }
    }
}
