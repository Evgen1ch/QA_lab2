﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace QA_lab2
{
    class CartPage: DemoWebShopPage
    {
        private static string URL_MATCH = "cart";

        private IWebElement CartTable => _driver.FindElement(By.ClassName("cart"));

        public CartPage(IWebDriver driver): base(driver, URL_MATCH) { }

        public CartPage CheckProductInCart(string productName)
        {
            var table = _driver.FindElement(By.ClassName("cart")).FindElements(By.ClassName("product"));
            foreach (var row in table)
            {
                if (row.GetProperty("textContent").Trim() == productName)
                {
                    return this;
                }
            }
            throw new AssertionException("Product was not find");
        }
    }
}