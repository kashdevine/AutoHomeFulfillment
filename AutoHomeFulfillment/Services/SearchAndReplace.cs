using AutoHomeFulfillment.Contracts;
using AutoHomeFulfillment.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHomeFulfillment.Services
{
    public class SearchAndReplace : ISearchAndReplace
    {
        private readonly IWebDriver _driver;


        public SearchAndReplace(IWebDriver driver)
        {
            _driver = driver;
        }

        public void checkCaseSensitive(WPSearchAndReplace searchAndReplacePage)
        {
            searchAndReplacePage.caseInsensitiveCheckBox.Click();
        }

        public void fillReplaceFieldWithDomain(WPSearchAndReplace searchAndReplacePage, string clientDomain)
        {
            string fullDomain = clientDomain + ".idxbrokerhome.com";
            searchAndReplacePage.replaceField.Clear();
            searchAndReplacePage.replaceField.SendKeys(fullDomain);
        }

        public void fillSearchFieldWithDomain(WPSearchAndReplace searchAndReplacePage, string themeDomain)
        {
            searchAndReplacePage.searchField.Clear();
            searchAndReplacePage.searchField.SendKeys(themeDomain);

        }

        public void goToPage(WPSearchAndReplace searchAndReplacePage, string mainDomainName)
        {
            string secureProtocol = "https://";
            string fullDomain = secureProtocol + mainDomainName + ".idxbrokerhome.com/wp-admin/tools.php?page=better-search-replace";
            _driver.Navigate().GoToUrl(fullDomain);

        }

        public void searchAndReplace(WPSearchAndReplace searchAndReplacePage)
        {
            searchAndReplacePage.runButton.Click();
        }

        public void selectAlltables(WPSearchAndReplace searchAndReplacePage)
        {
            SelectElement tableselection = new SelectElement(searchAndReplacePage.tablesSelection);

            for(var i =0; i < tableselection.Options.Count(); i++)
            {
                tableselection.SelectByIndex(i);
            }

        }

        public void uncheckDryRun(WPSearchAndReplace searchAndReplacePage)
        {
            searchAndReplacePage.dryRunCheckBox.Click();
        }
    }
}
