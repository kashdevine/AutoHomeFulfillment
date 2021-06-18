using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHomeFulfillment.Models
{
    public class WPEmailConfirm
    {
        private IWebDriver _driver;
        public IWebElement confirmButton;

        public WPEmailConfirm(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
