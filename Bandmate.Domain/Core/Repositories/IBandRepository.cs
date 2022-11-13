using System.Collections.Generic;
using BandMate.Domain.Core.Models;

namespace BandMate.Domain.Core.Repositories
{
    public interface IBandRepository : IRepository<Band>
    {
        IEnumerable<Band> GetAllByAccountID(int accountID);
        Band GetDefaultBand(int accountID);
    }
}
