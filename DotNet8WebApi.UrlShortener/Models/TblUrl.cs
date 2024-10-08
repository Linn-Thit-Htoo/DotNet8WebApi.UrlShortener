namespace DotNet8WebApi.UrlShortener.Models;

public partial class TblUrl
{
    public string Id { get; set; } = null!;

    public string LongUrl { get; set; } = null!;

    public string ShortUrl { get; set; } = null!;

    public string Code { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
