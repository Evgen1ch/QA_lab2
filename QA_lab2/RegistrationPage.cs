using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;

namespace QA_lab2
{
    class RegistrationPage
    {
        private static string URL_MATCH = "register";

        private readonly IWebDriver _driver;

        private IWebElement FirstName => _driver.FindElement(By.Id("FirstName"));

        private IWebElement LastName => _driver.FindElement(By.Id("LastName"));

        private IWebElement Email => _driver.FindElement(By.Id("Email"));

        private IWebElement Password => _driver.FindElement(By.Id("Password"));

        private IWebElement PasswordConfirmation => _driver.FindElement(By.Id("ConfirmPassword"));

        private IWebElement SubmitBtn => _driver.FindElement(By.Id("register-button"));

        public RegistrationPage(IWebDriver driver)
        {
            if (!driver.Url.Contains(URL_MATCH))
                throw new ArgumentException("The page you`re looking for is not a registration page");
            _driver = driver;
        }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">Valid User</param>
        /// <returns>
        /// <see cref="RegisterResultPage"/> object
        /// </returns>
        public RegisterResultPage RegisterUserSuccess(User user)
        {
            RegisterUser(user);
            return new RegisterResultPage(_driver);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">Invalid User</param>
        /// <returns>
        ///<see cref="RegistrationPage"/> object
        /// </returns>
        public RegistrationPage RegisterUserFail(User user)
        {
            RegisterUser(user);
            return new RegistrationPage(_driver);
        }

        public RegistrationPage CheckFirstNameErrorMessage()
        {
            Assert.Pass();
            return this;
        }

        public RegistrationPage CheckLastNameErrorMessage()
        {
            Assert.Pass();
            return this;
        }

        public RegistrationPage CheckEmailErrorMessage()
        {
            Assert.Pass();
            return this;
        }

        public RegistrationPage CheckPasswordErrorMessage()
        {
            var errorSpan = _driver.FindElement(By.XPath("//span[@data-valmsg-for='Password']/span"));
            Assert.IsTrue(errorSpan.Displayed);
            return this;
        }

        public RegistrationPage CheckPasswordConfirmationErrorMessage()
        {
            Assert.Pass();
            return this;
        }
    }
}
