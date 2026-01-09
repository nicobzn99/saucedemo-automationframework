using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoFramework.pageObjects
{
    public class OverviewPage : BasePage
    {
        public OverviewPage(IWebDriver driver) : base(driver) { }

        public By finishButton = By.Id("finish");
        private By pageTitle = By.ClassName("title");

        public CompletePage ClicKFinishButton()
        {
            Click(finishButton);
            return new CompletePage(driver);
        }

        public bool IsPageLoaded()
        {
            return driver.Url.Contains("step-two")
                && IsElementVisible(pageTitle)
                && GetText(pageTitle).Equals("Checkout: Overview");
        }

        public LoginPage Logout()
        {
            ClickLogoutFromMenu();
            return new LoginPage(driver);
        }

    }
}
