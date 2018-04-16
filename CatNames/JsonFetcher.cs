namespace CatNames
{
    public class JsonFetcher
    {
        private readonly IRequester _requester;

        public JsonFetcher(IRequester requester)
        {
            _requester = requester;
        }

        public T Fetch<T>(string uri)
        {
            this._requester.Request(uri);
            return default(T);
        }
    }
}