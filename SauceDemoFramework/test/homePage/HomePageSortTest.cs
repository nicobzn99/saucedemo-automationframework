using SauceDemoFramework.pageObjects;
using SauceDemoFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoFramework.test.homePage
{
    public class Tests : Base
    {

        [Test]
        [TestCase("standard_user", "secret_sauce")]
        public void SortAtoZ(string username, string password)
        {
            var loginPage = new LoginPage(driver);

            var homePage = loginPage
                .EnterUsername(username)
                .EnterPassword(password)
                .ClickLogin();

            Assert.IsTrue(homePage.IsPageLoaded());

            var sortedlList = homePage.GetItemNameList();

            Assert.That(sortedlList, Is.Ordered.Ascending);
        }

        [Test]
        [TestCase("standard_user", "secret_sauce", "za")]
        public void SortZtoA(string username, string password, string sortOption)
        {
            var loginPage = new LoginPage(driver);

            var homePage = loginPage
                .EnterUsername(username)
                .EnterPassword(password)
                .ClickLogin();

            Assert.IsTrue(homePage.IsPageLoaded());

            homePage.SelectSortOption(sortOption);
            var sortedlList = homePage.GetItemNameList();

            Assert.That(sortedlList, Is.Ordered.Descending);
        }

        [Test]
        [TestCase("standard_user", "secret_sauce", "lohi")]
        public void PriceLowToHigh(string username, string password, string sortOption)
        {
            var loginPage = new LoginPage(driver);

            var homePage = loginPage
                .EnterUsername(username)
                .EnterPassword(password)
                .ClickLogin();

            Assert.IsTrue(homePage.IsPageLoaded());

            homePage.SelectSortOption(sortOption);
            var sortedlList = homePage.GetItemPriceList();

            Assert.That(sortedlList, Is.Ordered.Ascending);
        }

        [Test]
        [TestCase("standard_user", "secret_sauce", "hilo")]
        public void PriceHighToLow(string username, string password, string sortOption)
        {
            var loginPage = new LoginPage(driver);

            var homePage = loginPage
                .EnterUsername(username)
                .EnterPassword(password)
                .ClickLogin();

            Assert.IsTrue(homePage.IsPageLoaded());

            homePage.SelectSortOption(sortOption);
            var sortedlList = homePage.GetItemPriceList();

            Assert.That(sortedlList, Is.Ordered.Descending);
        }
    }
}
