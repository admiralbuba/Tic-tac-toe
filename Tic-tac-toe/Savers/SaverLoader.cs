using Tic_tac_toe.Properties;

namespace Tic_tac_toe.Savers
{
    public static class SaverLoader
    {
        public static Settings setting { get; set; } = Settings.DataBase;
        public static void SaveData()
        {
            switch(setting)
            {
                case Settings.DataBase:
                    DataBaseSaver.SaveData();
                    break;
                case Settings.JSON:
                    JSONSaver.SaveData();
                    break;
            };
        }
        public static void GetData(ITicTacToe platform)
        {
            switch (setting)
            {
                case Settings.DataBase:
                    DataBaseSaver.GetData(platform);
                    break;
                case Settings.JSON:
                    JSONSaver.GetData();
                    break;
            };
        }
    }
}
