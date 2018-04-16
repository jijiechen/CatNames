using System.Collections.Generic;

namespace CatNames
{
    public class PeopleService
    {
        private readonly JsonFetcher _jsonFetcher;

        public PeopleService(JsonFetcher jsonFetcher)
        {
            _jsonFetcher = jsonFetcher;
        }

        public List<People> GetPeople()
        {
            return _jsonFetcher.Fetch<List<People>>("https://agl-developer-test.azurewebsites.net/people.json");
        }
    }
}