using System.Windows.Forms;

namespace Tic_tac_toe.Properties
{
    class TicTacToe
    {
        private static TicTacToe Instance;
        public bool Turn { get; set; }
        public int TurnCount { get; set; }
        public Values[,] Map { get; set; }
        private bool isVictory = false;
        private const int mapSize = 3;
        public TicTacToe()
        {
            Turn = true;
            TurnCount = 0;
            Map = new Values[mapSize, mapSize];
        }
        public static TicTacToe GetInstance() => Instance ??= new TicTacToe();
        public void ResetGame()
        {
            Turn = true;
            TurnCount = 0;
            Map = new Values[mapSize, mapSize];
            MainWindow.GetInstance().ChangeTurnLabel(Values.X);
        }
        public void MakeTurn(object sender)
        {
            Button button = (Button)sender;
            if (Turn)
            {
                button.Text = "X";
                ArrayHelper.PutValuesInMap(Map, button, Values.X);
                MainWindow.GetInstance().ChangeTurnLabel(Values.O);
            }
            else
            {
                button.Text = "O";
                ArrayHelper.PutValuesInMap(Map, button, Values.O);
                MainWindow.GetInstance().ChangeTurnLabel(Values.X);
            }
            button.Enabled = false;
            Turn = !Turn;
            TurnCount++;
            CheckForHorizontalAndVerticalWinner();
            CheckForDiagonalWinner();
            if (TurnCount == 9 && isVictory == false)
            {
                MessageBox.Show("Draw!");
            }
        }
        public void SetInArray(string name)
        {
            if (MainWindow.GetInstance().GetButtonText(name) == "X")
                ArrayHelper.PutValuesInMap(Map, MainWindow.GetInstance().GetButton(name), Values.X);
            if (MainWindow.GetInstance().GetButtonText(name) == "O")
                ArrayHelper.PutValuesInMap(Map, MainWindow.GetInstance().GetButton(name), Values.O);

        }
        private void CheckForHorizontalAndVerticalWinner()
        {
            for (int i = 0; i < mapSize; i++)
            {
                int sumXHor = 0;
                int sumOHor = 0;
                int sumXVer = 0;
                int sumOVer = 0;
                for (int j = 0; j < mapSize; j++)
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
            if (Map[i, j] == value)
                sum++;
            CheckForVictoryConditions(sum);
        }
        private void CheckForDiagonalWinner()
        {
            int sumXDiag = 0;
            int sumODiag = 0;
            int sumXAntiDiag = 0;
            int sumOAntiDiag = 0;
            for (int i = 0; i < mapSize; i++)
            {
                CheckInMap(i, i, Values.X, ref sumXDiag);
                CheckInMap(i, i * (-1) + 2, Values.X, ref sumXAntiDiag);
                CheckInMap(i, i, Values.O, ref sumODiag);
                CheckInMap(i, i * (-1) + 2, Values.O, ref sumOAntiDiag);
            }
        }
        private void CheckForVictoryConditions(int sum)
        {
            if (sum == mapSize)
            {
                string message = Turn ? $"{Values.O}" : $"{Values.X}"; 
                MessageBox.Show($"Player {message} win!");
                MainWindow.GetInstance().DisableAllButtons();
                isVictory = true;
            }
        }
    }
}
