using System;
using System.Configuration;
using System.Data.Linq;
using Tic_tac_toe.Models;
using Tic_tac_toe.Properties;

namespace Tic_tac_toe
{
    public static class DataBaseSaver
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static void GetData()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                GetMap(db);
                GetTurns(db);
                GetWinnersCount(db);
            }
        }
        public static void SaveData()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                SaveMap(db);
                SaveTurns(db);
                SaveWinnersCount(db);
            }
        }
        private static void SaveMap(DataContext db)
        {
            Table<ButtonInfo> map = db.GetTable<ButtonInfo>();

            foreach (var item in map)
            {
                var value = MainWindow.Instance.GetButtonText(item.Id);
                item.Value = String.IsNullOrEmpty(value) ? null : value;
            }
            db.SubmitChanges();
        }
        private static void SaveTurns(DataContext db)
        {
            Table<Turns> turns = db.GetTable<Turns>();
            var value = turns.GetNewBindingList();
            if (value is null || value.Count != 0)
            {
                foreach (var item in turns)
                {
                    turns.DeleteOnSubmit(item);
                    db.SubmitChanges();
                }
                InsertTurns(turns);
            }
            else
            {
                InsertTurns(turns);
            }
            db.SubmitChanges();
        }
        private static void SaveWinnersCount(DataContext db)
        {
            Table<WinnersCount> winnersCounts = db.GetTable<WinnersCount>();
            var value = winnersCounts.GetNewBindingList();
            if (value is null || value.Count != 0)
            {
                foreach (var item in winnersCounts)
                {
                    winnersCounts.DeleteOnSubmit(item);
                    db.SubmitChanges();
                }
                InsertWinnersCounts(winnersCounts);
            }
            else
            {
                InsertWinnersCounts(winnersCounts);
            }
            db.SubmitChanges();
        }
        private static void InsertWinnersCounts(Table<WinnersCount> winnersCounts)
        {
            var values = new WinnersCount
            {
                PlayerXWinCount = TicTacToe.Instance.PlayerXWinCount,
                PlayerOWinCount = TicTacToe.Instance.PlayerOWinCount
            };
            winnersCounts.InsertOnSubmit(values);
        }
        private static void InsertTurns(Table<Turns> turns)
        {
            var values = new Turns { Turn = TicTacToe.Instance.Turn, TurnCount = TicTacToe.Instance.TurnCount };
            turns.InsertOnSubmit(values);
        }
        private static void GetMap(DataContext db)
        {
            Table<ButtonInfo> map = db.GetTable<ButtonInfo>();

            foreach (var item in map)
            {
                MainWindow.Instance.SetButtonText(item.Id, item.Value);
                TicTacToe.Instance.SetInArray(item.Id, item?.Value ?? "Null");
            }
        }
        private static void GetTurns(DataContext db)
        {
            Table<Turns> turns = db.GetTable<Turns>();
            foreach (var item in turns)
            {
                TicTacToe.Instance.Turn = item.Turn;
                TicTacToe.Instance.TurnCount = item.TurnCount;
            }
            MainWindow.Instance.UpdateTurnLabel();
        }
        private static void GetWinnersCount(DataContext db)
        {
            Table<WinnersCount> turns = db.GetTable<WinnersCount>();
            foreach (var item in turns)
            {
                TicTacToe.Instance.PlayerXWinCount = item.PlayerXWinCount;
                TicTacToe.Instance.PlayerOWinCount = item.PlayerOWinCount;
            }
            MainWindow.Instance.UpdateWinnerLabel();
        }
    }
}
