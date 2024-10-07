using DotNet8WebApi.UrlShortener.Models;

namespace DotNet8WebApi.UrlShortener.Services;

public class UrlShortenerService : IUrlShortenerService
{
    private readonly AppDbContext _context;

    public UrlShortenerService(AppDbContext context)
    {
        _context = context;
    }

    public Task<string> ShortenUrl(UrlRequestDTO urlRequest, CancellationToken cs)
    {
        throw new NotImplementedException();
    }
}
