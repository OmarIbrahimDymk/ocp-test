using TechTalk.SpecFlow;
using Xunit;

namespace ocp_test
{
    [Binding]
    public class HomeSteps
    {
        private readonly PageContext _context;

        public HomeSteps(PageContext context)
        {
            _context = context;
        }

        [Given(@"I am on the home screen")]
        public void GivenIAmOnTheHomeScreen()
        {
            _context.HomePage = HomePage.NavigateTo(_context.Driver);

            Assert.Equal("Home Page", _context.Driver.Title);

            Utility.DemoPause();
        }

        [Then(@"I am redirected to Corporate Registry Services")]
        public void ThenIAmRedirectedToCorporateRegistryServices()
        {
            Assert.Equal("Corporate Registry Services", _context.Driver.Title);

            Utility.DemoPause();
        }
    }
}
