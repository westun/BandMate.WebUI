//using DevOne.Security.Cryptography.BCrypt;
//using System.Linq;
//using System.Web.Security;
//using BandMate.Domain.Core;
//using BandMate.Domain.Core.Models;
//using BandMate.Domain.Core.Providers;
//using BandMate.Domain.Core.Security;
//using BandMate.Domain.Security;

//namespace BandMate.Domain.Providers
//{
//    public class BandMateAuthProvider : IAuthProvider
//    {
//        private readonly IPasswordEncryptor _encryptor;
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly string version = "1.0"; //System.Configuration.ConfigurationManager.AppSettings["Authentication.Version"].ToString();
        
//        public BandMateAuthProvider(IUnitOfWork unitOfWork, IPasswordEncryptor encryptor)
//        {
//            this._encryptor = encryptor;
//            this._unitOfWork = unitOfWork;
//        }
                
//        public bool Authenticate(string username, string password, bool createPersistentCookie = false)
//        {
//            Account account = this._unitOfWork.Accounts.GetByEmailWithCredentials(username);
//            if(account == null || account.AccountCredentials == null)
//            {
//                return false;
//            }

//            string storedPassword = account.AccountCredentials
//                .FirstOrDefault(ac => ac.Version == this.version && ac.Active)?.Password;
//            if (this._encryptor.VerifyPassword(password, storedPassword))
//            {
//                FormsAuthentication.SetAuthCookie(username, createPersistentCookie);
//                return true;
//            }

//            return false;
//        }
        
//        public void Logout()
//        {
//            FormsAuthentication.SignOut();
//        }
//    }
//}
