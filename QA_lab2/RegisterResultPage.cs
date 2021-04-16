using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace QA_lab2
{
    class RegisterResultPage: DemoWebShopPage
    {
        private static string LocalPath = "/registerresult/1";

        private IWebElement ContinueBtn => _driver.FindElement(By.ClassName("register-continue-button"));

        public RegisterResultPage(IWebDriver driver) :base(driver, LocalPath) { }

        public MainPage Continue()
        {
            ContinueBtn.Click();
            return new MainPage(_driver);
        }
    }
}
