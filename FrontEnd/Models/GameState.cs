using Core.Models;

namespace Browser.Models
{
    public class GameState
    {
        public GameState()
        {
            WinnersCount = new WinnersCount();
            EndGame = new EndGame();
        }
        public string CurrentTurn { get; set; }
        public WinnersCount WinnersCount { get; set; }
        public EndGame EndGame { get; set; }
        public bool ReleaseButtons { get; set; }
        public bool ShowDrow { get; set; }
    }
}
