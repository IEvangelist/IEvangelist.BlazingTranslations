using IEvangelist.BlazingTranslations.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IEvangelist.BlazingTranslations.Server.Controllers
{
    [
        ApiController,
        Route("api/cultures")
    ]
    public class CulturesController : ControllerBase
    {
        readonly IHttpClientFactory _httpClientFactory;
        readonly IMemoryCache _cache;

        public CulturesController(
            IHttpClientFactory httpClientFactory,
            IMemoryCache cache) =>
            (_httpClientFactory, _cache) = (httpClientFactory, cache);

        [HttpGet, Produces("application/json")]
        public Task<AzureCultures> Get() =>
            _cache.GetOrCreateAsync(nameof(CulturesController), async _ =>
            {
                using var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri("https://api.cognitive.microsofttranslator.com");

                var cultutes = await client.GetFromJsonAsync<AzureCultures>(
                    "languages?api-version=3.0&scope=translation",
                    DefaultOptions.SerializerOptions);

                return cultutes;
            });
    }
}
