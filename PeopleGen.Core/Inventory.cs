using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
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
        public string MoneyType { get; set; }
        public Boolean IsMagical { get; set; }
        public Boolean IsCursed { get; set; }

        public List<Business> business { get; set; } = new List<Business>();


    }


    //public class Inventory
    //{
    //    public string name { get; set; }
    //    public string category { get; set; }
    //    public string cost { get; set; }
    //    public string damage_dice { get; set; }
    //    public string damage_type { get; set; }
    //    public string weight { get; set; }
    //    public string[] properties { get; set; }
    //}
}