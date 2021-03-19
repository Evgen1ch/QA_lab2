using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QA_lab2
{
    [TestFixture]
    public class RegistrationTests
    {
        private ChromeDriver _driver;
        private string _baseUrl;
        private RegistrationPage _registrationPage;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _baseUrl = "http://demowebshop.tricentis.com/register";
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void RegistrationSuccessTest()
        {
            
            Assert.Pass();
        }
    }
}