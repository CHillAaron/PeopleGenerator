using PeopleGen.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleGen.Dal
{
    public class InventoryService 
    {
        private PeopleDbContext _context { get; }
        public InventoryService(PeopleDbContext context)
        {
            this._context = context;
        }
        public List<Inventory> GetAllItems()
        {
            return this._context.Inventory.ToList();
        }
        public Inventory GetAllItems(int id)
        {
            return this._context.Inventory.Where(item => item.InventoryId == id).FirstOrDefault();
        }
        public void AddItem(Inventory newItem)
        {

            this._context.Inventory.Add(newItem);
            this._context.SaveChanges();
        }
        //public Inventory CreateItem()
        //{
        //    Person businessOwner = GetBusinessOwner(population);
        //    string businessType = GetBusinessType(size);
        //    int cityId = (int)businessOwner.CityId;
        //    //List<Inventory> inventory;
        //    Business newBusiness = new Business()
        //    {
        //        BusinessName = $"{businessOwner.FirstName} {businessType}",
        //        BusinessType = businessType,
        //        BusinessOwner = businessOwner,
        //        CityId = (int)businessOwner.CityId,
        //        //Inventory = inventory

        //    };
        //    return newBusiness;
        //}
    }
}
