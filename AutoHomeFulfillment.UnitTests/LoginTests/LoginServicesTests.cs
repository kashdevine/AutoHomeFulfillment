using AutoHomeFulfillment.Contracts;
using AutoHomeFulfillment.Models;
using AutoHomeFulfillment.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AutoHomeFulfillment.UnitTests.LoginTests
{
    public class LoginServicesTests
    {
        IWebDriver _driver;
        ILoginServices sut;
        WPLogin _loginPage;

        public LoginServicesTests()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");
            IWebDriver _driver = new ChromeDriver(chromeOptions);
            WPLogin _loginPage = new WPLogin(_driver);
            ILoginServices sut = new LoginServices(_driver);
        }

        [Fact]
        public void configureLoginURL_returnsValidURL() {
            //Arrange
            string testDomain = "kmowatt";
            string expected = "https://kmowatt.idxbrokerhome.com";
            //Act
            var result = sut.configureLoginURL(_loginPage, testDomain);

            //Assert
            Assert.Matches(expected, result);
        }

    }
}
