using AutoHomeFulfillment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHomeFulfillment.Contracts
{
    public interface ISearchAndReplace
    {
        void goToPage(WPSearchAndReplace searchAndReplacePage, string mainDomainName);
        void fillSearchFieldWithDomain(WPSearchAndReplace searchAndReplacePage, string themeDomain);
        void fillReplaceFieldWithDomain(WPSearchAndReplace searchAndReplacePage, string clientDomain);
        void fillSearchFieldWithIDXDomain(WPSearchAndReplace searchAndReplacePage, string themeDomain);
        void fillReplaceFieldWithClientIDXDomain(WPSearchAndReplace searchAndReplacePage, string clientIDXDomain);
        void checkCaseSensitive(WPSearchAndReplace searchAndReplacePage);
        void uncheckDryRun(WPSearchAndReplace searchAndReplacePage);
        void searchAndReplace(WPSearchAndReplace searchAndReplacePage);
        void selectAllTables(WPSearchAndReplace searchAndReplacePage);
        
    }
}
