using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Models
{
    public class GameInfo
    {
        [JsonProperty("MapInfo")]
        public List<ButtonInfo> ButtonInfos { get; set; }
        [JsonProperty("TurnsInfo")]
        public Turns Turns { get; set; }
        public WinnersCount WinnersCount { get; set; }
        public GameInfo()
        {
            ButtonInfos = new List<ButtonInfo>();
            Turns = new Turns();
            WinnersCount = new WinnersCount();
        }
    }
}
