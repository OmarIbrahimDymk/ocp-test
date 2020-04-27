using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace ocp_test
{
    public class CorporateRegistryServicesPage
    {
        private readonly IWebDriver _driver;
        private const string PageUri = "http://localhost:8080/register";
        WebDriverWait _wait;

        // CRS Page
        private string _saveBtn = "save";
        private string _nextBtn = "next";
        private string _checkboxWrapper = "v-input--selection-controls";

        // Important Info Tab
        private string _checkbox = "checkbox";

        // General Details Tab
        private string _name = "name";
        private string _validateBtn = "validate";
        private string _businessActivitiy = "activity";
        private string _entitySelection = "v-select__selections";
        private string _radioYes = ".v-radio.theme--light";
        private string _radioGroup = "[role=radiogroup]";
        private string _uploadConsents = "v-file-input__text";
        private string _consentInput = "consents";
        private string _letterInput = "letter";

        // Address Tab
        private string _address1 = "address1";
        private string _addAddressBtn = "addAddress";

        public CorporateRegistryServicesPage(IWebDriver driver)
        {
            _driver = driver;

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        public static CorporateRegistryServicesPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);
            return new CorporateRegistryServicesPage(driver);
        }

        public void ClickCheckBox() => _wait.Until((d) => d.FindElement(By.ClassName(_checkboxWrapper))).Click();

        public HomePage ClickSaveButton()
        {
            _wait.Until((d) => d.FindElement(By.Id(_saveBtn))).Click();

            return new HomePage(_driver);
        }

        public void ClickNextButton() => _wait.Until((d) => d.FindElement(By.Id(_nextBtn))).Click();

        public void ClickValidateButton() => _wait.Until((d) => d.FindElement(By.Id(_validateBtn))).Click();
        public void ClickConsent() => _wait.Until((d) => d.FindElement(By.ClassName(_uploadConsents))).Click();

        public void ClickConsentButton() => _wait.Until((d) => d.FindElement(By.CssSelector(_radioYes))).Click();
        public void ClickAddAddressButton() => _wait.Until((d) => d.FindElement(By.Id(_addAddressBtn))).Click();

        public bool IsCheckboxSelected() => _wait.Until((d) => d.FindElement(By.Id(_checkbox))).Selected;
        public bool IsNameVisible() => _wait.Until((d) => d.FindElement(By.Id(_name))).Displayed;
        public bool IsConsentRadioVisible() => _wait.Until((d) => d.FindElement(By.CssSelector(_radioGroup))).Displayed;
        public bool IsUploadConsentsVisible() => _wait.Until((d) => d.FindElement(By.ClassName(_uploadConsents))).Displayed;

        public void SetName(string name) => _wait.Until((d) => d.FindElement(By.Id(_name))).SendKeys(name);
        public void SetConsents(string fileName) => _wait.Until((d) => d.FindElement(By.Id(_consentInput))).SendKeys(fileName);
        public void SetLetter(string fileName) => _wait.Until((d) => d.FindElement(By.Id(_letterInput))).SendKeys(fileName);
        public void SetActivity(string activity) => _wait.Until((d) => d.FindElement(By.Id(_businessActivitiy))).SendKeys(activity);
        public void SetAddress1(string activity) => _wait.Until((d) => d.FindElement(By.Id(_address1))).SendKeys(activity);

        public void SelectEntity2()
        {
            var entity = _driver.FindElement(By.Id("entity"));
            var selectElement = new SelectElement(entity);

            selectElement.SelectByIndex(0);
        }

        public void SelectEntity()
        {
            _wait.Until((d) => d.FindElement(By.ClassName(_entitySelection))).Click();

            ReadOnlyCollection<IWebElement> _entitySelectionItems = _driver.FindElements(By.ClassName("v-list-item__title"));
            Utility.DemoPause();
            _entitySelectionItems[0].Click();
        }

        public int GetAddressesCount() => _wait.Until((d) => d.FindElements(By.ClassName("address"))).Count;
    }
}
