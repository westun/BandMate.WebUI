using System.Collections.Generic;
using System.Linq;
using BandMate.Domain.Core.Models;
using BandMate.Domain.Core.Repositories;

namespace BandMate.Domain.Persistence.Repositories
{
    class BandAccountRepository : IBandAccountRepository
    {
        private readonly BandMateContext _context;

        public BandAccountRepository(BandMateContext context)
        {
            this._context = context;
        }

        public IEnumerable<BandAccount> GetAll(int accountID)
        {
            return this._context.BandAccounts
                .Where(ba => ba.AccountID == accountID)
                .ToList();
        }

        public BandAccount GetDefaultBand(int accountID)
        {
            return this._context.BandAccounts
                .FirstOrDefault(ba => ba.AccountID == accountID && ba.Default);
        }
    }
}
