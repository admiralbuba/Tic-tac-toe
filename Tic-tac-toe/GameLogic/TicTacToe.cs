using System.Windows.Forms;

namespace Tic_tac_toe.Properties
{
    class TicTacToe
    {
        private static TicTacToe Instance;
        public bool Turn { get; set; }
        public int TurnCount { get; set; }
        public byte PlayerXWinCount { get; set; }
        public byte PlayerOWinCount { get; set; }
        public MapValues[,] Map { get; set; }
        private bool isVictory = false;
        private const int mapSize = 3;
        public TicTacToe()
        {
            Turn = true;
            TurnCount = 0;
            Map = new MapValues[mapSize, mapSize];
        }
        public static TicTacToe GetInstance() => Instance ??= new TicTacToe();
        public void ResetGame()
        {
            Turn = true;
            TurnCount = 0;
            Map = new MapValues[mapSize, mapSize];
            PlayerXWinCount = 0;
            PlayerOWinCount = 0;
            MainWindow.GetInstance().ChangeTurnLabel(MapValues.X);
            MainWindow.GetInstance().UpdateWinnerLabel();
        }
        public void MakeTurn(object sender)
        {
            Button button = (Button)sender;
            if (Turn)
            {
                button.Text = "X";
                ArrayHelper.PutValuesInMap(Map, button, MapValues.X);
                MainWindow.GetInstance().ChangeTurnLabel(MapValues.O);
            }
            else
            {
                button.Text = "O";
                ArrayHelper.PutValuesInMap(Map, button, MapValues.O);
                MainWindow.GetInstance().ChangeTurnLabel(MapValues.X);
            }
            button.Enabled = false;
            Turn = !Turn;
            TurnCount++;
            CheckForWinner();
            if (TurnCount == 9 && isVictory == false)
            {
                MessageBox.Show("Draw!");
            }
        }
        public void CheckForWinner()
        {
            CheckForHorizontalAndVerticalWinner();
            CheckForDiagonalWinner();
        }
        public void SetInArray(string name)
        {
            if (MainWindow.GetInstance().GetButtonText(name) == "X")
                ArrayHelper.PutValuesInMap(Map, MainWindow.GetInstance().GetButton(name), MapValues.X);
            if (MainWindow.GetInstance().GetButtonText(name) == "O")
                ArrayHelper.PutValuesInMap(Map, MainWindow.GetInstance().GetButton(name), MapValues.O);

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
                    CheckInMap(i, j, MapValues.X, ref sumXHor);
                    CheckInMap(j, i, MapValues.X, ref sumXVer);;
                    CheckInMap(i, j, MapValues.O, ref sumOHor);
                    CheckInMap(j, i, MapValues.O, ref sumOVer);

                }
            }
        }
        private void CheckInMap(int i, int j, MapValues value, ref int sum)
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
                CheckInMap(i, i, MapValues.X, ref sumXDiag);
                CheckInMap(i, i * (-1) + 2, MapValues.X, ref sumXAntiDiag);
                CheckInMap(i, i, MapValues.O, ref sumODiag);
                CheckInMap(i, i * (-1) + 2, MapValues.O, ref sumOAntiDiag);
            }
        }
        private void CheckForVictoryConditions(int sum)
        {
            if (sum == mapSize)
            {
                var winner = Turn ? MapValues.O : MapValues.X;
                MessageBox.Show($"Player {winner} win!");
                MainWindow.GetInstance().DisableAllButtons();
                isVictory = true;
                if (winner == MapValues.X)
                {
                    PlayerXWinCount++;
                    MainWindow.GetInstance().UpdateWinnerLabel();
                }                    
                if (winner == MapValues.O)
                {
                    PlayerOWinCount++;
                    MainWindow.GetInstance().UpdateWinnerLabel();
                }
            }
        }
    }
}
