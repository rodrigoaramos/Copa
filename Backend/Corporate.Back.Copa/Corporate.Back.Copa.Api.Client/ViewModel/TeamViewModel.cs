using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Back.Copa.Api.Client.ViewModel
{
    public class TeamViewModel
    {
        [JsonProperty("Id")]
        public string Id { get; set; } = "";

        [JsonProperty("Nome")]
        public string Name { get; set; } = "";

        [JsonProperty("Sigla")]
        public string Initials { get; set; } = "";

        [JsonProperty("Gols")]
        public int Goals { get; set; } = 0;
    }
}