using System;
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
            Console.WriteLine("Performing Search and replace...");
            searchAndReplaceDomains(searchAndReplace, searchReplaceModel, clientDomain);

            //Uncomment Below after creating selectTheme method
            //searchAndReplace.searchAndReplaceDomains(searchAndReplace, searchReplaceModel,clientDomain);

            //Wait 30 seconds
            int sleeptime = 30 * 1000;
            Thread.Sleep(sleeptime);


            Console.WriteLine("Performing Search and replace again....");

            searchAndReplace.searchAndReplaceSecondTime(searchAndReplace, searchReplaceModel);



            // This will carry out the search and replace for the IDX Search Domains
            searchAndReplace.fillSearchFieldWithIDXDomain(searchReplaceModel, searchReplaceModel.firstImpressionIDXDomain);
            searchAndReplace.fillReplaceFieldWithClientIDXDomain(searchReplaceModel, clientDomain);
            // Commented out for now to not break my demo account
            //searchAndReplace.uncheckDryRun(searchReplaceModel);
            searchAndReplace.selectAllTables(searchReplaceModel);
            searchAndReplace.searchAndReplace(searchReplaceModel);


            //driver.Quit();
        }

        private static void searchAndReplaceDomains(SearchAndReplace searchAndReplace, WPSearchAndReplace searchReplaceModel, string clientDomain)
        {
            // Currently using the First Impression information to load information in the search and replace
            // I will have refactor to allow the theme information to be optional

            //Call selectThemeMethod
            searchAndReplace.fillSearchFieldWithDomain(searchReplaceModel, searchReplaceModel.firstImpressionDomain);
            searchAndReplace.fillReplaceFieldWithDomain(searchReplaceModel, clientDomain);
            searchAndReplace.checkCaseSensitive(searchReplaceModel);
            // Commented out for now to not break my demo account
            //searchAndReplace.uncheckDryRun(searchReplaceModel);
            searchAndReplace.selectAllTables(searchReplaceModel);
            searchAndReplace.searchAndReplace(searchReplaceModel);

        }

        //Create selectTheme method
        private static void selectTheme(int themeId)
        {
            //TODO: Implement switch statement for themes
        }


        private static void verifyThemeId(string input)
        {
            int themeId;

            try
            {
                int inputInt = Int32.Parse(input);
                themeId = inputInt;
                selectTheme(themeId);
            }
            catch (Exception)
            {

                Console.WriteLine($"{input} was not a valid integer. Please try again.");

            }
            
        }


    }
}
