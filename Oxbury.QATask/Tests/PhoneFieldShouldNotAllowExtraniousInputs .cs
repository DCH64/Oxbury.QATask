using NUnit.Framework;
using Oxbury.QATask.SeleniumSetUp.Helpers;

namespace Oxbury.QATask.SeleniumSetUp
{
    [TestFixture(SeleniumDevice.ChromeDesktop, "https://automationintesting.online/")]
    [TestFixture(SeleniumDevice.EdgeDesktop, "https://automationintesting.online/")]
internal class PhoneFieldShouldNotAllowExtraniousInputs : OxburyBannerCheck
{
    private string pageUrl;

        public PhoneFieldShouldNotAllowExtraniousInputs(SeleniumDevice device, string pageUrl) : base(device)
        {
            this.pageUrl = pageUrl;
        }

        [SetUp]
        public override void Setup()
        {
            //Navigate to the ficture URL
            Driver.Navigate().GoToUrl(pageUrl);
            base.Setup();
        }

        [Test]
        public void PhoneFieldShouldNotAllowEmptyInputs()
        {
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "phone", "");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
            BedAndBreakfastPage.CheckForCorrectAlert(Driver, "must not be empty");
        }

        [Test]
        public void PhoneFieldShouldNotBeLessThanElevenChars()
        {
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "phone", "1111111111");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
            BedAndBreakfastPage.CheckForCorrectAlert(Driver, "size must be between 11 and 21");
        }

        [Test]
        public void PhoneFieldShouldNotBeMoreThanTwentyOneChars()
        {
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "phone", "1111111111111111111111");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
            BedAndBreakfastPage.CheckForCorrectAlert(Driver, "size must be between 11 and 21");
        }
    }
}