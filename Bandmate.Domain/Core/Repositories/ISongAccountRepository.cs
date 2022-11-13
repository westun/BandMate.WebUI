using BandMate.Domain.Core.Models;

namespace BandMate.Domain.Core.Repositories
{
    public interface ISongAccountRepository : IRepository<SongAccount>
    {
        SongAccount Get(int songID, int accountID);
    }
}
