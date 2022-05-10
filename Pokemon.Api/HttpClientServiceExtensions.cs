namespace Pokemon.Api
{
    public static class HttpClientServiceExtensions
    {
        public static IServiceCollection AddExternalApis(this IServiceCollection services)
        {
            services.AddHttpClient("PokemonApiClient", c => {

                c.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            });

            return services;
        }

    }
}
