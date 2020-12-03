using Browser.Models;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Browser.LogicTransfer
{
    public class LogicTransfer : ITicTacToe
    {
        private static LogicTransfer instance;
        public static LogicTransfer Instance => instance ??= new LogicTransfer();
        public GameState GameState { get; set; }
        private LogicTransfer()
        {
            GameState = new GameState();
        }
        public object GetEndGameMessage(MapValues winner)
        {
            GameState.EndGame.CurrentWinner = winner.ToString();
            GameState.EndGame.ShowEndGameMessage = true;
            return "Yes";
        }

        public void ReleaseButtons()
        {
            GameState.ReleaseButtons = true;
        }

        public void ShowDrow()
        {
            GameState.ShowDrow = true;
        }

        public void UpdateTurnLabel()
        {
            if (TicTacToe.Instance.Turn)
                GameState.CurrentTurn = "X";
            else
                GameState.CurrentTurn = "O";
        }

        public void UpdateWinnerLabel()
        {
            GameState.WinnerLabels.XWins = TicTacToe.Instance.PlayerXWinCount;
            GameState.WinnerLabels.OWins = TicTacToe.Instance.PlayerOWinCount;
        }
    }
}
