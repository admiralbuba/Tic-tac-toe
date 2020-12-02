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
        public GameState GameStateJson { get; set; }
        private LogicTransfer()
        {
            GameStateJson = new GameState();
        }
        public object GetEndGameMessage(MapValues winner)
        {
            GameStateJson.EndGame.CurrentWinner = winner;
            GameStateJson.EndGame.ShowEndGameMessage = true;
            return GameStateJson;
        }

        public void ReleaseButtons()
        {
            GameStateJson.ReleaseButtons = true;
        }

        public void ShowDrow()
        {
            GameStateJson.ShowDrow = true;
        }

        public void UpdateTurnLabel()
        {
            if (TicTacToe.Instance.Turn)
                GameStateJson.CurrentTurn = "X";
            else
                GameStateJson.CurrentTurn = "O";
        }

        public void UpdateWinnerLabel()
        {
            var xCount = TicTacToe.Instance.PlayerXWinCount;
            GameStateJson.WinnerLabels.XWins = xCount;
            var oCount = TicTacToe.Instance.PlayerOWinCount;
            GameStateJson.WinnerLabels.XWins = oCount;
        }
    }
}
