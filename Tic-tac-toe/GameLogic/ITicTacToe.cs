using Tic_tac_toe.Models;

namespace Tic_tac_toe.Properties
{
    interface ITicTacToe
    {
        void CheckForWinner();
        void MakeTurn(object sender);
        void ResetGame();
        void ResetMap();
        void ChangeTurnLabel(MapValues mapValues);
        void SetInArray(string name);
        void CheckForVictoryConditions();
        void GetButton();
    }
}