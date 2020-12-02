using System.Windows.Forms;
using Tic_tac_toe.Models;

namespace Tic_tac_toe.Properties
{
    public interface ITicTacToe
    {
        void ChangeTurnLabel(MapValues mapValues);
        void UpdateWinnerLabel();
        DialogResult GetEndGameMessage(MapValues winner);
        void ReleaseButtons();
        void ShowDrow();
        string GetButton(string id);
        void DisableButton(string name);
        void ChangeButtonText(string name, string value);
        void UpdateTurnLabel();
        void SetButtonText(string id, string value);
    }
}