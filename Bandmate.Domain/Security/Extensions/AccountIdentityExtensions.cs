using System.Security.Principal;

namespace BandMate.Domain.Security.Extensions
{
    public static class AccountIdentityExtensions
    {
        public static int GetAccountID(this IIdentity identity)
        {
            var accountIdentity = identity as AccountIdentity;
            if (accountIdentity != null)
            {
                return accountIdentity.AccountID;
            }
            return 0;
        }
    }
}
