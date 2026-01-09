using AngleSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SauceDemoFramework.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SauceDemoFramework.utilities
{
    public class Base
    {
        public IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            String browserName = ConfigManager.Browser;

            InitBrowser(browserName);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = ConfigManager.BaseUrl;
        }

        public void InitBrowser( string browserName)
        {
            switch (browserName)
            {
                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    ChromeOptions options = new ChromeOptions();

                    // 2. Add user profile preferences to disable password management pop-ups
                    // Disables the "Save password?" prompt
                    options.AddUserProfilePreference("credentials_enable_service", false);
                    // Disables the password manager entirely
                    options.AddUserProfilePreference("profile.password_manager_enabled", false);
                    // Disables the "password found in a data breach" warning (for newer Chrome versions)
                    options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver(options);
                    break;


            }
        }

        [TearDown]
        public void StopBrowser() 
        {
            driver.Quit();
        }
    }
}
