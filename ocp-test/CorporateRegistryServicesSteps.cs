using TechTalk.SpecFlow;
using Xunit;

namespace ocp_test
{
    [Binding]
    public class CorporateRegistryServicesSteps
    {
        private readonly PageContext _context;

        public CorporateRegistryServicesSteps(PageContext context)
        {
            _context = context;
        }

        [Given(@"I am on the Register Business Name screen")]
        public void GivenIAmOnTheRegisterBusinessNameScreen()
        {
            _context.CorporateRegistryServicesPage = CorporateRegistryServicesPage.NavigateTo(_context.Driver);
            Utility.DemoPause();
        }

        [Given(@"I am redirected to Home screen")]
        public void GivenIAmRedirectedToHomeScreen()
        {
            Utility.Pause();
            _context.HomePage = new HomePage(_context.Driver);
            Assert.Equal("Home Page", _context.Driver.Title);
            Utility.DemoPause();
        }

        [When(@"I am redirected to Register Business Name screen")]
        public void WhenIAmRedirectedToRegisterBusinessNameScreen()
        {
            Utility.Pause();
            _context.CorporateRegistryServicesPage = new CorporateRegistryServicesPage(_context.Driver);
            Assert.Equal("Corporate Registry Services", _context.Driver.Title);
            Utility.DemoPause();
        }


        [Then(@"I should see the checkbox is checked")]
        public void ThenIShouldSeeTheCheckboxIsChecked()
        {
            Utility.Pause();
            Assert.True(_context.CorporateRegistryServicesPage.IsCheckboxSelected());
            Utility.DemoPause();
        }

        [When(@"I fill all the required fields")]
        public void WhenIFillAllTheRequiredFields()
        {
            Utility.DemoPause();
            _context.CorporateRegistryServicesPage.InitializeGeneralDetailsElements();
            _context.CorporateRegistryServicesPage.SetName("My Company");
            Utility.DemoPause();
            _context.CorporateRegistryServicesPage.ClickValidateButton();
            Utility.DemoPause();
            _context.CorporateRegistryServicesPage.SelectEntity();
            Utility.DemoPause();
        }
    }
}
