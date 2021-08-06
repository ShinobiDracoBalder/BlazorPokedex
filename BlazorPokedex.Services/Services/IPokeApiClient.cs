using BlazorPokedex.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorPokedex.Services.Services
{
    public interface IPokeApiClient
    {
        Task<ResultObject> GetAllPokemons(PaginationParameters parameters);
        Task<Pokemon> GetPokemon(string name);
        Task<IEnumerable<Pokemon>> GetAllPokemons();
    }
}
