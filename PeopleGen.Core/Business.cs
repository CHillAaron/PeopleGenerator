using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleGen.Core
{
    public class Business
    {
        [Key]
        public int BusinessId { get; set; }
        [Required]
        public string BusinessName { get; set; }
        [Required]
        public string BusinessType { get; set; }
        [Required]
        public Person BusinessOwner { get; set; }
        [Required]
        public int NumOfEmployees { get; set; }
        [Required]
        public int CityId { get; set; }
        public Civilization Civilization { get; set; }
        [NotMapped]
        public List<Inventory> Inventory { get; set; } = new List<Inventory>();
    }
}
