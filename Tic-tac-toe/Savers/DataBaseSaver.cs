using System;
using System.Configuration;
using System.Data.Linq;
using Core.Models;
using Core.Properties;

namespace Core
{
    public static class DataBaseSaver
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static void GetData(ITicTacToe platform, IUIHelper uIHelper = null)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                GetMap(db, platform, uIHelper);
                GetTurns(db, platform);
                GetWinnersCount(db, platform);
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
        private static void GetMap(DataContext db, ITicTacToe platform, IUIHelper uIHelper = null)
        {
            Table<ButtonInfo> map = db.GetTable<ButtonInfo>();

            foreach (var item in map)
            {
                uIHelper?.SetButtonText(item.Id, item.Value);
                TicTacToe.Instance.SetInArray(item.Id, item?.Value ?? "Null");
            }
        }
        private static void GetTurns(DataContext db, ITicTacToe platform)
        {
            Table<Turns> turns = db.GetTable<Turns>();
            foreach (var item in turns)
            {
                TicTacToe.Instance.Turn = item.Turn;
                TicTacToe.Instance.TurnCount = item.TurnCount;
            }
            platform.UpdateTurnLabel();
        }
        private static void GetWinnersCount(DataContext db, ITicTacToe platform)
        {
            Table<WinnersCount> turns = db.GetTable<WinnersCount>();
            foreach (var item in turns)
            {
                TicTacToe.Instance.PlayerXWinCount = item.PlayerXWinCount;
                TicTacToe.Instance.PlayerOWinCount = item.PlayerOWinCount;
            }
            platform.UpdateWinnerLabel();
        }
    }
}
