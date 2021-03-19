using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace QA_lab2
{
    class RegistrationPage
    {
        private readonly IWebDriver _driver;

        private IWebElement FirstName => _driver.FindElement(By.Id("FirstName"));

        private IWebElement LastName => _driver.FindElement(By.Id("LastName"));

        private IWebElement Email => _driver.FindElement(By.Id("Email"));

        private IWebElement Password => _driver.FindElement(By.Id("Password"));

        private IWebElement PasswordConfirmation => _driver.FindElement(By.Id("ConfirmPassword"));

        private IWebElement Submit => _driver.FindElement(By.Id("register-button"));

        public RegistrationPage(IWebDriver driver)
        {
            if (!driver.Url.Contains("register"))
                throw new ArgumentException("The page you`re looking for is invalid");
            _driver = driver;
        }
    }
}
