using AutoHomeFulfillment.Contracts;
using AutoHomeFulfillment.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHomeFulfillment.Services
{
    public class LoginServices : ILoginServices
    {
        IWebDriver _driver;

        public LoginServices(IWebDriver driver)
        {
            _driver = driver;
        }

        public string configureLoginURL(WPLogin loginPage, string mainDomainName)
        {
            string secureProtocol = "https://";
            string idxHOMESubdomain = ".idxbrokerhome.com/";
            var resultURL = secureProtocol + mainDomainName + idxHOMESubdomain + loginPage.loginUrl;
            return resultURL;
        }

        public void GotoLoginPage(WPLogin wPLogin,  string mainDomainName)
        {
            if (string.IsNullOrEmpty(mainDomainName)) 
            {
                Console.WriteLine("Nothing was entered.");
                Console.Write("What is the client's domain?\n");

                string input = Console.ReadLine();

                GotoLoginPage(wPLogin, input);
            }
            string HOMESiteUrl = configureLoginURL(wPLogin, mainDomainName);

            _driver.Navigate().GoToUrl(HOMESiteUrl);
        }

        public WPAdminDashboard Login(WPLogin wPLogin, string username, string password)
        {
            wPLogin.usernameField.Clear();
            wPLogin.passwordField.Clear();

            wPLogin.usernameField.SendKeys(username);
            wPLogin.passwordField.SendKeys(password);

            wPLogin.submitButton.Click();
            return new WPAdminDashboard(_driver);
            
        }
    }
}
