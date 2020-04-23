using OpenQA.Selenium;
namespace ocp_test
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private const string PageUri = "http://localhost:8080/";

        private IWebElement _registerButton;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;

            _registerButton = _driver.FindElement(By.Id("register"));
        }

        public static HomePage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);

            return new HomePage(driver);
        }

        public void ClickRegisterButton() => _registerButton.Click();
    }
}
