using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace QA_lab2
{
    class BooksPage: DemoWebShopPage
    {
        private static string LocalPath = "/books";

        private IWebElement FirstBook => _driver.FindElement(By.ClassName("item-box"))
            .FindElement(By.CssSelector(".button-2.product-box-add-to-cart-button"));

        public IWebElement Cart => _driver.FindElement(By.ClassName("ico-cart"));

        public BooksPage(IWebDriver driver): base(driver, LocalPath) { }

        public BooksPage GetBook()
        {
            FirstBook.Click();
            return this;
        }

        public CartPage GoToCart()
        {
            Cart.Click();
            return new CartPage(_driver);
        }
    }
}
