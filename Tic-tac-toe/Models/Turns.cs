using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Text;

namespace Tic_tac_toe.Models
{
    [Table(Name = "Turns")]
    public class Turns
    {
        [JsonProperty("turn")]
        [Column(Name = "Turn", CanBeNull = true, IsPrimaryKey = true)]
        public bool Turn { get; set; }
        [JsonProperty("turnCount")]
        [Column(Name = "TurnCount", CanBeNull = false)]
        public int TurnCount { get; set; }
    }
}
