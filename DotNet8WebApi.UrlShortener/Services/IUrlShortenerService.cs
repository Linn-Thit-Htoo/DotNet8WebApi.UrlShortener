namespace DotNet8WebApi.UrlShortener.Services;

public interface IUrlShortenerService
{
    Task<string> ShortenUrl(UrlRequestDTO urlRequest, CancellationToken cs);
    Task<string> GetLongUrl(string code, CancellationToken cs);
}
