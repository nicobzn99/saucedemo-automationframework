using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoFramework.pageObjects
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        private By cartItems = By.ClassName("cart_item");

        private By itemName = By.ClassName("inventory_item_name");
        private By itemPrice = By.ClassName("inventory_item_price");
        private By itemDesc = By.ClassName("inventory_item_desc");

        private By continueShoppingButton = By.Id("continue-shopping");
        private By checkoutButton = By.Id("checkout");
        private By removeItemButton = By.XPath(".//button[text()='Remove']");

        public int GetItemsCount()
        {
            return driver.FindElements(cartItems).Count;
        }

        public bool IsCartEmpty()
        {
            return GetItemsCount() == 0;
        }
        private IWebElement GetCartItemByName(string name)
        {
            foreach (var item in driver.FindElements(cartItems))
            {
                var currentName = item.FindElement(itemName).Text;

                if (currentName.Equals(name))
                {
                    return item;
                }
            }

            throw new Exception($"Item '{name}' no encontrado en el carrito");
        }

        public CartPage RemoveItem(string itemName)
        {
            var item = GetCartItemByName(itemName);

            var removeButton = WaitForChildElementVisible(item, removeItemButton);
            removeButton.Click();

            WaitForElementToDisappear(item);

            return this;
        }
        public List<string> GetItemNames()
        {
            if (!IsElementPresent(itemName))
            {
                return new List<string>();
            }

            var elements = WaitForElementsPresent(itemName);

            return elements
                .Select(e => e.Text)
                .ToList();
        }
        public decimal GetItemPrice(string name)
        {
            var item = GetCartItemByName(name);
            var priceElement = WaitForChildElementVisible(item, itemPrice);
            var priceText = priceElement.Text.Replace("$", "");
            return decimal.Parse(priceText, CultureInfo.InvariantCulture);
        }


        public HomePage ClickContinueShopping()
        {
            Click(continueShoppingButton);
            WaitForUrlContains("inventory");

            return new HomePage(driver);
        }
        public PersonalInfoPage ClickCheckout()
        {
            Click(checkoutButton);
            WaitForUrlContains("checkout");

            return new PersonalInfoPage(driver);
        }

        public LoginPage Logout()
        {
            ClickLogoutFromMenu();
            return new LoginPage(driver);
        }

    }
}
