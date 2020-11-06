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
                var value = MainWindow.GetInstance().GetButtonText(item.Id);
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
                PlayerXWinCount = TicTacToe.GetInstance().PlayerXWinCount,
                PlayerOWinCount = TicTacToe.GetInstance().PlayerOWinCount
            };
            winnersCounts.InsertOnSubmit(values);
        }
        private static void InsertTurns(Table<Turns> turns)
        {
            var values = new Turns { Turn = TicTacToe.GetInstance().Turn, TurnCount = TicTacToe.GetInstance().TurnCount };
            turns.InsertOnSubmit(values);
        }
        private static void GetMap(DataContext db)
        {
            Table<ButtonInfo> map = db.GetTable<ButtonInfo>();

            foreach (var item in map)
            {
                MainWindow.GetInstance().SetButtonText(item.Id, item.Value);
                TicTacToe.GetInstance().SetInArray(item.Id);
            }
        }
        private static void GetTurns(DataContext db)
        {
            Table<Turns> turns = db.GetTable<Turns>();
            foreach (var item in turns)
            {
                TicTacToe.GetInstance().Turn = item.Turn;
                TicTacToe.GetInstance().TurnCount = item.TurnCount;
            }
            MainWindow.GetInstance().UpdateTurnLabel();
        }
        private static void GetWinnersCount(DataContext db)
        {
            Table<WinnersCount> turns = db.GetTable<WinnersCount>();
            foreach (var item in turns)
            {
                TicTacToe.GetInstance().PlayerXWinCount = item.PlayerXWinCount;
                TicTacToe.GetInstance().PlayerOWinCount = item.PlayerOWinCount;
            }
            MainWindow.GetInstance().UpdateWinnerLabel();
        }
    }
}
