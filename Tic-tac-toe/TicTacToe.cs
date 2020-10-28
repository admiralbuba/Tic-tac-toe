using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Tic_tac_toe.Properties
{
    class TicTacToe
    {
        private static TicTacToe Instance;
        public bool turn { get; set; }
        public int turnCount { get; set; }
        public Values[,] map { get; set; }
        public TicTacToe()
        {
            turn = true;
            turnCount = 0;
            map = new Values[3, 3];
        }
        public static TicTacToe GetInstance() => Instance ??= new TicTacToe();
        public void ResetGame()
        {
            turn = true;
            turnCount = 0;
            map = new Values[3, 3];
        }
        public void MakeTurn(object sender)
        {
            Button button = (Button)sender;
            if (turn)
            {
                button.Text = "X";
                ArrayHelper.PutValuesInMap(map, button, Values.X);
            }
            else
            {
                button.Text = "O";
                ArrayHelper.PutValuesInMap(map, button, Values.O);
            }
            button.Enabled = false;
            turn = !turn;
            turnCount++;
            if (turnCount == 9)
            {
                MessageBox.Show("Draw!");
            }
            CheckForWinnerHorizontalAndVertical();
        }
        private void CheckForWinnerHorizontalAndVertical()
        {
            for (int i = 0; i < 3; i++)
            {
                int sumXHor = 0;
                int sumOHor = 0;
                int sumXVer = 0;
                int sumOVer = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (map[i, j] == Values.X)
                        sumXHor++;
                    CheckForVictoryConditions(sumXHor);
                    if (map[j, i] == Values.X)
                        sumXVer++;
                    CheckForVictoryConditions(sumXVer);
                    if (map[i, j] == Values.O)
                        sumOHor++;
                    CheckForVictoryConditions(sumOHor);
                    if (map[j, i] == Values.O)
                        sumOVer++;
                    CheckForVictoryConditions(sumOVer);

                }
            }
        }
        private void CheckForVictoryConditions(int sum)
        {
            if (sum == 3)
            {
                MessageBox.Show("Winner");
                var mainWindow = MainWindow.GetInstance();
                mainWindow.DisableAllButtons();
            }
        }
    }
}
