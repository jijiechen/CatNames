using CatNames.Providers;
using Xunit;

namespace CatNames.Tests
{
    public class JsonFetcherFacts
    {
        [Fact]
        public void ShouldRequestJsonData()
        {
            var requester = new StubRequester("{}");
            var jsonFetcher = new JsonFetcher(requester);
            
            jsonFetcher.Fetch<object>("url://dummy");
            Assert.Equal("url://dummy", requester.Requestedstring);
        }
        
        [Fact]
        public void ShouldParseJsonObject()
        {
            var requester = new StubRequester("{name: \"hello\"}");
            var jsonFetcher = new JsonFetcher(requester);
            
            var obj = jsonFetcher.Fetch<Thing>("url://dummy");
            Assert.NotNull(obj);
            Assert.Equal("hello", obj.name);
        }

        class Thing
        {
            public string name { get; set; }
        }
    }
}
