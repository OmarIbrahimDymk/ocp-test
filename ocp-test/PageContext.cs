using OpenQA.Selenium;

namespace ocp_test
{
    public class PageContext
    {
        public IWebDriver Driver { get; set; }
        public HomePage HomePage { get; set; }

        public CorporateRegistryServicesPage CorporateRegistryServicesPage { get; set; }
    }
}
