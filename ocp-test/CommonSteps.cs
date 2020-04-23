using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace ocp_test
{
    [Binding]
    public sealed class CommonSteps
    {
        private readonly PageContext _context;

        public CommonSteps(PageContext context)
        {
            _context = context;
        }

        [Given(@"I click the (.*) button")]
        [When(@"I click the (.*) button")]
        [Then(@"I click the (.*) button")]
        public void GivenIClickThe(string buttonName)
        {
            //Utility.Pause(100);
            switch (buttonName)
            {
                case "next":
                    _context.CorporateRegistryServicesPage.ClickNextButton();
                    break;
                case "validate":
                    _context.CorporateRegistryServicesPage.ClickValidateButton();
                    Utility.DemoPause();
                    break;
                case "save":
                    _context.CorporateRegistryServicesPage.ClickSaveButton();
                    break;
                case "checkbox":
                    _context.CorporateRegistryServicesPage.ClickCheckBox();
                    Utility.DemoPause();
                    break;
                case "consent":
                    _context.CorporateRegistryServicesPage.ClickConsentButton();
                    Utility.DemoPause();
                    break;
                case "register":
                    _context.HomePage.ClickRegisterButton();
                    break;
                default:
                    break;
            }
        }

        [Given(@"I scroll (.*) for (.*) pixel")]
        [Given(@"I scroll (.*) for (.*) pixel")]
        [Given(@"I scroll (.*) for (.*) pixel")]
        public void GivenIScrollDownForPixel(string direction, int pixels)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_context.Driver;
            js.ExecuteScript($"window.scrollBy(0,{pixels})");
            Utility.DemoPause();
        }

    }
}
