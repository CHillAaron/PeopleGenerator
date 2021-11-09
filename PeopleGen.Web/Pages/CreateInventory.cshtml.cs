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
    public class CreateInventoryModel : PageModel
    {
        [BindProperty]
        public Inventory Input { get; set; }
        private InventoryService _inventoryService;

        public CreateInventoryModel(InventoryService inventoryService)
        {
            this._inventoryService = inventoryService;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (this.ModelState.IsValid)
            {
                _inventoryService.AddItem(Input);
                return RedirectToPage("CreateInventory");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
