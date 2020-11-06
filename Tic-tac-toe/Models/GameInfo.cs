using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_tac_toe.Models
{
    public class GameInfo
    {
        [JsonProperty("MapInfo")]
        public List<ButtonInfo> ButtonInfos { get; set; }
        [JsonProperty("TurnsInfo")]
        public Turns Turns { get; set; }
        public GameInfo()
        {
            ButtonInfos = new List<ButtonInfo>();
            Turns = new Turns();
        }
    }
}
