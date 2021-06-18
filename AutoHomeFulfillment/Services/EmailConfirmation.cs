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
    class EmailConfirmation : IEmailConfirmation
    {
        private readonly IWebDriver _driver;

        public EmailConfirmation(IWebDriver driver)
        {
            _driver = driver;
        }
        public void confirmEmail(WPEmailConfirm wPEmailconfirmation)
        {
            wPEmailconfirmation.confirmButton.Click();
        }

        public bool doesExist(WPEmailConfirm wPEmailconfirmation)
        {
            try
            {
                wPEmailconfirmation.confirmButton = _driver.FindElement(By.Id("correct-admin-email"));
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return false;
            }
        }
    }
}
