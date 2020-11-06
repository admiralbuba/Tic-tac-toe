using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Text;

namespace Tic_tac_toe.Models
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
