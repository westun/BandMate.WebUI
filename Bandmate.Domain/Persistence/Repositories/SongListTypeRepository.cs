using BandMate.Domain.Core.Models;
using BandMate.Domain.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BandMate.Domain.Persistence.Repositories
{
    public class SongListTypeRepository : Repository<SongListType>, ISongListTypeRepository
    {
        public SongListTypeRepository(BandMateContext context)
            : base(context)
        {
        }

        private BandMateContext Context
        {
            get { return base.Context as BandMateContext; }
        }

        public IEnumerable<SongListType> GetByBandID(int bandID)
        {
            return this.Context.SongListTypes
                .Where(s => s.Band.BandID == bandID)
                .OrderBy(s => s.SortOrder)
                .ToList();
        }
    }
}
