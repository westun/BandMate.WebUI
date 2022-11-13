using BandMate.Domain.Core.Models;
using System.Collections.Generic;

namespace BandMate.Domain.Core.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetByEmail(string email);
        Account GetByEmailWithCredentials(string email);
        Account GetWithCredentials(int accountID);
        IEnumerable<Account> GetAll(int bandID);
    }
}
