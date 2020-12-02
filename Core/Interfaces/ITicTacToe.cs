using Core.Models;

namespace Core
{
    public interface ITicTacToe
    { 
        void UpdateWinnerLabel();
        object GetEndGameMessage(MapValues winner);
        void ReleaseButtons();
        void ShowDrow();
        void UpdateTurnLabel();
    }
}