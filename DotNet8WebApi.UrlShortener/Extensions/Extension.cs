using DotNet8WebApi.UrlShortener.Models;

namespace DotNet8WebApi.UrlShortener.Extensions
{
    public static class Extension
    {
        public static TblUrl ToEntity(UrlRequestDTO urlRequest, string code, string shortUrl)
        {
            return new TblUrl
            {
                Id = Ulid.NewUlid().ToString(),
                Code = code,
                CreatedDate = DateTime.Now,
                LongUrl = urlRequest.LongUrl,
                ShortUrl = shortUrl
            };
        }
    }
}
