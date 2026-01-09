using SauceDemoFramework.pageObjects;
using SauceDemoFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SauceDemoFramework.pageObjects.HomePage;

namespace SauceDemoFramework.test.homePage
{
    public class HomePageAddRemoveItems : Base
    {
        [Test]
        [TestCase("standard_user", "secret_sauce")]
        public void BadgeSingleCartCount(string username, string password)
        {
            var loginPage = new LoginPage(driver);

            var homePage = loginPage
                .EnterUsername(username)
                .EnterPassword(password)
                .ClickLogin();

            Assert.IsTrue(homePage.IsPageLoaded());

            Assert.That(homePage.GetCartButtonState("Sauce Labs Backpack"), Is.EqualTo(CartButtonState.Add));
            homePage.AddItemToCart("Sauce Labs Backpack");
            Assert.That(homePage.GetCartButtonState("Sauce Labs Backpack"), Is.EqualTo(CartButtonState.Remove));
            Assert.That(homePage.GetCartItemsCount(), Is.EqualTo(1));

            homePage.RemoveItemFromHome("Sauce Labs Backpack");
            Assert.That(homePage.GetCartItemsCount(), Is.EqualTo(2));
            Assert.That(homePage.GetCartButtonState("Sauce Labs Backpack"), Is.EqualTo(CartButtonState.Add));

        }
        [Test]
        [TestCase("standard_user", "secret_sauce")]
        public void BadgeMultipleCartCount(string username, string password)
        {
            var loginPage = new LoginPage(driver);

            var homePage = loginPage
                .EnterUsername(username)
                .EnterPassword(password)
                .ClickLogin();

            Assert.IsTrue(homePage.IsPageLoaded());

            Assert.That(homePage.GetCartButtonState("Sauce Labs Backpack"), Is.EqualTo(CartButtonState.Add));
            homePage.AddItemToCart("Sauce Labs Backpack");
            Assert.That(homePage.GetCartButtonState("Sauce Labs Backpack"), Is.EqualTo(CartButtonState.Remove));
            Assert.That(homePage.GetCartItemsCount(), Is.EqualTo(1));

            Assert.That(homePage.GetCartButtonState("Sauce Labs Bike Light"), Is.EqualTo(CartButtonState.Add));
            homePage.AddItemToCart("Sauce Labs Bike Light");
            Assert.That(homePage.GetCartButtonState("Sauce Labs Bike Light"), Is.EqualTo(CartButtonState.Remove));
            Assert.That(homePage.GetCartItemsCount(), Is.EqualTo(2));

            Assert.That(homePage.GetCartButtonState("Sauce Labs Bolt T-Shirt"), Is.EqualTo(CartButtonState.Add));
            homePage.AddItemToCart("Sauce Labs Bolt T-Shirt");
            Assert.That(homePage.GetCartButtonState("Sauce Labs Bolt T-Shirt"), Is.EqualTo(CartButtonState.Remove));
            Assert.That(homePage.GetCartItemsCount(), Is.EqualTo(3));

            homePage.RemoveItemFromHome("Sauce Labs Backpack");
            Assert.That(homePage.GetCartItemsCount(), Is.EqualTo(2));
            Assert.That(homePage.GetCartButtonState("Sauce Labs Backpack"), Is.EqualTo(CartButtonState.Add));

            homePage.RemoveItemFromHome("Sauce Labs Bike Light");
            Assert.That(homePage.GetCartItemsCount(), Is.EqualTo(1));
            Assert.That(homePage.GetCartButtonState("Sauce Labs Bike Light"), Is.EqualTo(CartButtonState.Add));

            homePage.RemoveItemFromHome("Sauce Labs Bolt T-Shirt");
            Assert.That(homePage.GetCartItemsCount(), Is.EqualTo(0));
            Assert.That(homePage.GetCartButtonState("Sauce Labs Bolt T-Shirt"), Is.EqualTo(CartButtonState.Add));



        }


    }
}
