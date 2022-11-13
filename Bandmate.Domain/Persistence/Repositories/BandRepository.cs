using System.Collections.Generic;
using System.Linq;
using BandMate.Domain.Core.Models;
using BandMate.Domain.Core.Repositories;

namespace BandMate.Domain.Persistence.Repositories
{
    public class BandRepository : Repository<Band>, IBandRepository
    {
        public BandRepository(BandMateContext context)
            :base(context)
        {
        }
        
        private BandMateContext Context
        {
            get { return base.Context as BandMateContext; }
        }

        public IEnumerable<Band> GetAllByAccountID(int accountID)
        {
            return this.Context.Bands
                .Where(b => b.BandAccounts.Any(ba => ba.AccountID == accountID))
                .ToList();
        }

        public Band GetDefaultBand(int accountID)
        {
            return this.Context.Bands
                .FirstOrDefault(b => b.BandAccounts.Any(ba => ba.AccountID == accountID && ba.Default));
        }
    }
}
