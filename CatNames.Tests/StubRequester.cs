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
            this.RequestedUri = uri;
            return _response;
        }

        public string RequestedUri { get; private set; }
    }
}