namespace DotNet8WebApi.UrlShortener.Services;

public class UrlShortenerService : IUrlShortenerService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public UrlShortenerService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<string> GetLongUrl(string code, CancellationToken cs)
    {
        try
        {
            var item = await _context.TblUrls.FirstOrDefaultAsync(x => x.Code == code, cancellationToken: cs);
            ArgumentNullException.ThrowIfNull(item);

            return item.LongUrl;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<string> ShortenUrl(UrlRequestDTO urlRequest, CancellationToken cs)
    {
        try
        {
            var code = Ulid.NewUlid().ToString();
            string shortUrl = $"{_configuration.GetSection("Url").Value!}/{code}";

            var url = new TblUrl()
            {
                Id = Ulid.NewUlid().ToString(),
                Code = code,
                CreatedDate = DateTime.Now,
                LongUrl = urlRequest.LongUrl,
                ShortUrl = shortUrl
            };
            await _context.TblUrls.AddAsync(url, cs);
            await _context.SaveChangesAsync(cs);

            return url.ShortUrl;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
