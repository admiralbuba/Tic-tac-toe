using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Tic_tac_toe.Models;
using Tic_tac_toe.Properties;

namespace Tic_tac_toe
{
    public static class JSONSaver
    {
        public static void SaveData()
        {

            JArray buttonsInfo = new JArray();
            var buttons = MainWindow.GetInstance().GetAllButtons();
            foreach (var button in buttons)
            {
                JObject buttonInfo = new JObject(
                    new JProperty("Id", button.Name),
                    new JProperty("Value", button.Text));
                buttonsInfo.Add(buttonInfo);
            }

            JArray turnsInfo = new JArray();
            JObject turns = new JObject(
                new JProperty("Turn", TicTacToe.GetInstance().Turn.ToString()),
                new JProperty("TurnCount", TicTacToe.GetInstance().TurnCount.ToString()));
            turnsInfo.Add(turns);

            JArray gameInfo = new JArray();
            gameInfo.Add(buttonsInfo);
            gameInfo.Add(turnsInfo);
            File.WriteAllText(Utils.directoryPath + "info.json", gameInfo.ToString());
        }

        public static void GetData()
        {
            var jarray = JArray.Parse(File.ReadAllText(Utils.directoryPath + "info.json"));
            var mapInfo = JsonConvert.DeserializeObject<List<ButtonInfo>>(jarray[0].ToString());
            var turnsInfo = JsonConvert.DeserializeObject<Turns>(jarray[1][0].ToString());
            foreach (var item in mapInfo)
            {
                MainWindow.GetInstance().SetButtonText(item.Id, item.Value);
                TicTacToe.GetInstance().SetInArray(item.Id);
            }
            TicTacToe.GetInstance().Turn = turnsInfo.Turn;
            TicTacToe.GetInstance().TurnCount = turnsInfo.TurnCount;
            MainWindow.GetInstance().UpdateTurnLabel();
        }
    }
}
