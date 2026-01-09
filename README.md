**SauceDemo Automation Framework**

UI test automation framework for https://www.saucedemo.com/, built using **C# and Selenium WebDriver**, following the **Page Object Model (POM)** design pattern and automation best practices.

---

**Project Overview**

This project automates end-to-end (E2E) scenarios for the **SauceDemo** web application, covering critical user flows such as:

- User login
- Product sorting
- Add / remove items from cart
- Complete checkout flow
- User personal information validation

The main goal of this framework is to be **scalable, maintainable, and easy to extend**, making it suitable as a **QA Automation portfolio project**.

---

**Technologies & Tools**

- **Language:** C#
- **Automation Tool:** Selenium WebDriver
- **Test Framework:** NUnit
- **Design Pattern:** Page Object Model (POM)
- **Configuration:** appsettings.json
- **IDE:** Visual Studio

---

**Project Structure**

SauceDemoFramework
│
├── config
│   └── ConfigManager.cs        # Configuration handling
│
├── pageObjects                 # Page Object classes
│   ├── BasePage.cs
│   ├── LoginPage.cs
│   ├── HomePage.cs
│   ├── CartPage.cs
│   ├── OverviewPage.cs
│   ├── CompletePage.cs
│   └── PersonalInfoPage.cs
│
├── test                        # Test cases
│   ├── cart
│   │   └── Cart.cs
│   │
│   ├── E2E
│   │   └── E2E.cs
│   │
│   ├── homePage
│   │   ├── HomePageAddRemoveItems.cs
│   │   └── HomePageSortTest.cs
│   │
│   ├── login
│   │   └── LoginTest.cs
│   │
│   └── personalInfo
│       └── PersonalInfo.cs
│
├── utilities
│   └── Base.cs                 # Test setup and teardown
│
├── appsettings.json            # Global configuration
└── Usings.cs                   # Global usings
