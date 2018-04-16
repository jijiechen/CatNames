using System.Collections.Generic;
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
        
        
        [Fact]
        public void ShouldListPetsWithPeople()
        {
            var people = new List<Person>()
            {
                new Person
                {
                    name = "Jim",
                    pets = new List<Pet>
                    {
                        new Pet {name = "Amy", type = "dog"}
                    }
                },
                new Person
                {
                    name = "Kate",
                    pets = new List<Pet>
                    {
                        new Pet {name = "Docy", type = "cat"}
                    }
                }
            };
            
            var peopleService = new PeopleService(jsonFetcher: null);

            var pets = peopleService.ListPets(people);
            Assert.Equal(2, pets.Count);
            Assert.Equal("Amy", pets[0].name);
            Assert.Equal("Docy", pets[1].name);
        }
        
        
        [Fact]
        public void ShouldListPetsInalphabeticalOrder()
        {
            var people = new List<Person>()
            {
                new Person
                {
                    name = "Jim",
                    pets = new List<Pet>
                    {
                        new Pet {name = "Lovely", type = "dog"}
                    }
                },
                new Person
                {
                    name = "Kate",
                    pets = new List<Pet>
                    {
                        new Pet {name = "Docy", type = "cat"}
                    }
                }
            };
            
            var peopleService = new PeopleService(jsonFetcher: null);

            var pets = peopleService.ListPets(people);
            Assert.Equal(2, pets.Count);
            Assert.Equal("Docy", pets[0].name);
            Assert.Equal("Lovely", pets[1].name);
        }
    }
}