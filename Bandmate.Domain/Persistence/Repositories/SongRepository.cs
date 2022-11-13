using BandMate.Domain.Core.Models;
using BandMate.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BandMate.Domain.Persistence.Repositories
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        public SongRepository(BandMateContext context)
            : base(context)
        {
        }

        private BandMateContext Context
        {
            get { return base.Context as BandMateContext; }
        }

        public IEnumerable<Song> GetByBandID(int bandID)
        {
            return this.Context.Songs
                .Where(s => s.Band.BandID == bandID)
                .Include(s => s.SongAccounts)
                .Include(s => s.SongListType)
                .OrderBy(s => s.Artist)
                .ThenBy(s => s.Title)
                .ToList();
        }

        public Song GetWithSongAccounts(int songID)
        {
            return this.Context.Songs
                .Where(s => s.SongID == songID)
                .Include(s => s.SongAccounts)
                .Include(s => s.SongListType)
                .FirstOrDefault();
        }
    }
}
