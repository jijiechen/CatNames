using CatNames.Providers;

namespace CatNames.Tests
{
    class StubRequester : IRequester
    {
        private readonly string _response;

        public StubRequester(string response)
        {
            _response = response;
        }

        public string Request(string uri)
        {
            this.Requestedstring = uri;
            return _response;
        }

        public string Requestedstring { get; private set; }
    }
}