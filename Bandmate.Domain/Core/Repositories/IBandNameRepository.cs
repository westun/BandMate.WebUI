using System.Collections.Generic;
using BandMate.Domain.Core.Models;

namespace BandMate.Domain.Core.Repositories
{
    public interface IBandNameRepository: IRepository<BandName>
    {
        IEnumerable<BandName> GetAllByBandID(int bandID);
    }
}
