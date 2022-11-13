using BandMate.Domain.Core.Models;
using System.Collections.Generic;

namespace BandMate.Domain.Core.Repositories
{
    public interface IGigRepository
    {
        IEnumerable<Gig> GetAllWithVenue(int bandID);
    }
}