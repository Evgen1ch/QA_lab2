using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace QA_lab2
{
    class LoginPage: DemoWebShopPage
    {
        private static string URL_MATCH = "/login";

        private IWebElement Email => _driver.FindElement(By.Id("Email"));

        private IWebElement Password => _driver.FindElement(By.Id("Password"));

        private IWebElement Submit => _driver.FindElement(By.ClassName("login-button"));

        private IWebElement ErrorMessage =>
            _driver.FindElement(By.XPath("//div[@class='validation-summary-errors']/span"));
        public LoginPage(IWebDriver driver) : base(driver, URL_MATCH) { }

        public LoginPage TypeEmail(string email)
        {
            Email.SendKeys(email);
            return this;
        }

        public LoginPage TypePassword(string password)
        {
            Password.SendKeys(password);
            return this;
        }

        public LoginPage LoginFail()
        {
            Submit.Click();
            return new LoginPage(_driver);
        }

        public MainPage LoginSuccess()
        {
            Submit.Click();
            return new MainPage(_driver);
        }

        public LoginPage CheckErrorMessage()
        {
            Assert.IsTrue(ErrorMessage.Displayed);
            return this;
        }
    }
}
