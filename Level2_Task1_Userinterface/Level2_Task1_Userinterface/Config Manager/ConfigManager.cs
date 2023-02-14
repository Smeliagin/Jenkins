using Level2_Task1_Userinterface.Utils;
using Level2_Task1_Userinterface.Models;

namespace Level2_Task1_Userinterface.Config_Manager
{
    public static class ConfigManager
    {
        public static Config configData = JsonReaderUtil.GetDataFromFile<Config>(PathClass.configPath);
        public static readonly string url = configData.Url;
    }
}
