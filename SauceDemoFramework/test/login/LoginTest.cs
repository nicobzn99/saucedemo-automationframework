using AngleSharp.Dom;
using SauceDemoFramework.config;
using SauceDemoFramework.pageObjects;
using SauceDemoFramework.utilities;

namespace SauceDemoFramework.test.login
{
    public class Tests : Base
    {

        [Test]
        [TestCase("standard_user", "standard_user")]
        public void ValidLogin(string username, string password)
        {
            var loginPage = new LoginPage(driver);

            var homePage = loginPage
                .EnterUsername(username)
                .EnterPassword(password)
                .ClickLogin();

            Assert.IsTrue(homePage.IsPageLoaded());


        }
        [Test]
        [TestCase("standard_user", "Badpass")]
        public void InvalidLogin(string username, string password)
        {
            var loginPage = new LoginPage(driver);

            loginPage
                .EnterUsername(username)
                .EnterPassword(password)
                .ClickLogin();

            var errorMessage = loginPage.GetErrorMessage();

            Assert.That(errorMessage, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));

        }


    }

}