namespace CatNames.Providers
{
    public interface IRequester
    {
        string Request(string uri);
    }
}