namespace CatNames.Tests
{
    class StubRequester : IRequester
    {
        public string Request(string uri)
        {
            this.Requestedstring = uri;
            return null;
        }

        public string Requestedstring { get; private set; }
    }
}