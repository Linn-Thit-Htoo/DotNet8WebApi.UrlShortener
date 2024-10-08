﻿using DotNet8WebApi.UrlShortener.Models;
using DotNet8WebApi.UrlShortener.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
