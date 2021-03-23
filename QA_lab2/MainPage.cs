using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace QA_lab2
{
    class MainPage: DemoWebShopPage
    {
        private static string URL_MATCH = "http://demowebshop.tricentis.com/";
        
        private IWebElement Books => _driver.FindElement(By.LinkText("Books"));

        //mb other page elements

        public MainPage(IWebDriver driver): base(driver, URL_MATCH) { }

        public BooksPage GoToBooksPage()
        {
            Books.Click();
            return new BooksPage(_driver);
        }
    }
}
