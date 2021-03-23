using System;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

//------Tests------
// Registration
// Move item to cart
// Log in
// Log out

namespace QA_lab2
{
    [TestFixture]
    public class DemoWebShopTests
    {
        private ChromeDriver _driver;
        private string _baseUrl;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _baseUrl = "http://demowebshop.tricentis.com";
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test, Order(1)]
        public void RegistrationSuccessTest()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(_baseUrl + "/register");
            User user = User.CreateValidUser();

            RegistrationPage registrationPage = new RegistrationPage(_driver);
            registrationPage
                .RegisterUserSuccess(user)
                .Continue();

            //todo logout
        }

        [Test, Order(2)]
        public void RegistrationFailTest()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(_baseUrl + "/register");
            User user = User.CreateValidUser();
            user.Password = "1";

            RegistrationPage registrationPage = new RegistrationPage(_driver);
            registrationPage
                .RegisterUserFail(user)
                .CheckPasswordErrorMessage();

            //todo logout
        }

        [Test, Order(3)]
        public void AddItemToCartTest()
        {
            string expectedItem = "Computing and Internet";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(_baseUrl);

            MainPage mainPage = new MainPage(_driver);
            ((CartPage) mainPage
                    .GoToBooksPage()
                    .GetBook()
                    .GoToCart())
                .CheckProductInCart(expectedItem);
        }

        [Test, Order(4)]
        public void LoginSuccessTest()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(_baseUrl);
            Assert.Pass();
        }

        public void LoginFailTest()
        {
            Assert.Pass();
        }

        public void LogoutTest()
        {
            Assert.Pass();
        }
    }
}