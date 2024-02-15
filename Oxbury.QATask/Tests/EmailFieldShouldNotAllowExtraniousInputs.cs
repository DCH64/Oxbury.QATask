using NUnit.Framework;
using Oxbury.QATask.SeleniumSetUp.Helpers;

namespace Oxbury.QATask.SeleniumSetUp
{
    [TestFixture(SeleniumDevice.ChromeDesktop, "https://automationintesting.online/")]
    [TestFixture(SeleniumDevice.EdgeDesktop, "https://automationintesting.online/")]
internal class EmailFieldShouldNotAllowExtraniousInputs : OxburyBannerCheck
{
    private string pageUrl;

        public EmailFieldShouldNotAllowExtraniousInputs(SeleniumDevice device, string pageUrl) : base(device)
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
        public void EmailFieldShouldNotAllowEmptyInputs()
        {
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "email", "");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
            BedAndBreakfastPage.CheckForCorrectAlert(Driver, "email should not be blank");
        }

        [Test]
        public void EmailFieldShouldNotAllowNoDomain()
        {
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "email", "dan@.com");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
            BedAndBreakfastPage.CheckForCorrectAlert(Driver, "must be a well-formed email address");
        }
        [Test]
        public void EmailFieldShouldNotAllowNoTopLevelDomain()
        {
            //this test fails but probably shouldn't, just lacking this validation on the FE
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "email", "dan@helloworld");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
            BedAndBreakfastPage.CheckForCorrectAlert(Driver, "must be a well-formed email address");
        }
        [Test]
        public void EmailFieldShouldNotAllowNoAtSymbol()
        {
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "email", "dan.com");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
            BedAndBreakfastPage.CheckForCorrectAlert(Driver, "must be a well-formed email address");
        }
    }
}