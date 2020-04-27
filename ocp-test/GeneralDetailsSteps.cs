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

        [Given(@"I on the (.*) Tab")]
        public void GivenIOnTheGeneralDetailsTab(string tabName)
        {
            _output.WriteLine("Hola");

            _context.CorporateRegistryServicesPage = CorporateRegistryServicesPage.NavigateTo(_context.Driver);

            switch (tabName)
            {
                case "General Details":
                    _context.CorporateRegistryServicesPage.ClickNextButton();
                    _context.CorporateRegistryServicesPage.InitializeGeneralDetailsElements();
                    break;
                case "Address":
                    _context.CorporateRegistryServicesPage.ClickNextButton();
                    Utility.Pause(300);
                    _context.CorporateRegistryServicesPage.ClickNextButton();
                    _context.CorporateRegistryServicesPage.InitializeAddressElements();
                    break;
                default:
                    break;
            }

            Utility.DemoPause();
        }

        [Given(@"I enter (.*) to (.*) field")]
        public void GivenIEnterSomethingToSomeField(string text, string fieldName)
        {
            switch (fieldName)
            {
                case "proposed name":
                    _context.CorporateRegistryServicesPage.SetName(text);
                    Utility.DemoPause();
                    break;
                case "bussiness activity":
                    _context.CorporateRegistryServicesPage.SetActivity(text);
                    Utility.DemoPause();
                    break;
                case "upload consents":
                    _context.CorporateRegistryServicesPage.SetConsents(text);
                    Utility.DemoPause();
                    break;
                case "upload letter":
                    _context.CorporateRegistryServicesPage.SetLetter(text);
                    Utility.DemoPause();
                    break;
                case "address1":
                    _context.CorporateRegistryServicesPage.SetAddress1(text);
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
                    _context.CorporateRegistryServicesPage.SelectEntity();
                    Utility.DemoPause();
                    break;
                default:
                    break;
            }
        }


        [Then(@"Radio button visibility should be (.*)")]
        public void ThenRadioButtonVisibilityShouldBe(bool visibility)
        {
            Assert.Equal(visibility, _context.CorporateRegistryServicesPage.IsConsentRadioVisible());
        }

        [Then(@"Upload consent visibility should be (.*)")]
        public void ThenUploadConsentShouldBeHidden(bool visibility)
        {
            Utility.DemoPause();
            Assert.Equal(visibility, _context.CorporateRegistryServicesPage.IsUploadConsentsVisible());
        }

        [Then(@"I should see new address is added")]
        public void ThenIShouldSeeNewAddressIsAdded()
        {
            Utility.DemoPause();
            Assert.Equal(1, _context.CorporateRegistryServicesPage.GetAddressesCount());
        }

    }
}
