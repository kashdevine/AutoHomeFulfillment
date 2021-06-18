using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHomeFulfillment.Models
{
    public class WPLogin
    {
        private IWebDriver _driver;
        public string loginUrl => "login/";
        public IWebElement usernameField => _driver.FindElement(By.Id("user_login"));
        public IWebElement passwordField => _driver.FindElement(By.Id("user_pass"));
        public IWebElement submitButton => _driver.FindElement(By.Id("wp-submit"));


        public WPLogin(IWebDriver driver)
        {
            _driver = driver;
        }


    }
}
