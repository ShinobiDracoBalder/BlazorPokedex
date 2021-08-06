using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlazorPokedex.Models.Models
{
    public class ResultObject
    {
        [JsonProperty("results")]
        public IEnumerable<Pokemon> Pokemons { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
