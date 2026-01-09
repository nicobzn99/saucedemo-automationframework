using OpenQA.Selenium;
using SauceDemoFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoFramework.pageObjects
{
    public class CompletePage : BasePage
    {
        public CompletePage(IWebDriver driver) : base(driver) { }

        public By completeButton = By.Id("back-to-products");

        public HomePage ClickCompleteButton()
        {
            Click(completeButton);
            return new HomePage(driver);
        }

        public LoginPage Logout()
        {
            ClickLogoutFromMenu();
            return new LoginPage(driver);
        }
    }
}
