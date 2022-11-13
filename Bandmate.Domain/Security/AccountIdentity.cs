using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace BandMate.Domain.Security
{
    public class AccountIdentity : GenericIdentity
    {
        private readonly int _accountID;

        public int AccountID
        {
            get { return _accountID; }
        }

        public AccountIdentity(string name, string type, int accountID) : base(name, type)
        {
            _accountID = accountID;
        }

    }
}
