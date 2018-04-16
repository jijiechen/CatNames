using System.Collections.Generic;
using CatNames.Models;
using CatNames.Providers;

namespace CatNames.Services
{
    public class PeopleService
    {
        private readonly JsonFetcher _jsonFetcher;

        public PeopleService(JsonFetcher jsonFetcher)
        {
            _jsonFetcher = jsonFetcher;
        }

        public List<PersonDataModel> GetPeople()
        {
            return _jsonFetcher.Fetch<List<PersonDataModel>>("https://agl-developer-test.azurewebsites.net/people.json");
        }
    }
}