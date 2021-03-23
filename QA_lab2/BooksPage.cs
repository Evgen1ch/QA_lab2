using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace QA_lab2
{
    class BooksPage: DemoWebShopPage
    {
        private static string URL_MATCH = "books";

        private IWebElement FirstBook => _driver.FindElement(By.ClassName("item-box"))
            .FindElement(By.CssSelector(".button-2.product-box-add-to-cart-button"));

        public BooksPage(IWebDriver driver): base(driver, URL_MATCH) { }

        public BooksPage GetBook()
        {
            FirstBook.Click();
            return this;
        }
    }
}
