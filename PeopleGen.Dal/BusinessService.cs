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
        public Business GetBusinessById(int id)
        {
            return this._context.Business.Where(business => business.BusinessId == id)
                                                 .FirstOrDefault();
        }
        public void AddBusiness(Business newBusiness)
        {
            this._context.Add(newBusiness);
            this._context.SaveChanges();
        }
        public Business CreateBusiness(List<Person> population,  string size)
        {
            Person businessOwner = GetBusinessOwner(population);
            string businessType = GetBusinessType(size);
            int cityId = (int)businessOwner.CityId;
            //List<Inventory> inventory;
            Business newBusiness = new Business()
            {
                BusinessName = $"{businessOwner.FirstName} {businessType}",
                BusinessType = businessType,
                BusinessOwner = businessOwner,
                CityId = (int)businessOwner.CityId,
                //Inventory = inventory

            };
            return newBusiness;
        }
        public Person GetBusinessOwner(List<Person> population)
        {
            Dictionary<int, Person> people = population.ToDictionary(x => x.PersonId);
            int populationIndex = random.Next(0, people.Count);
            Person selectedPerson = people.ElementAt(populationIndex).Value;
            return selectedPerson;
        }
        public string GetBusinessType(string size)
        {
            switch (size)
            {
                case ("tiny"):
                    return GetCommonBusinesstype();
                case ("small"):
                    return GetCommonBusinesstype();
                case ("medium"):
                    return GetCommonBusinesstype();
                case ("large"):
                    return GetCommonBusinesstype();
                case ("xLarge"):
                    return GetCommonBusinesstype();
            };
            return "invalid entry";
                
        }
        public string GetCommonBusinesstype()
        {
            Array typeOfBusiness = Enum.GetValues(typeof(Core.enums.CommonBusinessType));
            Core.enums.CommonBusinessType getTypeOfBusiness = (Core.enums.CommonBusinessType)typeOfBusiness.GetValue(random.Next(typeOfBusiness.Length));
            return getTypeOfBusiness.ToString();
        }
        public string GetSpecificBusinesstype()
        {
            Array typeOfBusiness = Enum.GetValues(typeof(Core.enums.SpecificBusinessType));
            Core.enums.SpecificBusinessType getTypeOfBusiness = (Core.enums.SpecificBusinessType)typeOfBusiness.GetValue(random.Next(typeOfBusiness.Length));
            return getTypeOfBusiness.ToString();
        }
    }
}
