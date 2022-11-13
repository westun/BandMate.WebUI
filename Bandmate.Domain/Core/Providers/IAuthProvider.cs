namespace BandMate.Domain.Core.Providers
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password, bool createPersistentCookie = false);
        void Logout();
    }
}
