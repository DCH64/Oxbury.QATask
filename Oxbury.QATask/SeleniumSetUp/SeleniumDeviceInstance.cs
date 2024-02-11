using System.Drawing;

namespace Oxbury.QATask.SeleniumSetUp
{
    public class SeleniumDeviceInstance
    {
        public SeleniumDriver Driver { get; set; }
        public Size? Size { get; set; }

        public static SeleniumDeviceInstance Find(SeleniumDevice seleniumDevice)
        {
            switch (seleniumDevice)
            {
                case SeleniumDevice.ChromeDesktop:
                    return ChromeDesktop;
                case SeleniumDevice.EdgeDesktop:
                    return EdgeDesktop;
                default:
                    return null;
            }
        }

        public static SeleniumDeviceInstance ChromeDesktop = new SeleniumDeviceInstance()
        {
            Driver = SeleniumDriver.Chrome,
            Size = new Size(1920, 1080)
        };

        public static SeleniumDeviceInstance EdgeDesktop = new SeleniumDeviceInstance()
        {
            Driver = SeleniumDriver.Edge,
            Size = new Size(1920, 1080)
        };
    }
}
