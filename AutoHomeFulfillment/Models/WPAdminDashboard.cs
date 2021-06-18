using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHomeFulfillment.Models
{
   public class WPAdminDashboard
    {
        private IWebDriver _driver;

        public WPAdminDashboard(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
