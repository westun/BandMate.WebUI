using BandMate.Domain.Core.Models;
using System.Collections.Generic;

namespace BandMate.Domain.Core.Repositories
{
    public interface ISongListTypeRepository : IRepository<SongListType>
    {
        IEnumerable<SongListType> GetByBandID(int bandID);
    }
}
