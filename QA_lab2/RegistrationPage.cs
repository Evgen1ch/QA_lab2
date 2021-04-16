using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;

namespace QA_lab2
{
    class RegistrationPage: DemoWebShopPage
    {
        private static string LocalPath = "/register";

        private IWebElement FirstName => _driver.FindElement(By.Id("FirstName"));

        private IWebElement LastName => _driver.FindElement(By.Id("LastName"));

        private IWebElement Email => _driver.FindElement(By.Id("Email"));

        private IWebElement Password => _driver.FindElement(By.Id("Password"));

        private IWebElement PasswordConfirmation => _driver.FindElement(By.Id("ConfirmPassword"));

        private IWebElement SubmitBtn => _driver.FindElement(By.Id("register-button"));

        public RegistrationPage(IWebDriver driver) : base(driver, LocalPath) { }

        private void RegisterUser(User user)
        {
            FirstName.SendKeys(user.FirstName);
            LastName.SendKeys(user.LastName);
            Email.SendKeys(user.Email);
            Password.SendKeys(user.Password);
            PasswordConfirmation.SendKeys(user.Password);
            SubmitBtn.Click();
        }

        public RegisterResultPage RegisterUserSuccess(User user)
        {
            RegisterUser(user);
            return new RegisterResultPage(_driver);
        }

        public RegistrationPage RegisterUserFail(User user)
        {
            RegisterUser(user);
            return new RegistrationPage(_driver);
        }

        //If password is shorter than 6 characters
        public RegistrationPage CheckPasswordErrorMessage()
        {
            var errorSpan = _driver.FindElement(By.XPath("//span[@data-valmsg-for='Password']/span"));
            Assert.IsTrue(errorSpan.Displayed);
            return this;
        }
    }
}
