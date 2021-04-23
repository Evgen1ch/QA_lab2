using NUnit.Framework;
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

        private User _registerUser;
        private User _loginUser;
        private User _logoutUser;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _registerUser = User.CreateValidUser();
            _loginUser = User.CreateValidUser();
            _logoutUser = User.CreateValidUser();
        }

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _baseUrl = "http://demowebshop.tricentis.com";
            _driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void RegistrationSuccessTest()
        {
            _driver.Navigate().GoToUrl(_baseUrl + "/register");
            
            RegistrationPage registrationPage = new RegistrationPage(_driver);
            registrationPage
                .RegisterUserSuccess(_registerUser)
                .Continue()
                .CheckEmailMatch(_registerUser.Email);
        }

        [Test]
        public void RegistrationFailTest()
        {
            _driver.Navigate().GoToUrl(_baseUrl + "/register");
            User user = _registerUser.Copy();
            user.Password = "1";

            RegistrationPage registrationPage = new RegistrationPage(_driver);
            registrationPage
                .RegisterUserFail(user)
                .CheckPasswordErrorMessage();
        }

        [Test]
        public void AddItemToCartTest()
        {
            string expectedItem = "Computing and Internet";

            _driver.Navigate().GoToUrl(_baseUrl);

            MainPage mainPage = new MainPage(_driver);
            mainPage
                .GoToBooksPage()
                .GetBook()
                .GoToCart()
                .CheckProductInCart(expectedItem);
        }

        [Test]
        public void LoginSuccessTest()
        {
            //register
            //log in
            _driver.Navigate().GoToUrl(_baseUrl);

            MainPage mainPage = new MainPage(_driver);
            var afterRegister = mainPage
                .GoToRegistration()
                .RegisterUserSuccess(_loginUser)
                .Continue()
                .ClickLogOut();

            afterRegister
                .GoToLogin()
                .TypeEmail(_loginUser.Email)
                .TypePassword(_loginUser.Password)
                .LoginSuccess()
                .CheckEmailMatch(_loginUser.Email);
        }

        [Test]
        public void LoginFailTest()
        {
            string email = _loginUser.Email;
            string password = "a";
            _driver.Navigate().GoToUrl(_baseUrl);

            MainPage mainPage = new MainPage(_driver);
            mainPage
                .GoToLogin()
                .TypeEmail(email)
                .TypePassword(password)
                .LoginFail()
                .CheckErrorMessage();
        }

        [Test]
        public void LogoutTest()
        {
            //register
            //log out
            _driver.Navigate().GoToUrl(_baseUrl);

            MainPage mainPage = new MainPage(_driver);
            var mainPageAfterRegister = mainPage
                .GoToRegistration()
                .RegisterUserSuccess(_logoutUser)
                .Continue();

            mainPageAfterRegister
                .ClickLogOut()
                .CheckLogoutSuccess();
        }
    }
}