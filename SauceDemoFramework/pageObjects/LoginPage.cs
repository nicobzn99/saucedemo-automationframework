using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoFramework.pageObjects
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private By usernameInput = By.Id("user-name");
        private By passwordInput = By.Id("password");
        private By loginButton = By.Id("login-button");
        private By errorMessage = By.CssSelector("[data-test='error']");

        public LoginPage EnterUsername(string username)
        {
            Type(usernameInput, username);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            Type(passwordInput, password);
            return this;
        }

        public HomePage ClickLogin()
        {
            Click(loginButton);
            return new HomePage(driver);
        }

        public string GetErrorMessage()
        {
            return GetText(errorMessage);
        }
    }

}

