using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlazorPokedex.Models.Models
{
    public class Pokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("weight")]
        public int Weight { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("base_experience")]
        public int Experience { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("types")]
        public List<Type> Types { get; set; }

        [JsonProperty("sprites")]
        public Sprite Sprite { get; set; }
    }
}
