using System.Linq;
using BandMate.Domain.Core.Models;
using BandMate.Domain.Core.Repositories;

namespace BandMate.Domain.Persistence.Repositories
{
    public class SongAccountRepository : Repository<SongAccount>, ISongAccountRepository
    {
        public SongAccountRepository(BandMateContext context)
            :base(context)
        {

        }

        public BandMateContext Context
        {
            get { return base.Context as BandMateContext; }
        }
        
        public SongAccount Get(int songID, int accountID)
        {
            return this.Context.SongAccounts
                .FirstOrDefault(sa => sa.SongID == songID && sa.AccountID == accountID);
        }
    }
}
