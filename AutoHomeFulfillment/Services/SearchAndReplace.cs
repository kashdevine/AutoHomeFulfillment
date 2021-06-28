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

        public void fillReplaceFieldWithClientIDXDomain(WPSearchAndReplace searchAndReplacePage, string clientIDXDomain)
        {
            string fullDomain = clientIDXDomain + ".idxbroker.com";
            searchAndReplacePage.replaceField.Clear();
            searchAndReplacePage.replaceField.SendKeys(fullDomain);
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

        public void fillSearchFieldWithIDXDomain(WPSearchAndReplace searchAndReplacePage, string themeIDXDomain)
        {
            searchAndReplacePage.searchField.Clear();
            searchAndReplacePage.searchField.SendKeys(themeIDXDomain);
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

        public void selectAllTables(WPSearchAndReplace searchAndReplacePage)
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

        public void searchAndReplaceSecondTime(SearchAndReplace searchAndReplace, WPSearchAndReplace searchReplaceModel)
        {
            // Commented out for now to not break my demo account
            searchAndReplace.uncheckDryRun(searchReplaceModel);
            searchAndReplace.searchAndReplace(searchReplaceModel);

        }
        public void SearchAndReplaceIDXDomains(string clientDomain, string clientThemeId, WPSearchAndReplace searchReplaceModel, SearchAndReplace searchAndReplace)
        {
            // This will carry out the search and replace for the IDX Search Domains
            string selectedTheme = verifyIDXDomain(clientThemeId, searchReplaceModel);

            searchAndReplace.fillSearchFieldWithIDXDomain(searchReplaceModel, selectedTheme);
            searchAndReplace.fillReplaceFieldWithClientIDXDomain(searchReplaceModel, clientDomain);
            // Commented out for now to not break my demo account
            searchAndReplace.uncheckDryRun(searchReplaceModel);
            searchAndReplace.selectAllTables(searchReplaceModel);
            searchAndReplace.searchAndReplace(searchReplaceModel);
        }

        public void searchAndReplaceDomains(SearchAndReplace searchAndReplace, WPSearchAndReplace searchReplaceModel, string clientDomain, string clientThemeId)
        {

            //Call selectThemeMethod
            string selectedTheme = verifyThemeId(clientThemeId, searchReplaceModel);

            searchAndReplace.fillSearchFieldWithDomain(searchReplaceModel, selectedTheme);
            searchAndReplace.fillReplaceFieldWithDomain(searchReplaceModel, clientDomain);
            searchAndReplace.checkCaseSensitive(searchReplaceModel);
            // Commented out for now to not break my demo account
            searchAndReplace.uncheckDryRun(searchReplaceModel);
            searchAndReplace.selectAllTables(searchReplaceModel);
            searchAndReplace.searchAndReplace(searchReplaceModel);

        }


        public string selectTheme(int themeId, WPSearchAndReplace searchReplaceModel)
        {

            switch (themeId)
            {
                case 1:
                    return searchReplaceModel.firstImpressionDomain;
                case 2:
                    return searchReplaceModel.statelyDomain;
                case 3:
                    return searchReplaceModel.curbAppealDomain;
                case 4:
                    return searchReplaceModel.picturePerfectDomain;
                case 5:
                    return searchReplaceModel.mustSeeDomain;
                case 6:
                    return searchReplaceModel.primeLocationDomain;
                case 7:
                    return searchReplaceModel.openFloorPlanDomain;
                default:
                    return string.Empty;
            }

        }

        public string selectIDXDomain(int themeId, WPSearchAndReplace searchReplaceModel)
        {
            switch (themeId)
            {
                case 1:
                    return searchReplaceModel.firstImpressionIDXDomain;
                case 2:
                    return searchReplaceModel.statelyIDXDomain;
                case 3:
                    return searchReplaceModel.curbAppealIDXDomain;
                case 4:
                    return searchReplaceModel.picturePerfectIDXDomain;
                case 5:
                    return searchReplaceModel.mustSeeIDXDomain;
                case 6:
                    return searchReplaceModel.primeLocationIDXDomain;
                case 7:
                    return searchReplaceModel.openFloorPlanIDXDomain;
                default:
                    return string.Empty;
            }
        }


        public string verifyThemeId(string input, WPSearchAndReplace searchReplaceModel)
        {
            int themeId;

            try
            {
                int inputInt = Int32.Parse(input);
                themeId = inputInt;
                return selectTheme(themeId, searchReplaceModel);
            }
            catch (Exception)
            {

                Console.WriteLine($"{input} was not a valid integer. Please try again.");
                return string.Empty;
            }

        }

        public string verifyIDXDomain(string input, WPSearchAndReplace searchReplaceModel)
        {
            int themeId;

            try
            {
                int inputInt = Int32.Parse(input);
                themeId = inputInt;
                return selectIDXDomain(themeId, searchReplaceModel);
            }
            catch (Exception)
            {

                Console.WriteLine($"{input} was not a valid integer. Please try again.");
                return string.Empty;
            }

        }
    }
}
