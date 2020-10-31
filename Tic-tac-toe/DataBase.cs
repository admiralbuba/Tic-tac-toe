using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms.VisualStyles;
using System.Linq;
using System.Data.Linq;
using Tic_tac_toe.Models;
using Tic_tac_toe.Properties;

namespace Tic_tac_toe
{
    public static class DataBase
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static void GetData()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                GetMap(db);
                GetTurns(db);
            }
        }
        public static void SaveData()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                SaveMap(db);
                SaveTurns(db);
            }
        }
        private static void SaveMap(DataContext db)
        {
            Table<Map> map = db.GetTable<Map>();

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
            if ( value is null || value.Count != 0)
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
        private static void InsertTurns(Table<Turns> turns)
        {
            var values = new Turns { Turn = TicTacToe.GetInstance().Turn, TurnCount = TicTacToe.GetInstance().TurnCount };
            turns.InsertOnSubmit(values);
        }
        private static void GetMap(DataContext db)
        {
            Table<Map> map = db.GetTable<Map>();

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
    }
}
