using BandMate.Domain.Core;
using BandMate.Domain.Core.Repositories;
using BandMate.Domain.Persistence.Repositories;

namespace BandMate.Domain.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BandMateContext _context;

        public UnitOfWork(BandMateContext context)
        {
            this._context = context;
            this.Accounts = new AccountRepository(this._context);
            this.Bands = new BandRepository(this._context);
            this.BandAccounts = new BandAccountRepository(this._context);
            this.BandNames = new BandNameRepository(this._context);
            this.PasswordResetRequests = new PasswordResetRequestRepository(this._context);
            this.Songs = new SongRepository(this._context);
            this.SongAccounts = new SongAccountRepository(this._context);
            this.SongListTypes = new SongListTypeRepository(this._context);
            this.Gigs = new GigRepository(this._context);
            this.SetLists = new SetListRepository(this._context);
        }

        public IAccountRepository Accounts { get; private set; }
        public IBandRepository Bands { get; private set; }
        public IBandNameRepository BandNames { get; private set; }
        public IBandAccountRepository BandAccounts { get; private set; }
        public IPasswordResetRequestRepository PasswordResetRequests { get; private set; }
        public ISongRepository Songs { get; private set; }
        public ISongAccountRepository SongAccounts { get; private set; }
        public ISongListTypeRepository SongListTypes { get; private set; }
        public IGigRepository Gigs { get; set; }
        public ISetListRepository SetLists { get; set; }

        public int Complete()
        {
            return this._context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._context.Dispose();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}
