using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace QA_lab2
{
    class MainPage: DemoWebShopPage
    {
        
        private static string URL_MATCH = "/";

        private IWebElement Register => _driver.FindElement(By.LinkText("Register"));

        private IWebElement Books => _driver.FindElement(By.LinkText("Books"));

        private IWebElement Account => _driver.FindElement(By.ClassName("account"));

        private IWebElement LogIn => _driver.FindElement(By.ClassName("ico-login"));

        private IWebElement LogOut => _driver.FindElement(By.ClassName("ico-logout"));

        public MainPage(IWebDriver driver): base(driver, URL_MATCH) { }

        public BooksPage GoToBooksPage()
        {
            Books.Click();
            return new BooksPage(_driver);
        }

        public LoginPage GoToLogin()
        {
            LogIn.Click();
            return new LoginPage(_driver);
        }

        public RegistrationPage GoToRegistration()
        {
            Register.Click();
            return new RegistrationPage(_driver);
        }

        public MainPage ClickLogOut()
        {
            LogOut.Click();
            return new MainPage(_driver);
        }

        public void CheckEmailMatch(string expectedEmail)
        {
            Assert.AreEqual(expectedEmail, Account.Text);
        }

        public void CheckLogoutSuccess()
        {
            Assert.IsTrue(LogIn.Displayed);
        }
    }
}
