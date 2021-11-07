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
        PeopleDbContext serviceDbContext = new PeopleDbContext();
        Random random = new Random();

        public CityServices(PeopleDbContext context)
        {
            this._context = context;
        }
        public List<Civilization> GetAllCities()
        {
            return this._context.Civilization.ToList();
        }
        public Civilization GetCityById(int id)
            {
                return this._context.Civilization.Where(city => city.CityId == id).FirstOrDefault();
            }
        public void AddCity(Civilization newCity)
        {
            serviceDbContext.Civilization.Add(newCity);
            serviceDbContext.SaveChanges();
        }
        //---------- Methods for selecting people -------------------
        public List<Person> GetAllPeople()
        {
            return this._context.Persons.ToList() ;
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
            Civilization newCity = new Civilization()
            {
                TypeOfRule = TypeOfRule,
                Location = location,
                Population = allPopulation,
                CityName = location + " " + population
            };
            AddCity(newCity);
        }
        public int PopulationSize(string size)
        {
                int population;

            switch (size)
            {
                case ("tiny"):
                    return population = random.Next(43, 52);
                case ("small"):
                    return population = random.Next(250, 325);
                case ("medium"):
                    return population = random.Next(900, 1052);
                case ("large"):
                    return population = random.Next(4787, 5245);
                case ("xLarge"):
                    return population = random.Next(19678, 22341);
            }
            return population = 0;
        }
        public List<Person> AddPopulation(int populationAmount)
        {
            int i = 0;
            List<Person> allPeople = GetAllPeople();
            List<Person> populationOfCity = new List<Person>();
            while (i < populationAmount)
            {
                //go to database grab a random person
                int selectedPersonid = random.Next(1, allPeople.Count);
                Person selectedPerson = GetPersonById(selectedPersonid);
                //add the person to the city list
                populationOfCity.Add(selectedPerson);
                //add a relationship to the person to the city
                i++;
            }
            return populationOfCity;
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
