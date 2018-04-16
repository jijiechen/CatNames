using System.Collections.Generic;
using System.Linq;

namespace CatNames
{
    public class PeopleService
    {
        private readonly JsonFetcher _jsonFetcher;

        public PeopleService(JsonFetcher jsonFetcher)
        {
            _jsonFetcher = jsonFetcher;
        }

        public List<Person> GetPeople()
        {
            return _jsonFetcher.Fetch<List<Person>>("https://agl-developer-test.azurewebsites.net/people.json");
        }

        public List<Pet> ListPets(List<Person> people)
        {
            return people
                .SelectMany(person => person.pets)
                .OrderBy(pet => pet.name)
                .ToList();
        }
    }
}