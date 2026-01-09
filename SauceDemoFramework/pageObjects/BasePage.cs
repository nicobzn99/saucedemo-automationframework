using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoFramework.pageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected void Type(By locator, string text)
        {
            var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            element.Clear();
            element.SendKeys(text);
        }

        protected void Click(By locator)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }

        protected string GetText(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator)).Text;
        }

        protected IWebElement WaitForElementVisible(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected IWebElement WaitForElementClickable(By locator)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        protected bool WaitForUrlContains(string text)
        {
            return wait.Until(ExpectedConditions.UrlContains(text));
        }
        protected void WaitForElementText(By locator, string text)
        {
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }

        protected bool IsElementPresent(By locator, int seconds = 2)
        {
            try
            {
                var shortWait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                shortWait.Until(ExpectedConditions.ElementExists(locator));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        protected bool IsElementVisible(By locator, int seconds = 5)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        protected IReadOnlyCollection<IWebElement> WaitForElementsPresent(By locator)
        {
            return wait.Until(driver =>
            {
                var elements = driver.FindElements(locator);
                return elements.Count > 0 ? elements : null;
            });
        }


        protected IWebElement WaitForChildElementVisible(IWebElement parent, By childLocator)
        {
            return wait.Until(_ =>
            {
                try
                {
                    var element = parent.FindElement(childLocator);
                    return element.Displayed ? element : null;
                }
                catch
                {
                    return null;
                }
            });
        }

        protected void WaitForElementToDisappear(IWebElement element)
        {
            wait.Until(driver =>
            {
                try
                {
                    return !element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            });
        }

        protected void WaitForElementToDisappear(By locator)
        {
            wait.Until(driver =>
            {
                try
                {
                    return !driver.FindElements(locator).Any();
                }
                catch
                {
                    return true;
                }
            });
        }

        // Side Menu locators
        protected By menuButton = By.Id("react-burger-menu-btn");
        protected By closeMenuButton = By.Id("react-burger-cross-btn");
        protected By allItemsLink = By.Id("inventory_sidebar_link");
        protected By aboutLink = By.Id("about_sidebar_link");
        protected By logoutLink = By.Id("logout_sidebar_link");
        protected By resetAppStateLink = By.Id("reset_sidebar_link");

        // Side Menu actions
        protected void OpenSideMenu()
        {
            Click(menuButton);
        }

        protected void CloseSideMenu()
        {
            Click(closeMenuButton);
        }

        protected void ClickLogoutFromMenu()
        {
            OpenSideMenu();
            Click(logoutLink);
        }

        protected void ClickResetAppState()
        {
            OpenSideMenu();
            Click(resetAppStateLink);
        }
    }

}
