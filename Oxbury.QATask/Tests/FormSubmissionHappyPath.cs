using NUnit.Framework;
using Oxbury.QATask.SeleniumSetUp.Helpers;

namespace Oxbury.QATask.SeleniumSetUp
{
    [TestFixture(SeleniumDevice.ChromeDesktop, "https://automationintesting.online/")]
    [TestFixture(SeleniumDevice.EdgeDesktop, "https://automationintesting.online/")]
internal class FormSubmissionHappyPath : OxburyBannerCheck
{
    private string pageUrl;

        public FormSubmissionHappyPath(SeleniumDevice device, string pageUrl) : base(device)
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
        public void FormSubmissionWithExpectedValues()
        {
            //I would have liked to set up an XML file to avoid hard coding values here but didn't due to time constraints.
            BedAndBreakfastPage.ClickOnBookFormBtn(Driver);
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "firstname", "Dan");
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "lastname", "Hall");
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "email", "D.C@test.com");
            BedAndBreakfastPage.SendKeysToFormfield(Driver, "phone", "0123456789");
            BedAndBreakfastPage.ClickOnSubmitFormBtn(Driver);
        }
    }
}