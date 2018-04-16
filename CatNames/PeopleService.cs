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

        public List<PetDto> ListPets(List<Person> people)
        {
            return people
                .SelectMany(PetService.ListPetAsDtos)
                .OrderBy(pet => pet.name)
                .ToList();
        }
    }
}