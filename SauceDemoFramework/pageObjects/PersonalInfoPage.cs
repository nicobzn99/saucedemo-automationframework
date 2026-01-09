using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoFramework.pageObjects
{
    public class PersonalInfoPage : BasePage
    {
        public PersonalInfoPage(IWebDriver driver) : base(driver) { }

        private By firstName = By.Id("first-name");
        private By lastName = By.Id("last-name");
        private By zipCode = By.Id("postal-code");

        private By errorMessage = By.CssSelector("[data-test='error']");

        private By continueButton = By.Id("continue");

        public PersonalInfoPage EnterFirstName(string name)
        {
            Type(firstName, name);
            return this;
        }

        public PersonalInfoPage EnterLastName(string name)
        {
            Type(lastName, name);
            return this;
        }

        public PersonalInfoPage EnterPostalCode(string postalCode)
        {
            Type(zipCode, postalCode);
            return this;
        }

        public void ClickContinue()
        {
            Click(continueButton);
        }

        public bool IsErrorDisplayed()
        {
            return IsElementVisible(errorMessage);
        }

        public string GetErrorMessage()
        {
            return GetText(errorMessage);
        }

        public bool IsOnOverviewPage()
        {
            return driver.Url.Contains("step-two");
        }

        public string GetNameErrorMessage()
        {
            return GetText(errorMessage);
        }

        public LoginPage Logout()
        {
            ClickLogoutFromMenu();
            return new LoginPage(driver);
        }
    }
}
