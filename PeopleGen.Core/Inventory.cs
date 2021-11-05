using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleGen.Core
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        [Required]
        public string InventoryName { get; set; }
        [Required]
        public string InventoryType { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string moneyType { get; set; }
        public Boolean IsMagical { get; set; }
        public Boolean IsCursed { get; set; }

        public List<Business> business { get; set; } = new List<Business>();
    }
}
