using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace Core.Models
{
    [Table(Name = "Turns")]
    public class Turns
    {
        [Key]
        [JsonProperty("turn")]
        [Column(Name = "Turn", CanBeNull = true, IsPrimaryKey = true)]
        public bool Turn { get; set; }
        [JsonProperty("turnCount")]
        [Column(Name = "TurnCount", CanBeNull = false)]
        public int TurnCount { get; set; }
    }
}
