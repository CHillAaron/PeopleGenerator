using Microsoft.EntityFrameworkCore;
using PeopleGen.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleGen.Dal
{
    public class CityServices
    {
        private PeopleDbContext _context { get; }
        Random random = new Random();
        private BusinessService _businessService;


        public CityServices(PeopleDbContext context, BusinessService businessService)
        {
            this._context = context;
            this._businessService = businessService;
        }
        public List<Civilization> GetAllCities()
        {
            return this._context.Civilization.ToList();
        }
        public Civilization GetCityById(int id)
            {
                return this._context.Civilization.Where(city => city.CityId == id)
                                                 .Include(city => city.Population)  
                                                 .Include(city => city.Businesses)
                                                 .FirstOrDefault();
            }
        public void AddCity(Civilization newCity)
        {

            this._context.Civilization.Add(newCity);
            this._context.SaveChanges();
        }
        //---------- Methods for selecting people -------------------
        public List<Person> GetAllPeople()
        {
            return this._context.Persons.ToList();
        }
        public Person GetPersonById(int id)
        {
            return this._context.Persons.Where(person => person.PersonId == id).FirstOrDefault();
        }
        //---------- end Methods for selecting people -------------------


        //City population Generation. 
        //
        public void CreateCity(string size)
        {
            //get population size
            int population = PopulationSize(size);
            //get people for the population
            List<Person> allPopulation = AddPopulation(population);
            //get Type of Rule
            string TypeOfRule = GetTypeOfRule();
            //Get Location
            string location = GetLocation();
            //get City Name
            string Name = $"{size} {location}";
            //get Ideology
            //Create Business
            List<Business> newBusinesses = new List<Business>();
            newBusinesses.Add( this._businessService.CreateBusiness(allPopulation, size));

            Civilization newCity = new Civilization()
            {
                TypeOfRule = TypeOfRule,
                Location = location,
                Population = allPopulation,
                CityName = location + " " + population,
                Businesses = newBusinesses
            };
            AddCity(newCity);
        }
        public int PopulationSize(string size)
        {

            switch (size)
            {
                case ("tiny"):
                    return random.Next(43, 52);
                case ("small"):
                    return random.Next(250, 325);
                case ("medium"):
                    return random.Next(900, 1052);
                case ("large"):
                    return random.Next(4787, 5245);
                case ("xLarge"):
                    return random.Next(19678, 22341);
            }
            return 0;
        }
        public List<Person> AddPopulation(int populationAmount)
        {
            List<Person> allPeople = GetAllPeople();
            Dictionary<int, Person> peopleLeft = allPeople.ToDictionary(x => x.PersonId);
            if(populationAmount > allPeople.Count)
            {
                populationAmount = allPeople.Count;
            }
            Dictionary<int, Person> currentPop = new Dictionary<int, Person>();
            while (currentPop.Count < populationAmount)
            {
                //go to database grab a random person
                int peopleLeftIndex = random.Next(0, peopleLeft.Count);
                Person selectedPerson = peopleLeft.ElementAt(peopleLeftIndex).Value;
                //Person selectedPerson = GetPersonById(selectedPersonid);
                //check the list for the person
                //add the person to the city list

                currentPop.Add(selectedPerson.PersonId, selectedPerson);
                peopleLeft.Remove(selectedPerson.PersonId);
                //add a relationship to the person to the city
            }
            return currentPop.Values.ToList();
        }
        public string GetTypeOfRule()
        {
            Array typeOfRule = Enum.GetValues(typeof(Core.enums.TypeOfRule));
            Core.enums.TypeOfRule getTypeOfRule = (Core.enums.TypeOfRule)typeOfRule.GetValue(random.Next(typeOfRule.Length));
            return getTypeOfRule.ToString();
        }
        public string GetLocation()
        {
            Array location = Enum.GetValues(typeof(Core.enums.Location));
            Core.enums.Location getLocation = (Core.enums.Location)location.GetValue(random.Next(location.Length));
            return getLocation.ToString();
        }
    }
}
