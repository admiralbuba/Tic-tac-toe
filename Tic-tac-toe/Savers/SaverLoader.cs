using Core.Properties;

namespace Core.Savers
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
        public static void GetData(ITicTacToe platform, IUIHelper uIHelper = null)
        {
            switch (setting)
            {
                case Settings.DataBase:
                    DataBaseSaver.GetData(platform, uIHelper);
                    break;
                case Settings.JSON:
                    JSONSaver.GetData();
                    break;
            };
        }
    }
}
