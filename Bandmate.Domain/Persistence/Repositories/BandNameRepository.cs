using System.Collections.Generic;
using System.Linq;
using BandMate.Domain.Core.Models;
using BandMate.Domain.Core.Repositories;

namespace BandMate.Domain.Persistence.Repositories
{
    public class BandNameRepository : Repository<BandName>, IBandNameRepository
    {
        public BandNameRepository(BandMateContext context)
            :base(context)
        {
        }

        private BandMateContext BandMateContext
        {
            get { return base.Context as BandMateContext; }
        }

        public IEnumerable<BandName> GetAllByBandID(int bandID)
        {
            return BandMateContext.BandNames.Where(bn => bn.BandID == bandID);
        }
    }
}
