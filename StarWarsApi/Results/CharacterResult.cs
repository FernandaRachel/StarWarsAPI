using Newtonsoft.Json;
using StarWarsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsApi.Results
{
    public class CharacterResult
    {
        [JsonPropertyName("mainCharacter ")]
        public Character MainCharacter { get; set; }

        [JsonPropertyName("suggestedCharacter")]
        public List<Character> SuggestedCharacter { get; set; }
    }
}
