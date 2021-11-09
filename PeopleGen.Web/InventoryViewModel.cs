using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleGen.Web
{
    public class InventoryViewModel
    {
        [Required]
        public string InventoryName { get; set; }
        [Required]
        public string InventoryType { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string MoneyType { get; set; }
        public Boolean IsMagical { get; set; }
        public Boolean IsCursed { get; set; }
    }
}
