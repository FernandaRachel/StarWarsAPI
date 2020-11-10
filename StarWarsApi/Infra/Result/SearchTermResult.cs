using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsApi.Infra.Result
{
    public class SearchTermResult
    {
        [JsonPropertyName("searchTerm")]
        public string SeachTerm { get; set; }

        [JsonPropertyName("qtdSearch ")]
        public int QtdSearch { get; set; }
    }
}
