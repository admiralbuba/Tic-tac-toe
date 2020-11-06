using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_tac_toe.Models
{
    public class WinnersCount
    {
        [JsonProperty("playerXWinCount")]
        public byte PlayerXWinCount { get; set; }
        [JsonProperty("playerOWinCount")]
        public byte PlayerOWinCount { get; set; }
    }
}
