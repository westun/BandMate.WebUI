using BandMate.Domain.Core.Models;
using System.Collections.Generic;

namespace BandMate.Domain.Core.Repositories
{
    public interface IPasswordResetRequestRepository
    {
        PasswordResetRequest GetByIDAndToken(int passwordResetRequestID, string token);
        IEnumerable<PasswordResetRequest> GetAllRevocableTokens(int accountID);
        void Add(PasswordResetRequest passwordResetRequest);
    }
}
