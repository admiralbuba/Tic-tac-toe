using Newtonsoft.Json;
using System.IO;
using Tic_tac_toe.Models;
using Tic_tac_toe.Properties;

namespace Tic_tac_toe
{
    public static class JSONSaver
    {
        public static void SaveData()
        {
            var gameInfo = new GameInfo();
            var buttons = MainWindow.GetInstance().GetAllButtons();
            foreach (var button in buttons)
            {
                gameInfo.ButtonInfos.Add(new ButtonInfo() { 
                    Id = button.Name, 
                    Value = button.Text });
            }
            gameInfo.Turns.Turn = TicTacToe.GetInstance().Turn;
            gameInfo.Turns.TurnCount = TicTacToe.GetInstance().TurnCount;
            gameInfo.WinnersCount.PlayerXWinCount = TicTacToe.GetInstance().PlayerXWinCount;
            gameInfo.WinnersCount.PlayerOWinCount = TicTacToe.GetInstance().PlayerOWinCount;
            var str = JsonConvert.SerializeObject(gameInfo);
            File.WriteAllText(Utils.directoryPath + "info.json", str);
        }

        public static void GetData()
        {
            var gameInfo = JsonConvert.DeserializeObject<GameInfo>(File.ReadAllText(Utils.directoryPath + "info.json"));
            foreach (var item in gameInfo.ButtonInfos)
            {
                MainWindow.GetInstance().SetButtonText(item.Id, item.Value);
                TicTacToe.GetInstance().SetInArray(item.Id);
            }
            TicTacToe.GetInstance().Turn = gameInfo.Turns.Turn;
            TicTacToe.GetInstance().TurnCount = gameInfo.Turns.TurnCount;
            TicTacToe.GetInstance().PlayerXWinCount = gameInfo.WinnersCount.PlayerXWinCount;
            TicTacToe.GetInstance().PlayerOWinCount = gameInfo.WinnersCount.PlayerOWinCount;
            MainWindow.GetInstance().UpdateWinnerLabel();
            MainWindow.GetInstance().UpdateTurnLabel();
            TicTacToe.GetInstance().CheckForWinner();
        }
    }
}
