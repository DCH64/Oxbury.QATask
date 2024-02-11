using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace Oxbury.QATask.SeleniumSetUp
{
    public abstract class SeleniumTest
    {

        private static DriverManager driverManager = new DriverManager();


        private static Dictionary<SeleniumDriver, Func<IWebDriver>> DriverLookupTable = new Dictionary<SeleniumDriver, Func<IWebDriver>>() {
        {
            SeleniumDriver.Chrome,
            () => {
                driverManager.SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                ChromeOptions chromeOptions = new ChromeOptions();

                //Headless Mode options
                chromeOptions.AddArgument("headless");
                chromeOptions.AddArgument("disable-gpu");
                chromeOptions.AddArgument("remote-debugging-port=9222");
                return new ChromeDriver(chromeOptions);
            }
        },
        {
            SeleniumDriver.Edge,
            () => {
                driverManager.SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
                EdgeOptions edgeOptions = new EdgeOptions();

                //Headless Mode options
                //edgeOptions.AddArgument("headless");
                //edgeOptions.AddArgument("disable-gpu");
                //edgeOptions.AddArgument("remote-debugging-port=9222");
                return new EdgeDriver(edgeOptions);
            }
        }
    };

        public readonly IWebDriver Driver;

        public SeleniumTest(SeleniumDevice device)
        {
            SeleniumDeviceInstance instance = SeleniumDeviceInstance.Find(device);

            //Creates the driver as specified by the driver variable.
            Driver = DriverLookupTable[instance.Driver]();
            Driver.Manage().Window.Size = instance.Size ?? new System.Drawing.Size(1920, 1080);
        }

        [OneTimeTearDownAttribute]
        public void TestFixtureTearDown()
        {
            Driver.Dispose();
        }
    }
}
