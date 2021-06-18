using AutoHomeFulfillment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHomeFulfillment.Contracts
{
    public interface IEmailConfirmation
    {
        bool doesExist(WPEmailConfirm wPEmailconfirmation);
        void confirmEmail(WPEmailConfirm wPEmailconfirmation);
    }
}
