global using DotNet8WebApi.UrlShortener.Models;
global using DotNet8WebApi.UrlShortener.Services;
global using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebApi.UrlShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlShortenerService _urlShortenerService;

        public UrlController(IUrlShortenerService urlShortenerService)
        {
            _urlShortenerService = urlShortenerService;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetLongUrl(string code, CancellationToken cs)
        {
            try
            {
                string longUrl = await _urlShortenerService.GetLongUrl(code, cs);
                return Ok(longUrl);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ShortenUrl([FromBody] UrlRequestDTO urlRequest, CancellationToken cs)
        {
            try
            {
                if (string.IsNullOrEmpty(urlRequest.LongUrl))
                {
                    return BadRequest("Long Url cannot be empty.");
                }

                string shortUrl = await _urlShortenerService.ShortenUrl(urlRequest, cs);
                return Ok(shortUrl);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
