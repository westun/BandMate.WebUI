using BandMate.Domain.Core.Models;

namespace BandMate.Domain.Core.Repositories
{
    public interface ISetListRepository
    {
        SetList GetWithSetListItems(int setListID, int bandID);
    }
}