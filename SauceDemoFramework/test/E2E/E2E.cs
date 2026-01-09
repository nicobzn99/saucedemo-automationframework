using SauceDemoFramework.pageObjects;
using SauceDemoFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SauceDemoFramework.pageObjects.HomePage;

namespace SauceDemoFramework.test.E2E
{
    public class E2E : Base
    {
        [Test]
        [TestCase("standard_user", "secret_sauce")]
        public void E2ETest(string username, string password)
        {
            var loginPage = new LoginPage(driver);

            var personalInfoPage = loginPage
                .EnterUsername(username)
                .EnterPassword(password)
                .ClickLogin()
                .AddItemToCart("Sauce Labs Backpack")
                .ClickCartIcon()
                .ClickCheckout()
                .EnterFirstName("Nico")
                .EnterLastName("Bazan")
                .EnterPostalCode("66741");

            personalInfoPage.ClickContinue();

            var overviewPage = new OverviewPage(driver);
            Assert.IsTrue(overviewPage.IsPageLoaded());

            overviewPage
                .ClicKFinishButton()
                .Logout();
        }
    }
}
