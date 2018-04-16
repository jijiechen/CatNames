using Xunit;

namespace CatNames.Tests
{
    public class WebResourceFacts
    {
        [Fact]
        public void ShouldRequestJsonData()
        {
            var requester = new StubRequester();
            var jsonFetcher = new JsonFetcher(requester);
            
            jsonFetcher.Fetch<object>("url://dummy");
            Assert.Equal("url://dummy", requester.Requestedstring);
        }
    }
}
