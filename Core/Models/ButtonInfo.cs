using Newtonsoft.Json;
using System.Data.Linq.Mapping;

namespace Core.Models
{
    [Table(Name = "Map")]
    public class ButtonInfo
    {
        [JsonProperty("id")]
        [Column(Name = "Id", IsPrimaryKey = true)]
        public string Id { get; set; }
        [JsonProperty("value")]
        [Column(Name = "Value", CanBeNull = true)]
        public string Value { get; set; }
    }
}
