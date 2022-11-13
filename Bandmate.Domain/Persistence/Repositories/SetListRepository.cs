using BandMate.Domain.Core.Models;
using BandMate.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BandMate.Domain.Persistence.Repositories
{
    public class SetListRepository : Repository<Account>, ISetListRepository
    {
        public SetListRepository(BandMateContext context)
            : base(context)
        {
        }

        private BandMateContext Context
        {
            get { return base.Context as BandMateContext; }
        }

        public SetList GetWithSetListItems(int setListID, int bandID)
        {
            return this.Context.SetLists
                .Include(sl => sl.SetListItems)
                .Include(sl => sl.SetListItems.Select(sli => sli.Song))
                .FirstOrDefault(sl => sl.SetListID == setListID && sl.Band.BandID == bandID);
        }
    }
}
