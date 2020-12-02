namespace Browser.Models
{
    public class GameState
    {
        public string CurrentTurn { get; set; }
        public WinnerLabels WinnerLabels { get; set; }
        public EndGame EndGame { get; set; }
        public bool ReleaseButtons { get; set; }
        public bool ShowDrow { get; set; }
    }
}
