using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace ocp_test
{
    [Binding]
    public sealed class Hooks
    {
        private readonly PageContext _context;

        public Hooks(PageContext context)
        {
            _context = context;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Utility.demoMode = Debugger.IsAttached;
            Utility.productionMode = !Debugger.IsAttached;

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("headless");
            _context.Driver = Utility.productionMode ? new ChromeDriver(options) : new ChromeDriver();
            _context.Driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _context.Driver.Dispose();
        }
    }
}
