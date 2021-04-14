using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace QA_lab2
{
    class RegisterResultPage: DemoWebShopPage
    {
        private static string URL_MATCH = "/registerresult/1";

        private IWebElement ContinueBtn => _driver.FindElement(By.ClassName("register-continue-button"));

        public RegisterResultPage(IWebDriver driver) :base(driver, URL_MATCH) { }

        public MainPage Continue()
        {
            ContinueBtn.Click();
            return new MainPage(_driver);
        }
    }
}
