using Newtonsoft.Json;

namespace Level2_Task1_Userinterface.Utils
{
    public static class JsonReaderUtil
    {
        public static T GetDataFromFile<T>(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
