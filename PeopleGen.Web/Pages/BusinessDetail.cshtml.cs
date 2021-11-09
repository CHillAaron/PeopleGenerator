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
        private InventoryService _inventoryService;
        public BusinessDetailModel(BusinessService businessService, InventoryService inventoryService)
        {
            this._businessService = businessService;
            this._inventoryService = inventoryService;
        }
        public void OnGet(int id)
        {
            this.BusinessModel = this._businessService.GetBusinessById(id);
            this.BusinessModel.Inventory = _inventoryService.GetAllItems();
        }
    }
}
