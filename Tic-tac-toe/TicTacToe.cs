﻿using System.Windows.Forms;

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
            CheckForHorizontalAndVerticalWinner();
            CheckForDiagonalWinner();
        }
        private void CheckForHorizontalAndVerticalWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                int sumXHor = 0;
                int sumOHor = 0;
                int sumXVer = 0;
                int sumOVer = 0;
                for (int j = 0; j < 3; j++)
                {
                    CheckInMap(i, j, Values.X, ref sumXHor);
                    CheckInMap(j, i, Values.X, ref sumXVer);;
                    CheckInMap(i, j, Values.O, ref sumOHor);
                    CheckInMap(j, i, Values.O, ref sumOVer);

                }
            }
        }
        private void CheckInMap(int i, int j, Values value, ref int sum)
        {
            if (map[i, j] == value)
                sum++;
            CheckForVictoryConditions(sum);
        }
        private void CheckForDiagonalWinner()
        {
            int sumXDiag = 0;
            int sumODiag = 0;
            int sumXAntiDiag = 0;
            int sumOAntiDiag = 0;
            for (int i = 0; i < 3; i++)
            {
                CheckInMap(i, i, Values.X, ref sumXDiag);
                CheckInMap(i, i * (-1) + 2, Values.X, ref sumXAntiDiag);
                CheckInMap(i, i, Values.O, ref sumODiag);
                CheckInMap(i, i * (-1) + 2, Values.O, ref sumOAntiDiag);
            }
        }
        private void CheckForVictoryConditions(int sum)
        {
            if (sum == 3)
            {
                MessageBox.Show("Winner");
                MainWindow.GetInstance().DisableAllButtons();
            }
        }
    }
}
