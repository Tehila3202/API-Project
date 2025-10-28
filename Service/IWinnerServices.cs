using chineseAction.Models;

namespace chineseAction.Service
{
    public interface IWinnerServices
    {
        IEnumerable<WinnerMask> GetAllWinner();
        WinnerMask getById(int id);

        bool Create(int PresentId);
    }
}