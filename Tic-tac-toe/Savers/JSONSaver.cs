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
                    new JProperty(button.Name),
                    new JProperty(button.Text));
                buttonsInfo.Add(buttonInfo);
            }

            JObject turns = new JObject(
                new JProperty(TicTacToe.GetInstance().Turn.ToString()),
                new JProperty(TicTacToe.GetInstance().TurnCount.ToString()));

            JArray gameInfo = new JArray();
            gameInfo.Add(buttonsInfo);
            gameInfo.Add(turns);
            File.WriteAllText(Utils.directoryPath + "info.json", gameInfo.ToString());
        }

        public static void GetData()
        {
        }
    }
}
