using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Text;

namespace Tic_tac_toe.Models
{
    [Table(Name = "WinnerCount")]
    public class WinnersCount
    {
        [Key]
        [JsonProperty("playerXWinCount")]
        [Column(Name = "PlayerXWinCount", IsPrimaryKey = true)]
        public byte PlayerXWinCount { get; set; }
        [JsonProperty("playerOWinCount")]
        [Column(Name = "PlayerOWinCount")]
        public byte PlayerOWinCount { get; set; }
    }
}
