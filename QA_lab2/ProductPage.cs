using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace QA_lab2
{
    class ProductPage: DemoWebShopPage
    {
        public ProductPage(IWebDriver driver, string urlMatch) : base(driver, urlMatch)
        { }
    }
}
