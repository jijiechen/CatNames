using Xunit;

namespace CatNames.Tests
{
    public class PeopleServiceFacts
    {
        [Fact]
        public void ShouldRequestUrlToFetchData()
        {
            var requester = new StubRequester("[]");
            var peopleService = new PeopleService(new JsonFetcher(requester));

            peopleService.GetPeople();
            
            Assert.Equal("https://agl-developer-test.azurewebsites.net/people.json", requester.Requestedstring);
        }
        
        
        [Fact]
        public void ShouldGetPeopleData()
        {
            var requester = new StubRequester("[{\"name\":\"Kate\",\"gender\":\"Female\",\"age\":15,\"pets\":[{\"name\":\"Kitty\",\"type\":\"cat\"}]}]");
            var peopleService = new PeopleService(new JsonFetcher(requester));

            var people = peopleService.GetPeople();
            Assert.Equal(1, people.Count);
            Assert.Equal("Kate", people[0].name);
        }
    }
}