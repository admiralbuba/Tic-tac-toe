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
            var buttons = MainWindow.Instance.GetAllButtons();
            foreach (var button in buttons)
            {
                gameInfo.ButtonInfos.Add(new ButtonInfo() { 
                    Id = button.Name, 
                    Value = button.Text });
            }
            TicTacToe.Instance.PutMapInfoIntoGameInfoObject(gameInfo);
            File.WriteAllText(Utils.directoryPath + "info.json", JsonConvert.SerializeObject(gameInfo));
        }

        public static void GetData()
        {
            var gameInfo = JsonConvert.DeserializeObject<GameInfo>(File.ReadAllText(Utils.directoryPath + "info.json"));
            foreach (var item in gameInfo.ButtonInfos)
            {
                MainWindow.Instance.SetButtonText(item.Id, item.Value);
                TicTacToe.Instance.SetInArray(item.Id, item.Value);
            }
            TicTacToe.Instance.GetMapInfoFromGameInfoObject(gameInfo);
            MainWindow.Instance.UpdateMainWindowsLabels();
            TicTacToe.Instance.CheckForWinner();
        }
    }
}
