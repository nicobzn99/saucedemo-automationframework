using SauceDemoFramework.pageObjects;
using SauceDemoFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SauceDemoFramework.pageObjects.HomePage;

namespace SauceDemoFramework.test.cart
{
    public class Cart : Base
    {
        [Test]
        [TestCase("standard_user", "secret_sauce")]
        public void EmptyCart(string username, string password)
        {
            var loginPage = new LoginPage(driver);

            var homePage = loginPage
                .EnterUsername(username)
                .EnterPassword(password)
                .ClickLogin();

            Assert.IsTrue(homePage.IsPageLoaded());

            var cartPage = homePage.ClickCartIcon();

            Assert.That(cartPage.IsCartEmpty(), Is.True);

            cartPage.Logout();
        }

        [Test]
        [TestCase("standard_user", "secret_sauce")]
        public void CartSingleItem(string username, string password)
        {
            var loginPage = new LoginPage(driver);

            var homePage = loginPage
                .EnterUsername(username)
                .EnterPassword(password)
                .ClickLogin();

            Assert.IsTrue(homePage.IsPageLoaded());

            homePage.AddItemToCart("Sauce Labs Backpack");
            Assert.That(homePage.GetCartItemsCount(), Is.EqualTo(1));

            var cartPage = homePage.ClickCartIcon();

            Assert.That(cartPage.GetItemsCount(), Is.EqualTo(1));

            var expectedItems = new List<string>
            {
                "Sauce Labs Backpack"
            };
            var actualItems = cartPage.GetItemNames();

            Assert.That(cartPage.GetItemPrice("Sauce Labs Backpack"), Is.EqualTo(29.99m));
            CollectionAssert.AreEquivalent(expectedItems, actualItems);

            cartPage.RemoveItem("Sauce Labs Backpack");
            Assert.That(cartPage.GetItemsCount(), Is.EqualTo(0));

            cartPage.Logout();
        }
        [Test]
        [TestCase("standard_user", "secret_sauce")]
        public void CartMultipleItemsItem(string username, string password)
        {
            var loginPage = new LoginPage(driver);

            var homePage = loginPage
                .EnterUsername(username)
                .EnterPassword(password)
                .ClickLogin();

            Assert.IsTrue(homePage.IsPageLoaded());

            homePage
                .AddItemToCart("Sauce Labs Backpack")
                .AddItemToCart("Sauce Labs Bike Light")
                .AddItemToCart("Sauce Labs Onesie");
            Assert.That(homePage.GetCartItemsCount(), Is.EqualTo(3));

            var cartPage = homePage.ClickCartIcon();

            Assert.That(cartPage.GetItemsCount(), Is.EqualTo(3));

            var expectedItems = new List<string>
            {
                "Sauce Labs Backpack",
                "Sauce Labs Bike Light",
                "Sauce Labs Onesie"
            };
            var actualItems = cartPage.GetItemNames();

            Assert.That(cartPage.GetItemPrice("Sauce Labs Backpack"), Is.EqualTo(29.99m));
            Assert.That(cartPage.GetItemPrice("Sauce Labs Bike Light"), Is.EqualTo(9.99m));
            Assert.That(cartPage.GetItemPrice("Sauce Labs Onesie"), Is.EqualTo(7.99m));
            CollectionAssert.AreEquivalent(expectedItems, actualItems);

            cartPage
                .RemoveItem("Sauce Labs Backpack")
                .RemoveItem("Sauce Labs Bike Light")
                .RemoveItem("Sauce Labs Onesie");
            Assert.That(cartPage.GetItemsCount(), Is.EqualTo(0));

            cartPage.Logout();
        }
    }
}
