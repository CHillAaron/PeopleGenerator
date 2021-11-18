using PeopleGen.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleGen.Dal
{
    public class PeopleService
    {
        private PeopleDbContext _context { get;}
        private APIService _speciesService;
        Random random = new Random();
        public PeopleService(PeopleDbContext context, APIService speciesService)
        {
            this._context = context;
            this._speciesService = speciesService;
        }
        public List<Person> GetAllPeople()
        {
            return this._context.Persons.ToList();
        }
        public Person GetPersonByName(string name)
        {
            return  this._context.Persons.Where(person => person.FirstName == name).FirstOrDefault();
        }
        public Person GetPersonById(int id)
            {
                return this._context.Persons.Where(person => person.PersonId == id).FirstOrDefault();
            }
        public void AddPerson(Person newPerson)
        {
            _context.Persons.Add(newPerson);
            _context.SaveChanges();
        }
        //public List<Species> GetAllSpecies()
        //{
        //    return this._context.Species.ToList();
        //}

        public async void CreateAmount(int amountToCreate)
        {
            int i = 0;
            while(i < amountToCreate)
            {

                CreatePerson();
                i++;
            }
        }
        public async void CreatePerson()
        {

            
            //get Gender
            string gender = GetGender();
            //get Name
            string firstName = GetFirstName(gender);
            string lastName = GetLastName();
            //Get Age
            int age = GetAge();
            //Get Stats
            int Strength = GetAttributes();
            int Dexterity = GetAttributes();
            int Constitution = GetAttributes();
            int Intelligence = GetAttributes();
            int Wisdom = GetAttributes();
            int Charisma = GetAttributes();
            //Get Alignment
            string alignment = GetAlignment();
            //Get Personality
            string personality = GetPersonality();
            //Gets the strengths
            //string personalityStrength = GetPersonalityStrength();
            //Get Species
            SpecificSpecies selectedSpecies = GetSpecies();
            Person newPerson = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                Age = age,
                Strength = Strength,
                Dexterity = Dexterity,
                Constitution = Constitution,
                Intelligence = Intelligence,
                Wisdom = Wisdom,
                Charisma = Charisma,
                Alignment = alignment,
                //PersonalityStrength = personalityStrength,
                SpeciesName = selectedSpecies.Name,
            };
            AddPerson( newPerson);

        }
        //public Species GetSpecies()
        //{
        //    List<Species> allSpecies = GetAllSpecies();
        //    int index = random.Next(allSpecies.Count);
        //    Species selectedSpecies = allSpecies[index];
        //    return selectedSpecies;
        //}
        public SpecificSpecies GetSpecies()
        {
            List<SpecificSpecies> allSpecies =  _speciesService.GetALLSpecies();
            int index = random.Next(allSpecies.Count);
            SpecificSpecies selectedSpecies = allSpecies[index];
            return selectedSpecies;
        }
        public string  GetGender()
        {
            string gender = "male";
            int genderChance = random.Next(1, 101);
            if (genderChance >= 40)
            {
                return gender = "female";
            }
            return gender;
        }
        public string GetFirstName(string gender)
        {
            if (gender == "female")
            {
                Array values = Enum.GetValues(typeof(Core.enums.FirstNamesFemale));
                Core.enums.FirstNamesFemale randumEnumValue = (Core.enums.FirstNamesFemale)values.GetValue(random.Next(values.Length));
                return randumEnumValue.ToString();
            }
            else
            {
                Array values = Enum.GetValues(typeof(Core.enums.FirstNamesMale));
                Core.enums.FirstNamesMale randumEnumValue = (Core.enums.FirstNamesMale)values.GetValue(random.Next(values.Length));
                return randumEnumValue.ToString();
            }

        }
        public string GetLastName()
        {
                Array values = Enum.GetValues(typeof(Core.enums.LastNames));
                Core.enums.LastNames randumEnumValue = (Core.enums.LastNames)values.GetValue(random.Next(values.Length));
                return randumEnumValue.ToString();
        }
        public int GetAge()
        {
            int age = random.Next(1, 101);
            return age;
        }
        public int GetAttributes()
        {
            int statScore = random.Next(6, 19);
            return statScore;
        }
        public string GetAlignment()
        {
            //Gets the moral of the character
            Array moral = Enum.GetValues(typeof(Core.enums.Moral));
            Core.enums.Moral getMoral = (Core.enums.Moral)moral.GetValue(random.Next(moral.Length));
            //Gets the Alignment of the Character
            Array alignment = Enum.GetValues(typeof(Core.enums.Alignment));
            Core.enums.Alignment getAlignment = (Core.enums.Alignment)alignment.GetValue(random.Next(alignment.Length));
            return getMoral + " " + getAlignment;
        }
        public string GetPersonality()
        {
            Array mood = Enum.GetValues(typeof(Core.enums.Personality));
            Core.enums.Personality getMood = (Core.enums.Personality)mood.GetValue(random.Next(mood.Length));
            Console.WriteLine("This is the mood: " + getMood);
            return getMood.ToString();

        }
        //public string GetPersonalityStrength()
        //{
        //    Array strength = Enum.GetValues(typeof(Core.enums.Strength));
        //    Core.enums.Strength getMood = (Core.enums.Strength)strength.GetValue(random.Next(strength.Length));
        //    return getMood.ToString();

        //}
        //public Species GetSpeciesById(int id)
        //{

        //    return this._context.Species.Where(species => species.SpeciesId == id).FirstOrDefault();
        //}
        public Civilization GetCivilizationById(int id)
        {
            return this._context.Civilization.Where(civilization => civilization.CityId == id).FirstOrDefault();
        }
    }
}
