using OpenQA.Selenium;

namespace Oxbury.QATask.SeleniumSetUp
{
    internal class OxburyBannerCheck : SeleniumTest
    {
        public OxburyBannerCheck(SeleniumDevice device) : base(device)
        {
        }

        public virtual void Setup()
        {
            //check if the page load banner is present, and close
            if (IsElementPresent(By.Id("collapseBanner"))) ;
            {
                if (IsElementPresent(By.CssSelector("#collapseBanner > div > div:nth-child(3) > div.col-2.text-center > button")))
                {
                    IWebElement consentButton = Driver.FindElement(By.CssSelector("#collapseBanner > div > div:nth-child(3) > div.col-2.text-center > button"));
                    consentButton.Click();
                }

            }
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }
    }
}