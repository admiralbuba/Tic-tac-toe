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
            TicTacToe.GetInstance().PutMapInfoIntoGameInfoObject(gameInfo);
            File.WriteAllText(Utils.directoryPath + "info.json", JsonConvert.SerializeObject(gameInfo));
        }

        public static void GetData()
        {
            var gameInfo = JsonConvert.DeserializeObject<GameInfo>(File.ReadAllText(Utils.directoryPath + "info.json"));
            foreach (var item in gameInfo.ButtonInfos)
            {
                MainWindow.GetInstance().SetButtonText(item.Id, item.Value);
                TicTacToe.GetInstance().SetInArray(item.Id);
            }
            TicTacToe.GetInstance().GetMapInfoFromGameInfoObject(gameInfo);
            MainWindow.GetInstance().UpdateMainWindowsLabels();
            TicTacToe.GetInstance().CheckForWinner();
        }
    }
}
