using System.Collections.Generic;
using BandMate.Domain.Core.Models;

namespace BandMate.Domain.Core.Repositories
{
    public interface IBandAccountRepository
    {
        BandAccount GetDefaultBand(int accountID);
        IEnumerable<BandAccount> GetAll(int accountID);
    }
}
