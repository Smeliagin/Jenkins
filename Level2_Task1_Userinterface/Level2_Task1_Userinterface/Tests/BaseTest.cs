using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;
using Level2_Task1_Userinterface.Config_Manager;
using Level2_Task1_Userinterface.Models;
using Level2_Task1_Userinterface.Utils;

namespace Level2_Task1_Userinterface.Tests
{
    public abstract class BaseTest
    {
        protected string TestCaseSeparator = new string('*', 10);
        protected static TestData testData = JsonReaderUtil.GetDataFromFile<TestData>(PathClass.testDataPath);
        protected static Logger Logger => Logger.Instance;

        [SetUp]
        public void Setup()
        {
            Logger.Info("Navigate to welcome page");
            AqualityServices.Browser.GoTo(ConfigManager.url);
            Logger.Info("Set window size maximize");
            AqualityServices.Browser.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Message != null)
            {
                Logger.Error(TestContext.CurrentContext.Result.Message.ToString());
            }
            AqualityServices.Browser.Quit();
            Logger.Info($"End userinterface tests");
        }
    }
    
}
