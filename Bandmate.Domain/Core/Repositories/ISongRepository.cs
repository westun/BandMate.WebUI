using System.Collections.Generic;
using BandMate.Domain.Core.Models;

namespace BandMate.Domain.Core.Repositories
{
    public interface ISongRepository : IRepository<Song>
    {
        IEnumerable<Song> GetByBandID(int bandID);
        Song GetWithSongAccounts(int songID);
    }
}
