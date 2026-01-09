using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoFramework.pageObjects
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        //Private Locators
        private By inventoryContainer = By.Id("inventory_container");
        private By cartIcon = By.ClassName("shopping_cart_link");
        private By dropDown = By.ClassName("product_sort_container");
        private By badge = By.ClassName("shopping_cart_badge");

        private By GetCartButton(string itemKey) =>
                By.XPath($"//div[@data-test='inventory-item-name' and text()='{itemKey}']" + "/ancestor::div[@class='inventory_item']//button");

        private By itemsName = By.CssSelector("div.inventory_item_name");
        private By itemsPrice = By.CssSelector("div.inventory_item_price");


        public enum CartButtonState
        {
            Add,
            Remove
        }

        public CartButtonState GetCartButtonState(string itemKey)
        {
            var button = WaitForElementVisible(GetCartButton(itemKey));

            return button.Text.Contains("Remove", StringComparison.OrdinalIgnoreCase)
                ? CartButtonState.Remove
                : CartButtonState.Add;
        }

        public bool IsPageLoaded()
        {
            try
            {
                return WaitForElementVisible(inventoryContainer).Displayed;
            }
            catch
            {
                return false;
            }
        }


        public HomePage AddItemToCart(string itemKey)
        {
            if (GetCartButtonState(itemKey) == CartButtonState.Add)
            {
                Click(GetCartButton(itemKey));
                WaitForElementText(GetCartButton(itemKey), "Remove");
            }

            return this;
        }

        public HomePage RemoveItemFromHome(string itemKey)
        {
            if (GetCartButtonState(itemKey) == CartButtonState.Remove)
            {
                Click(GetCartButton(itemKey));
                WaitForElementText(GetCartButton(itemKey), "Add to cart");
            }

            return this;
        }

        public int GetCartItemsCount()
        {
            if (!IsElementPresent(badge))
            {
                return 0;
            }

            var badgeElement = WaitForElementVisible(badge);
            return int.Parse(badgeElement.Text);
        }

        public List<string> GetItemNameList()
        {
            var items = WaitForElementsPresent(itemsName);

            return items.Select(item => item.Text).ToList();
        }

        public List<decimal> GetItemPriceList()
        {
            List<decimal> priceList = new List<decimal>();

            var items = WaitForElementsPresent(itemsPrice);

            foreach (var item in items)
            {
                string priceText = item.Text.Replace("$", "");

                priceList.Add(decimal.Parse(
                    priceText,
                    CultureInfo.InvariantCulture
                ));
            }

            return priceList;
        }

        public HomePage SelectSortOption(string value)
        {
            var dropdownElemnt = WaitForElementClickable(dropDown);
            var selectDropdown = new SelectElement(dropdownElemnt);
            selectDropdown.SelectByValue(value);

            return this;
        }


        public CartPage ClickCartIcon()
        {
            Click(cartIcon);
            WaitForUrlContains("cart");
            return new CartPage(driver);
        }
        public LoginPage Logout()
        {
            ClickLogoutFromMenu();
            return new LoginPage(driver);
        }

    }
}
