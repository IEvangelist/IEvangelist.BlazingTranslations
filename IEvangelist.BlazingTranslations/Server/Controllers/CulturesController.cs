using IEvangelist.BlazingTranslations.Shared;
using Microsoft.AspNetCore.Mvc;
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

        public CulturesController(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

        [HttpGet, Produces("application/json")]
        public async Task<AzureCultures> Get()
        {
            using var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://api.cognitive.microsofttranslator.com");

            var cultutes = await client.GetFromJsonAsync<AzureCultures>(
                "languages?api-version=3.0&scope=translation",
                DefaultOptions.SerializerOptions);

            return cultutes;
        }
    }
}
