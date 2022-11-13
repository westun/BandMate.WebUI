using System;
using BandMate.Domain.Core.Repositories;
using BandMate.Domain.Persistence.Repositories;

namespace BandMate.Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IBandRepository Bands { get; }
        IBandAccountRepository BandAccounts { get; }
        IBandNameRepository BandNames { get; }
        IPasswordResetRequestRepository PasswordResetRequests { get; }
        ISongRepository Songs { get; }
        ISongAccountRepository SongAccounts { get; }
        ISongListTypeRepository SongListTypes { get; }
        IGigRepository Gigs { get; }
        ISetListRepository SetLists { get; }
        int Complete();
    }
}
