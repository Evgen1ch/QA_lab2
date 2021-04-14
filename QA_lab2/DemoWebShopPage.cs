using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace QA_lab2
{
    abstract class DemoWebShopPage
    {
        protected IWebDriver _driver;

        protected DemoWebShopPage(IWebDriver driver, string pageLocalPath)
        {
            Uri uri = new Uri(driver.Url);
            string localPath = uri.LocalPath;

            if (localPath != pageLocalPath)
            {
                throw new ArgumentException($"Expected local path is {pageLocalPath}, but actual is {localPath}");
            }

            _driver = driver;
        }
        
    }
}
