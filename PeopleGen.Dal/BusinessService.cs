using PeopleGen.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PeopleGen.Dal
{
    public class BusinessService
    {
        private PeopleDbContext _context { get; }
        //PeopleDbContext serviceDbContext = new PeopleDbContext();
        Random random = new Random();

        public BusinessService(PeopleDbContext context)
        {
            this._context = context;
        }
        //Inventory Methods
        public void GetAllInventory()
        {

        }
        public void AddBusiness(Business newBusiness)
        {
            this._context.Add(newBusiness);
            this._context.SaveChanges();
        }
        public void CreateBusiness()
        {
            string businessName;
            string businessType;
            Person businessOwner;
            Civilization cityId;
            List<Inventory> inventory;
            //Business newBusiness = new Business()
            //{
            //    BusinessName = businessName,
            //    BusinessType = businessType,
            //    BusinessOwner = businessOwner,
            //    CityId = cityId,
            //    Inventory = inventory

            //}
        }
    }
}
