using System;
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
            Console.Write("What is the client's domain?\n");

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
            login.Login(wpLogin, "idxhome", "5qaHTYtcbPoUDKyRVvfrpKv9");


            // Check for the email confirmation page and if it comes up then click confirm
            if (emailConfirmPage.doesExist(emailConfirmModel))
            {
                emailConfirmPage.confirmEmail(emailConfirmModel);
            }


            //Carry out Search and Replace Methods
            searchAndReplace.goToPage(searchReplaceModel, clientDomain);
            searchAndReplace.fillSearchFieldWithDomain(searchReplaceModel, searchReplaceModel.firstImpressionDomain);
            searchAndReplace.fillReplaceFieldWithDomain(searchReplaceModel, clientDomain);
            searchAndReplace.checkCaseSensitive(searchReplaceModel);
            // Commented out for now to not break my demo account
            //searchAndReplace.uncheckDryRun(searchReplaceModel);

            //TODO: select all of the tables

            searchAndReplace.searchAndReplace(searchReplaceModel);


            


            //driver.Quit();
        }
    }
}
