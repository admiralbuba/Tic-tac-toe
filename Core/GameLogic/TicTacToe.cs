using System;
using Core.Models;

namespace Core
{
    public class TicTacToe
    {
        private static TicTacToe instance;
        public bool Turn { get; set; }
        public int TurnCount { get; set; }
        public byte PlayerXWinCount { get; set; }
        public byte PlayerOWinCount { get; set; }
        public MapValues[,] Map { get; set; }
        private const int mapSize = 3;
        private ITicTacToe platform;
        private IUIHelper uIHelper;
        public TicTacToe()
        {
            Turn = true;
            TurnCount = 0;
            Map = new MapValues[mapSize, mapSize];
        }
        public static TicTacToe Instance => instance ??= new TicTacToe();
        public void ResetGame()
        {
            ResetMap();
            PlayerXWinCount = 0;
            PlayerOWinCount = 0;
            platform.UpdateWinnerLabel();
        }
        private void ResetMap()
        {
            Turn = true;
            TurnCount = 0;
            Map = new MapValues[mapSize, mapSize];
            uIHelper?.ChangeTurnLabel(MapValues.X);
        }
        public void MakeTurn(string name, string value, ITicTacToe platform, IUIHelper uIHelper = null)
        {
            this.platform = platform;
            this.uIHelper = uIHelper;

            if (Turn)
            {
                uIHelper?.ChangeButtonText(name,"X");
                ArrayHelper.PutValuesInMap(Map, name, MapValues.X);
                uIHelper?.ChangeTurnLabel(MapValues.O);
            }
            else
            {
                uIHelper?.ChangeButtonText(name,"O");
                ArrayHelper.PutValuesInMap(Map, name, MapValues.O);
                uIHelper?.ChangeTurnLabel(MapValues.X);
            }
            uIHelper?.DisableButton(name);
            Turn = !Turn;
            TurnCount++;
            CheckForWinner();
            if (TurnCount == 9)
            {
                platform.ShowDrow();
            }
        }
        public void CheckForWinner()
        {
            CheckForHorizontalAndVerticalWinner();
            CheckForDiagonalWinner();
        }
        public void SetInArray(string id, string value)
        {
            ArrayHelper.PutValuesInMap(Map, id, (MapValues)Enum.Parse(typeof(MapValues), value));

        }
        public void PutMapInfoIntoGameInfoObject(GameInfo gameInfo)
        {
            gameInfo.Turns.Turn = Turn;
            gameInfo.Turns.TurnCount = TurnCount;
            gameInfo.WinnersCount.PlayerXWinCount = PlayerXWinCount;
            gameInfo.WinnersCount.PlayerOWinCount = PlayerOWinCount;
        }
        public void GetMapInfoFromGameInfoObject(GameInfo gameInfo)
        {
            Turn = gameInfo.Turns.Turn;
            TurnCount = gameInfo.Turns.TurnCount;
            PlayerXWinCount = gameInfo.WinnersCount.PlayerXWinCount;
            PlayerOWinCount = gameInfo.WinnersCount.PlayerOWinCount;
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
                    CheckInMap(j, i, MapValues.X, ref sumXVer);
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
                var result = platform.GetEndGameMessage(winner);
                if (result.ToString() == "Yes")
                {
                    if (winner == MapValues.X)
                    {
                        PlayerXWinCount++;
                        platform.UpdateWinnerLabel();
                    }
                    if (winner == MapValues.O)
                    {
                        PlayerOWinCount++;
                        platform.UpdateWinnerLabel();
                    }
                    ResetMap();
                    platform.ReleaseButtons();
                }
                else
                {
                    ResetGame();
                    platform.ReleaseButtons();
                }
            }
        }
    }
}
