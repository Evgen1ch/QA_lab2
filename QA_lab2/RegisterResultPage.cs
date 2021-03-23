using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace QA_lab2
{
    class RegisterResultPage
    {
        private static string URL_MATCH = "registerresult";

        private readonly IWebDriver _driver;
        private IWebElement ContinueBtn => _driver.FindElement(By.ClassName("register-continue-button"));

        public RegisterResultPage(IWebDriver driver)
        {
            if(!driver.Url.Contains(URL_MATCH))
            {
                throw new ArgumentException("Page is not registration results page");
            }

            _driver = driver;
        }

        public MainPage Continue()
        {
            ContinueBtn.Click();
            return new MainPage(_driver);
        }
    }
}
