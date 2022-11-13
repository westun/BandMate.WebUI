namespace BandMate.Domain.Core.Security
{
    public interface IPasswordEncryptor
    {
        bool VerifyPassword(string password, string hashedPassword);
        string GenerateSalt();
        string HashPassword(string password, string salt);
    }
}
