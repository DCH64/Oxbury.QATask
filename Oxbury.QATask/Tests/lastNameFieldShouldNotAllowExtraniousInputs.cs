using NUnit.Framework;
using Oxbury.QATask.SeleniumSetUp.Helpers;

namespace Oxbury.QATask.SeleniumSetUp
{
    [TestFixture(SeleniumDevice.ChromeDesktop, "https://automationintesting.online/")]
    [TestFixture(SeleniumDevice.EdgeDesktop, "https://automationintesting.online/")]
internal class FormNameFieldShouldAllowGenericNames : OxburyBannerCheck
{
    private string pageUrl;

        public FormNameFieldShouldAllowGenericNames(SeleniumDevice device, string pageUrl) : base(device)
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
        public void FirstNameFieldShouldNotAllowEmptyInputs()
        {
            //An unfinished test to confirm the correct empty field error is shown
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "firstname", "");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
            BedAndBreakfastPage.CheckForCorrectAlert(Driver, "Firstname should not be blank");
        }

        [Test]
        public void LastNameFieldShouldNotAllowEmptyInputs()
        {
            //An unfinished test to confirm the correct empty field error is shown
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "lastname", "");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
            BedAndBreakfastPage.CheckForCorrectAlert(Driver, "Lastname should not be blank");
        }
    }
}