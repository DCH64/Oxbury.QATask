using NUnit.Framework;
using OpenQA.Selenium;

namespace Oxbury.QATask.SeleniumSetUp
{
    [TestFixture(SeleniumDevice.ChromeDesktop, "https://automationintesting.online/")]
    [TestFixture(SeleniumDevice.EdgeDesktop, "https://automationintesting.online/")]
    internal abstract class BedAndBreakfastPage : SeleniumTest
    {
        protected string pageUrl = string.Empty;

        public BedAndBreakfastPage(SeleniumDevice device, string pageUrl) : base(device)
        {
            this.pageUrl = pageUrl;
        }
        //click on the book form button
        public static void ClickOnBookFormBtn(IWebDriver driver)
        {
            IWebElement BookFormBtn = driver.FindElement(By.CssSelector("button[class='btn btn-outline-primary float-right openBooking']"));
            BookFormBtn.Click();
        }
        //Click on the submitu button
        public static void ClickOnSubmitFormBtn(IWebDriver driver)
        {
            IWebElement SubmitFormBtn = driver.FindElement(By.CssSelector("button[class='btn btn-outline-primary float-right book-room']"));
            SubmitFormBtn.Click();
        }
        //A senkeys function that can be configured to the name field in the html
        public static void SendKeysToFormfield(IWebDriver driver,string fieldName, string keysToSend)
        {
            IWebElement emailField = driver.FindElement(By.Name($"fieldName"));
            emailField.Click();
            emailField.SendKeys(keysToSend);
        }
        //unfinished check for the correct alert
        public static void CheckForCorrectAlert(IWebDriver driver, string str)
        {
            IWebElement alertMessageBox = driver.FindElement(By.CssSelector(".alert.alert-danger"));
            IWebElement alertMessage = alertMessageBox.FindElements(By.TagName("p")).Where(item =>
            {

                if (item.FindElement(By.CssSelector(".text")).Text == $"{str}")
                {
                    //We've found the element.
                    return true;
                }
                else
                {
                    //This is not the element we are looking for.
                    return false;
                }
            }).First();

        }
    }
}
