using NUnit.Framework;
using Oxbury.QATask.SeleniumSetUp.Helpers;

namespace Oxbury.QATask.SeleniumSetUp
{
    [TestFixture(SeleniumDevice.ChromeDesktop, "https://automationintesting.online/")]
    [TestFixture(SeleniumDevice.EdgeDesktop, "https://automationintesting.online/")]
internal class lastNameFieldShouldNotAllowExtraniousInputs : OxburyBannerCheck
{
    private string pageUrl;

        public lastNameFieldShouldNotAllowExtraniousInputs(SeleniumDevice device, string pageUrl) : base(device)
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
        public void LastNameFieldShouldNotAllowEmptyInputs()
        {
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "lastname", "");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
            BedAndBreakfastPage.CheckForCorrectAlert(Driver, "Lastname should not be blank");
        }

        [Test]
        public void LastNameFieldShouldNotBeLessThanThreeChars()
        {
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "lastname", "Da");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
            BedAndBreakfastPage.CheckForCorrectAlert(Driver, "size must be between 3 and 30");
        }

        [Test]
        public void LastNameFieldShouldNotBeMoreThanThirtyChars()
        {
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "lastname", "dannndannndannndannndannndannn");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
            BedAndBreakfastPage.CheckForCorrectAlert(Driver, "size must be between 3 and 30");
        }
    }
}