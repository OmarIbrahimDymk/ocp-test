using TechTalk.SpecFlow;
using Xunit;
using Xunit.Abstractions;

namespace ocp_test
{
    [Binding]
    public class GeneralDetailsSteps
    {
        private readonly PageContext _context;
        private readonly ITestOutputHelper _output;

        public GeneralDetailsSteps(PageContext context, ITestOutputHelper output)
        {
            _context = context;
            _output = output;
        }

        [Given(@"I on the General Details Tab")]
        public void GivenIOnTheGeneralDetailsTab()
        {
            _output.WriteLine("Hola");

            _context.CorporateRegistryServicesPage = CorporateRegistryServicesPage.NavigateTo(_context.Driver);
            _context.CorporateRegistryServicesPage.ClickNextButton();

            _context.CorporateRegistryServicesPage.initializeGeneralDetailsElements();

            Utility.DemoPause();
        }

        [Given(@"I enter (.*) to (.*) field")]
        public void GivenIEnterSomethingToSomeField(string text, string fieldName)
        {
            switch (fieldName)
            {
                case "proposed name":
                    _context.CorporateRegistryServicesPage.setName(text);
                    Utility.DemoPause();
                    break;
                case "bussiness activity":
                    _context.CorporateRegistryServicesPage.setActivity(text);
                    Utility.DemoPause();
                    break;
                case "upload consents":
                    _context.CorporateRegistryServicesPage.setConsents(text);
                    Utility.DemoPause();
                    break;
                case "upload letter":
                    _context.CorporateRegistryServicesPage.setLetter(text);
                    Utility.DemoPause();
                    break;
                default:
                    break;
            }
        }

        [Given(@"I select (.*)")]
        public void GivenISelectEntityType(string selection)
        {
            switch (selection)
            {
                case "entity type":
                    _context.CorporateRegistryServicesPage.selectEntity();
                    Utility.DemoPause();
                    break;
                default:
                    break;
            }
        }


        [Then(@"Radio button visibility should be (.*)")]
        public void ThenRadioButtonVisibilityShouldBe(bool visibility)
        {
            Assert.Equal(visibility, _context.CorporateRegistryServicesPage.isConsentRadioVisible());
        }

        [Then(@"Upload consent visibility should be (.*)")]
        public void ThenUploadConsentShouldBeHidden(bool visibility)
        {
            Utility.DemoPause();
            Assert.Equal(visibility, _context.CorporateRegistryServicesPage.isUploadConsentsVisible());
        }
    }
}
