using AutoHomeFulfillment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHomeFulfillment.Contracts
{
    public interface ILoginServices
    {
        string configureLoginURL(WPLogin loginPage, string mainDomainName);
        void GotoLoginPage(WPLogin wPLogin,  string mainDomainName);
        WPAdminDashboard Login(WPLogin wPLogin, string username, string password);
    }
}
