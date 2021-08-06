using BlazorPokedex.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPokedex.Services.Services
{
    public class PokeApiClient : IPokeApiClient
    {
        private readonly HttpClient _httpClient;

        public PokeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResultObject> GetAllPokemons(PaginationParameters parameters)
        {
            return JsonConvert.DeserializeObject<ResultObject>(
                 await _httpClient.GetStringAsync($"pokemon?limit={parameters.PageSize}&offset={parameters.Offset}"));
        }

        public async Task<Pokemon> GetPokemon(string name)
        {
            return JsonConvert.DeserializeObject<Pokemon>(
                await _httpClient.GetStringAsync($"pokemon/{name}"));
        }

        public async Task<IEnumerable<Pokemon>> GetAllPokemons()
        {
            var pokemonList = JsonConvert.DeserializeObject<ResultObject>(
                await _httpClient.GetStringAsync($"pokemon?limit=100&offset=200"));
            var resultList = new List<Pokemon>();
            var resultList2 = new ObservableCollection<Pokemon>();
            foreach (var poke in pokemonList.Pokemons)          
                resultList.Add(await GetPokemon(poke.Name));

                resultList2 = new ObservableCollection<Pokemon>(
                pokemonList.Pokemons.Select(p => new Pokemon
                {
                    Id = p.Id,
                    Name = p.Name,
                })
            .OrderBy(p => p.Name)
            .ToList());

            return resultList2;
        }
    }
}
