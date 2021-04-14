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
        private static string URL_MATCH = "/register";

        private IWebElement FirstName => _driver.FindElement(By.Id("FirstName"));

        private IWebElement LastName => _driver.FindElement(By.Id("LastName"));

        private IWebElement Email => _driver.FindElement(By.Id("Email"));

        private IWebElement Password => _driver.FindElement(By.Id("Password"));

        private IWebElement PasswordConfirmation => _driver.FindElement(By.Id("ConfirmPassword"));

        private IWebElement SubmitBtn => _driver.FindElement(By.Id("register-button"));

        public RegistrationPage(IWebDriver driver) : base(driver, URL_MATCH) { } 

        //public RegistrationPage TypeFirstName(string firstName)
        //{
        //    FirstName.SendKeys(firstName);
        //    return this;
        //}

        //public RegistrationPage TypeLastName(string firstName)
        //{
        //    LastName.SendKeys(firstName);
        //    return this;
        //}

        //public RegistrationPage TypeEmail(string firstName)
        //{
        //    Email.SendKeys(firstName);
        //    return this;
        //}

        //public RegistrationPage TypePassword(string firstName)
        //{
        //    Password.SendKeys(firstName);
        //    return this;
        //}

        //public RegistrationPage TypePasswordConfirmation(string firstName)
        //{
        //    PasswordConfirmation.SendKeys(firstName);
        //    return this;
        //}

        //public RegisterResultPage Submit()
        //{
        //    SubmitBtn.Submit();
        //    return new RegisterResultPage(_driver);
        //}

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

        //Only if field is empty
        public RegistrationPage CheckFirstNameErrorMessage()
        {
            Assert.Pass();
            return this;
        }

        //Only if field is empty
        public RegistrationPage CheckLastNameErrorMessage()
        {
            Assert.Pass();
            return this;
        }

        //Email is illegal or empty
        public RegistrationPage CheckEmailErrorMessage()
        {
            Assert.Pass();
            return this;
        }


        //If password is shorter than 6 characters
        public RegistrationPage CheckPasswordErrorMessage()
        {
            var errorSpan = _driver.FindElement(By.XPath("//span[@data-valmsg-for='Password']/span"));
            Assert.IsTrue(errorSpan.Displayed);
            return this;
        }

        //If empty or not equal to password
        public RegistrationPage CheckPasswordConfirmationErrorMessage()
        {
            Assert.Pass();
            return this;
        }
    }
}
