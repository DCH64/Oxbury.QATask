using NUnit.Framework;
using Oxbury.QATask.SeleniumSetUp.Helpers;

namespace Oxbury.QATask.SeleniumSetUp
{
    [TestFixture(SeleniumDevice.ChromeDesktop, "https://automationintesting.online/")]
    [TestFixture(SeleniumDevice.EdgeDesktop, "https://automationintesting.online/")]
internal class FirstNameFieldShouldNotAllowExtraniousInputs : OxburyBannerCheck
{
    private string pageUrl;

        public FirstNameFieldShouldNotAllowExtraniousInputs(SeleniumDevice device, string pageUrl) : base(device)
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
        public void FirstnameFieldShouldNotAllowEmptyInputs()
        {
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "firstname", "");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
            BedAndBreakfastPage.CheckForCorrectAlert(Driver, "Firstname should not be blank");
        }

        [Test]
        public void FirstnameFieldShouldNotBeLessThanThreeChars()
        {
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "firstname", "Da");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
            BedAndBreakfastPage.CheckForCorrectAlert(Driver, "size must be between 3 and 18");
        }

        [Test]
        public void FirstnameFieldShouldNotBeMoreThanEighteenChars()
        {
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "firstname", "Dannnnnnnnnnnnnnnnn");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
            BedAndBreakfastPage.CheckForCorrectAlert(Driver, "size must be between 3 and 18");
        }
    }
}