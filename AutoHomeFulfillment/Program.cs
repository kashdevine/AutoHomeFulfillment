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

            Utilities.Utilities.displayThemeIndecies();

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
            searchAndReplace.searchAndReplaceDomains(searchAndReplace, searchReplaceModel, clientDomain, clientThemeId);

            //Wait 30 seconds
            int domainSleeptime = 30 * 1000;
            Thread.Sleep(domainSleeptime);


            Console.WriteLine("Performing Search and replace for the domains again....");

            searchAndReplace.searchAndReplaceSecondTime(searchAndReplace, searchReplaceModel);


            //Wait 30 seconds again
            Thread.Sleep(domainSleeptime);



            Console.WriteLine("Performing Search and replace for the IDX domains...");

            searchAndReplace.SearchAndReplaceIDXDomains(clientDomain, clientThemeId, searchReplaceModel, searchAndReplace);

            int idxDomainSleeptime = 32 * 1000;
            Thread.Sleep(idxDomainSleeptime);


            Console.WriteLine("Performing Search and replace for the IDX domains again....");

            searchAndReplace.searchAndReplaceSecondTime(searchAndReplace, searchReplaceModel);


            //driver.Quit();
        }
    }
}
