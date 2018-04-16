using System.Net;

namespace CatNames.Providers
{
    class WebRequester : IRequester
    {
        public string Request(string uri)
        {
            return new WebClient().DownloadString(uri);
        }
    }
}