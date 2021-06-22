using System;
using System.Collections.Generic;
using System.Threading;
using AutoHomeFulfillment.Models;
using AutoHomeFulfillment.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoHomeFulfillment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is the password for IDXHome?");
            string homepassword = Console.ReadLine();

            Console.WriteLine("What is the client's HOME subdomain?");

            string clientDomain = Console.ReadLine();

            Console.WriteLine("Select the clients theme by typing the number");
            displayThemeIndecies();

            string clientThemeId = Console.ReadLine();

            IWebDriver driver = new ChromeDriver();

            WPLogin wpLogin = new WPLogin(driver);
            WPEmailConfirm emailConfirmModel = new WPEmailConfirm(driver);
            WPSearchAndReplace searchReplaceModel = new WPSearchAndReplace(driver);


            LoginServices login = new LoginServices(driver);
            EmailConfirmation emailConfirmPage = new EmailConfirmation(driver);
            SearchAndReplace searchAndReplace = new SearchAndReplace(driver);


            //Login Page Section
            login.GotoLoginPage(wpLogin, clientDomain);
            login.Login(wpLogin, "idxhome", homepassword);


            // Check for the email confirmation page and if it comes up then click confirm
            if (emailConfirmPage.doesExist(emailConfirmModel))
            {
                emailConfirmPage.confirmEmail(emailConfirmModel);
            }


            //Carry out Search and Replace Methods Twice Each
            //Goes to the each and replace page
            searchAndReplace.goToPage(searchReplaceModel, clientDomain);


            //This will do the search and replace for the domains
            Console.WriteLine("Performing Search and replace for the domains...");
            searchAndReplaceDomains(searchAndReplace, searchReplaceModel, clientDomain, clientThemeId);

            //Uncomment Below after creating selectTheme method
            //searchAndReplace.searchAndReplaceDomains(searchAndReplace, searchReplaceModel, clientDomain, clientThemeId);

            //Wait 30 seconds
            int domainSleeptime = 30 * 1000;
            Thread.Sleep(domainSleeptime);


            Console.WriteLine("Performing Search and replace for the domains again....");

            searchAndReplace.searchAndReplaceSecondTime(searchAndReplace, searchReplaceModel);


            //Wait 30 seconds again
            Thread.Sleep(domainSleeptime);



            Console.WriteLine("Performing Search and replace for the IDX domains...");

            SearchAndReplaceIDXDomains(clientDomain, clientThemeId, searchReplaceModel, searchAndReplace);

            int idxDomainSleeptime = 32 * 1000;
            Thread.Sleep(idxDomainSleeptime);


            Console.WriteLine("Performing Search and replace for the IDX domains again....");

            searchAndReplace.searchAndReplaceSecondTime(searchAndReplace, searchReplaceModel);


            //driver.Quit();
        }

        private static void SearchAndReplaceIDXDomains(string clientDomain, string clientThemeId, WPSearchAndReplace searchReplaceModel, SearchAndReplace searchAndReplace)
        {
            // This will carry out the search and replace for the IDX Search Domains
            string selectedTheme = verifyIDXDomain(clientThemeId, searchReplaceModel);

            searchAndReplace.fillSearchFieldWithIDXDomain(searchReplaceModel, selectedTheme);
            searchAndReplace.fillReplaceFieldWithClientIDXDomain(searchReplaceModel, clientDomain);
            // Commented out for now to not break my demo account
            //searchAndReplace.uncheckDryRun(searchReplaceModel);
            searchAndReplace.selectAllTables(searchReplaceModel);
            searchAndReplace.searchAndReplace(searchReplaceModel);
        }

        private static void searchAndReplaceDomains(SearchAndReplace searchAndReplace, WPSearchAndReplace searchReplaceModel, string clientDomain, string clientThemeId)
        {

            //Call selectThemeMethod
            string selectedTheme = verifyThemeId(clientThemeId, searchReplaceModel);

            searchAndReplace.fillSearchFieldWithDomain(searchReplaceModel, selectedTheme);
            searchAndReplace.fillReplaceFieldWithDomain(searchReplaceModel, clientDomain);
            searchAndReplace.checkCaseSensitive(searchReplaceModel);
            // Commented out for now to not break my demo account
            //searchAndReplace.uncheckDryRun(searchReplaceModel);
            searchAndReplace.selectAllTables(searchReplaceModel);
            searchAndReplace.searchAndReplace(searchReplaceModel);

        }


        private static string selectTheme(int themeId, WPSearchAndReplace searchReplaceModel)
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

        private static string selectIDXDomain(int themeId, WPSearchAndReplace searchReplaceModel)
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


        private static string verifyThemeId(string input, WPSearchAndReplace searchReplaceModel)
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

        private static string verifyIDXDomain(string input, WPSearchAndReplace searchReplaceModel)
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

        private static void displayThemeIndecies()
        {
            string listOfThemes = "1. First Impression\n" +
                                  "2. Stately\n" +
                                  "3. Curb Appeal\n" +
                                  "4. Picture Perfect\n" +
                                  "5. Must See\n" +
                                  "6. Prime Location\n" +
                                  "7. Open Floor Plan\n";


            Console.WriteLine(listOfThemes);
        }

    }
}
