using SauceDemoFramework.pageObjects;
using SauceDemoFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoFramework.test.personalInfo
{
    public class PersonalInfoErrors : Base
    {
        [Test]
        [TestCase("standard_user", "secret_sauce")]
        public void PostalCodeErrorMessage(string username, string password)
        {
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
                    .EnterLastName("Bazan");

                personalInfoPage.ClickContinue();

                Assert.IsTrue(personalInfoPage.IsErrorDisplayed());
                Assert.That(personalInfoPage.GetErrorMessage(), Is.EqualTo("Error: Postal Code is required"));
            }
        }

        [Test]
        [TestCase("standard_user", "secret_sauce")]
        public void FirstNameErrorMessage(string username, string password)
        {
            {
                var loginPage = new LoginPage(driver);

                var personalInfoPage = loginPage
                    .EnterUsername(username)
                    .EnterPassword(password)
                    .ClickLogin()
                    .AddItemToCart("Sauce Labs Backpack")
                    .ClickCartIcon()
                    .ClickCheckout()
                    .EnterLastName("Bazan")
                    .EnterPostalCode("66495");

                personalInfoPage.ClickContinue();

                Assert.IsTrue(personalInfoPage.IsErrorDisplayed());
                Assert.That(personalInfoPage.GetErrorMessage(), Is.EqualTo("Error: First Name is required"));
            }
        }

        [Test]
        [TestCase("standard_user", "secret_sauce")]
        public void LastNameErrorMessage(string username, string password)
        {
            {
                var loginPage = new LoginPage(driver);

                var personalInfoPage = loginPage
                    .EnterUsername(username)
                    .EnterPassword(password)
                    .ClickLogin()
                    .AddItemToCart("Sauce Labs Backpack")
                    .ClickCartIcon()
                    .ClickCheckout()
                    .EnterFirstName("Nicolas")
                    .EnterPostalCode("66495");

                personalInfoPage.ClickContinue();

                Assert.IsTrue(personalInfoPage.IsErrorDisplayed());
                Assert.That(personalInfoPage.GetErrorMessage(), Is.EqualTo("Error: Last Name is required"));
            }
        }
    }
}
