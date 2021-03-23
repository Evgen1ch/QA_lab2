using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace QA_lab2
{
    abstract class DemoWebShopPage
    {
        protected IWebDriver _driver;
        protected IWebElement LogIn => _driver.FindElement(By.ClassName("ico-login"));

        protected IWebElement LogOut => _driver.FindElement(By.ClassName("ico-logout"));

        protected IWebElement Cart => _driver.FindElement(By.ClassName("ico-cart"));

        protected DemoWebShopPage(IWebDriver driver, string urlMatch)
        {
            if (!driver.Url.Contains(urlMatch))
                throw new ArgumentException($"Url is wrong. Expected match: {urlMatch}. Actual URL: {_driver.Url}");

            _driver = driver;
        }

        public DemoWebShopPage GoToCart()
        {
            Cart.Click();
            return new CartPage(_driver);
        }
    }
}
