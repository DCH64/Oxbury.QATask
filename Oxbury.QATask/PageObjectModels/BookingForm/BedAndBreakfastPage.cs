using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            IWebElement SubmitFormBtn = driver.FindElement(By.CssSelector("button[class='btn btn-outline-primary float-right book-room']"));
            SubmitFormBtn.Click();
        }
        //verify the correct message is shown
        public static void VerifySubmissionSuccessMessageAppears(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            IWebElement successMsgDialog = driver.FindElement(By.CssSelector("[aria-label*='onRequestClose Example']"));
            IWebElement successMsg = driver.FindElement(By.XPath("//h3[normalize-space()='Booking Successful!']"));
            if(successMsg.Enabled && successMsg.Displayed)
            {
                Assert.Pass();
            }
        }
        //A senkeys function that can be configured to the name field in the html
        public static void SendKeysToFormfield(IWebDriver driver,string fieldName, string keysToSend)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            IWebElement emailField = driver.FindElement(By.Name($"{fieldName}"));
            emailField.Click();
            emailField.SendKeys(keysToSend);
        }
        //select two calendar dates based on input strings
        public static void SelectTwoCalendarDates(IWebDriver driver, string str1, string str2)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            IWebElement calendarArea = driver.FindElement(By.ClassName("rbc-calendar"));
            IWebElement calendarAreaCurrent = calendarArea.FindElement(By.ClassName("rbc-month-view"));
            IWebElement selectedDay1 = calendarAreaCurrent.FindElement(By.XPath($"//*[text()='{str1}']"));
            IWebElement selectedDay1Parent = selectedDay1.FindElement(By.XPath(".."));
            IWebElement selectedDay2 = calendarAreaCurrent.FindElement(By.XPath($"//*[text()='{str2}']"));
            var builder = new Actions(driver);
            var dragAndRelease = builder.ClickAndHold(selectedDay1).MoveToElement(selectedDay1Parent).MoveToElement(selectedDay2).Release(selectedDay2).Build();
            dragAndRelease.Perform();
        }

        //unfinished check for the correct alert
        public static void CheckForCorrectAlert(IWebDriver driver, string str)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            IWebElement alertMessageBox = driver.FindElement(By.CssSelector(".alert.alert-danger"));
            IWebElement alertMessage = alertMessageBox.FindElement(By.XPath($"//*[text()='{str}']"));

        }
    }
}
