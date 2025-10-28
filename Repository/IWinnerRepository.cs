using chineseAction.Models;

namespace chineseAction.Repository
{
    public interface IWinnerRepository
    {
        IEnumerable<WinnerMask> GetAllWinner();
        //Winner getById(int id);

        bool Create(Winner w);
    }
}