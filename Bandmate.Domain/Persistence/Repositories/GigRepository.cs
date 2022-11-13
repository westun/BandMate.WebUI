using BandMate.Domain.Core.Models;
using BandMate.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BandMate.Domain.Persistence.Repositories
{
    public class GigRepository : Repository<Account>, IGigRepository
    {
        public GigRepository(BandMateContext context)
            : base(context)
        {
        }

        private BandMateContext Context
        {
            get { return base.Context as BandMateContext; }
        }

        public IEnumerable<Gig> GetAllWithVenue(int bandID)
        {
            return Context.Gigs
                .Include(g => g.Venue)
                .Include(g => g.Venue.Address)
                .Where(g => g.BandID == bandID)
                .ToList();
        }
    }
}
