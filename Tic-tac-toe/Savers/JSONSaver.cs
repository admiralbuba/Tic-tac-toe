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
            List<Map> map = new List<Map>();
            foreach (var item in jarray[0])
            {
                MainWindow.GetInstance().SetButtonText(JsonConvert.DeserializeObject<Map>(item.ToString()).Id,
                JsonConvert.DeserializeObject<Map>(item.ToString()).Value);
                TicTacToe.GetInstance().SetInArray(JsonConvert.DeserializeObject<Map>(item.ToString()).Id);
            }
            foreach (var item in jarray[1])
            {
                TicTacToe.GetInstance().Turn = (JsonConvert.DeserializeObject<Turns>(item.ToString()).Turn);
                TicTacToe.GetInstance().TurnCount = JsonConvert.DeserializeObject<Turns>(item.ToString()).TurnCount;
            }
            MainWindow.GetInstance().UpdateTurnLabel();
        }
    }
}
