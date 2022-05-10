using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Pokemon.Api.Controllers
{
    [Route("pokemons")]
    public class PokemonController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PokemonController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]   
        [Route("{nome}")]
        public async Task<IActionResult> Consultar([FromRoute] string nome)
        {
            //var httpClient = _httpClientFactory.CreateClient("PokemonApiClient");

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");

            var httpResponse = await httpClient.GetAsync($"pokemon/{nome}");

            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            if (!httpResponse.IsSuccessStatusCode || string.IsNullOrWhiteSpace(responseContent))
                return NotFound();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var pokemon = JsonSerializer.Deserialize<Pokemon>(responseContent, options);

            return Ok(pokemon);
        }
    }
}
