using DotNet8WebApi.UrlShortener.Models;

namespace DotNet8WebApi.UrlShortener.Services
{
    public interface IUrlShortenerService
    {
        Task<string> ShortenUrl(UrlRequestDTO urlRequest, CancellationToken cs);
    }
}
