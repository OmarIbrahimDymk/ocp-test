using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace ocp_test
{
    public class CorporateRegistryServicesTests
    {
        [Fact]
        public void GoToCorporateRegistryServicesPage()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("headless");
            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://localhost:8080/");

                IWebElement registerButton = driver.FindElement(By.Id("register"));

                Assert.Equal("Home Page", driver.Title);

                registerButton.Click();

                Utility.Pause();

                Assert.Equal("Corporate Registry Services", driver.Title);
            }
        }

        [Fact]
        public void DeclareReadImportantMessage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://localhost:8080/");

                IWebElement registerButton = driver.FindElement(By.Id("register"));

                registerButton.Click();

                Utility.Pause();

                IWebElement checkbox = driver.FindElement(By.ClassName("v-input--selection-controls"));

                checkbox.Click();

                Assert.Equal("Corporate Registry Services", driver.Title);
            }
        }

        [Fact]
        public void CancelRegistration()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://localhost:8080/");

                IWebElement registerButton = driver.FindElement(By.Id("register"));

                registerButton.Click();

                Utility.Pause();

                IWebElement checkbox = driver.FindElement(By.ClassName("v-input--selection-controls"));

                checkbox.Click();

                IWebElement cancelButton = driver.FindElement(By.Id("cancel"));

                cancelButton.Click();


                Assert.Equal("Home Page", driver.Title);
            }
        }

        [Fact]
        public void EnterProposedName()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("headless");
            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://localhost:8080/");

                IWebElement registerButton = driver.FindElement(By.Id("register"));

                registerButton.Click();

                Utility.Pause(100);

                IWebElement checkbox = driver.FindElement(By.ClassName("v-input--selection-controls"));

                checkbox.Click();

                IWebElement nextButton = driver.FindElement(By.Id("next"));

                nextButton.Click();

                Utility.Pause();

                IWebElement proposedName = driver.FindElement(By.Id("name"));

                proposedName.SendKeys("AyamKu");
            }
        }
    }
}
