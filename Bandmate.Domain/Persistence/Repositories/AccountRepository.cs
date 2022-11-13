using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BandMate.Domain.Core.Models;
using BandMate.Domain.Core.Repositories;

namespace BandMate.Domain.Persistence.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(BandMateContext context)
            : base(context)
        {
        }
        
        private BandMateContext Context
        {
            get { return base.Context as BandMateContext; }
        }
        
        public Account GetByEmail(string email)
        {
            return this.Context.Accounts
                .Include(a => a.Roles)
                .FirstOrDefault(a => a.Email == email);
        }

        public Account GetByEmailWithCredentials(string email)
        {
            return this.Context.Accounts
                .Include(a => a.AccountCredentials)
                .FirstOrDefault(a => a.Email == email);
        }

        public Account GetWithCredentials(int accountID)
        {
            return this.Context.Accounts
                .Include(a => a.AccountCredentials)
                .FirstOrDefault(a => a.AccountID == accountID);
        }

        public IEnumerable<Account> GetAll(int bandID)
        {
            return this.Context.BandAccounts
                .Where(ba => ba.BandID == bandID)
                .Select(ba => ba.Account)
                .ToList();
        }
    }
}
