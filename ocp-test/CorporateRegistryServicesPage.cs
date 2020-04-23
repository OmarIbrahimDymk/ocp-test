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

        private IWebElement _checkbox;
        private IWebElement _saveBtn;
        private IWebElement _nextBtn;
        private IWebElement _checkboxWrapper;

        private IWebElement _name;
        private IWebElement _validateBtn;
        private IWebElement _businessActivitiy;
        private IWebElement _entitySelection;
        private IWebElement _radioYes;
        private IWebElement _radioGroup;
        private IWebElement _uploadConsents;
        private IWebElement _consentInput;
        private ReadOnlyCollection<IWebElement> _entitySelectionItems;

        WebDriverWait _wait;

        public CorporateRegistryServicesPage(IWebDriver driver)
        {
            _driver = driver;

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));

            _checkbox = _wait.Until((d) => d.FindElement(By.Id("checkbox")));
            _saveBtn = _wait.Until((d) => d.FindElement(By.Id("save")));
            _nextBtn = _wait.Until((d) => d.FindElement(By.Id("next")));
            _checkboxWrapper = _wait.Until((d) => d.FindElement(By.ClassName("v-input--selection-controls")));
        }

        public static CorporateRegistryServicesPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);
            return new CorporateRegistryServicesPage(driver);
        }

        public void initializeGeneralDetailsElements()
        {

            _name = _wait.Until((d) => d.FindElement(By.Id("name")));
            _validateBtn = _wait.Until((d) => d.FindElement(By.Id("validate")));
            _businessActivitiy = _wait.Until((d) => d.FindElement(By.Id("activity")));
            _entitySelection = _wait.Until((d) => d.FindElement(By.ClassName("v-select__selections")));
            _radioYes = _wait.Until((d) => d.FindElement(By.CssSelector(".v-radio.theme--light")));
            _radioGroup = _wait.Until((d) => d.FindElement(By.CssSelector("[role=radiogroup]")));
            _uploadConsents = _wait.Until((d) => d.FindElement(By.ClassName("v-file-input__text")));
            _consentInput = _wait.Until((d) => d.FindElement(By.Id("consents")));
        }

        public void ClickCheckBox() => _checkboxWrapper.Click();

        public HomePage ClickSaveButton()
        {
            _saveBtn.Click();

            return new HomePage(_driver);
        }

        public void ClickNextButton() => _nextBtn.Click();

        public void ClickValidateButton() => _validateBtn.Click();
        public void ClickConsent() => _uploadConsents.Click();

        public void ClickConsentButton()
        {
            _radioYes.Click();
        }

        public bool isCheckboxSelected() => _checkbox.Selected;
        public bool isNameVisible() => _name.Displayed;
        public bool isConsentRadioVisible() => _radioGroup.Displayed;
        public bool isUploadConsentsVisible() => _uploadConsents.Displayed;

        public void setName(string name) => _name.SendKeys(name);
        public void setConsents(string fileName) => _consentInput.SendKeys(fileName);
        public void setActivity(string activity) => _businessActivitiy.SendKeys(activity);

        public void selectEntity2()
        {
            var entity = _driver.FindElement(By.Id("entity"));
            var selectElement = new SelectElement(entity);

            selectElement.SelectByIndex(0);
        }

        public void selectEntity()
        {
            _entitySelection.Click();

            _entitySelectionItems = _driver.FindElements(By.ClassName("v-list-item__title"));
            Utility.DemoPause();
            _entitySelectionItems[0].Click();
        }
    }
}
